/*****************************************************
*  EnvironmentManager ++
*  • Gestion centralisée de la santé de l’environnement
*  • Post‑process, courbes & FX en temps réel
*  • Groupes d’éléments activés/désactivés par seuil
*  • Interpolation fluide + évènement global
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EnvironmentManager : MonoBehaviour
{
    #region === Inspector ===
    [Header("Health Settings")]
    [Tooltip("‑1 = apocalypse, 1 = paradis")]
    [Range(-1f, 1f)] public  float environmentHealth = 0f;
    [Tooltip("Vitesse de transition visuelle")]
    [Min(0f)] public  float lerpSpeed        = 2f;

    [Header("Post‑Process")]
    public Volume        postProcess;
    public AnimationCurve saturationCurve;               // ‑1→‑100, 0→0, 1→+40

    [Header("Element Groups")]
    [Tooltip("Liste de groupes pilotés par la jauge")]
    public ElementGroup[] groups;                         // cf. struct plus bas
    #endregion

    #region === Runtime ===
    public  static EnvironmentManager Instance { get; private set; }
    public  event Action<float> OnHealthChanged;          // callback public
    private ColorAdjustments    colorAdjustments;
    private float               _currentSat;
    private float               _targetSat;
    #endregion

    #region === Unity ===
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        // — Post‑process (on clone le profil) —
        postProcess.profile = Instantiate(postProcess.profile);

        if (postProcess.profile.TryGet(out ColorAdjustments ca))
        {
            colorAdjustments = ca;
            colorAdjustments.saturation.overrideState = true;
        }
        else
        {
            Debug.LogError("[EnvironmentManager] ColorAdjustments introuvable !");
        }

        // — Mise en cache des groupes —
        foreach (var g in groups) g.CacheTaggedObjects();

        ApplyHealthImmediate(); // Apply initial value

        PollutionManager.Instance.onCurrencyChanged.AddListener(UpdateEnvironmentHealth);
    }

    void Update()
    {
        // 1) Post‑process ► interpolation fluide
        _targetSat   = saturationCurve.Evaluate(environmentHealth);
        _currentSat  = Mathf.Lerp(_currentSat, _targetSat, Time.deltaTime * lerpSpeed);
        colorAdjustments.saturation.value = _currentSat;
    }
    #endregion

    #region === Public API ===
    /// <summary> Ajoute (ou retire) de la santé à l’environnement. </summary>
    public void AdjustEnvironment(float delta) => SetEnvironmentHealth(environmentHealth + delta);

    /// <summary> Définit directement la santé (‑1…1). </summary>
    public void SetEnvironmentHealth(float value)
    {
        value = Mathf.Clamp(value, -1f, 1f);
        if (Mathf.Abs(value - environmentHealth) > 0.001f)
        {
            environmentHealth = value;
            ApplyHealthImmediate();
            OnHealthChanged?.Invoke(environmentHealth);
        }
    }

    #endregion

    #region === Core Logic ===
    private void ApplyHealthImmediate()
    {
        // — Activer / désactiver chaque groupe selon ses seuils —
        foreach (var g in groups) g.Apply(environmentHealth);

        // — Forcer le post‑process sans lerp pour le 1er frame —
        _currentSat = _targetSat = saturationCurve.Evaluate(environmentHealth);
        if (colorAdjustments != null)
            colorAdjustments.saturation.value = _currentSat;
    }
    #endregion

    /****************************************************
     *                    STRUCTS
     ****************************************************/
    [Serializable]
    public struct ElementGroup
    {
        [Tooltip("Tag associé (Tree, Butterfly, …)")] public string tag;
        [Tooltip("Health >= seuil → éléments activés")] public float enableThreshold;
        [Tooltip("Health <= seuilOff → éléments désactivés (optionnel)")]
        public float disableThreshold;
        [Space(3)]
        [Tooltip("Interdire le double FindGameObjectsWithTag")]
        [NonSerialized] private List<GameObject> cache;

        // — Mise en cache au Start —
        public void CacheTaggedObjects()
        {
            if (string.IsNullOrEmpty(tag)) return;
            cache = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));
        }

        // — Permet d’enregistrer un GO arrivé après le Start (ex : spawn) —
        public void Register(GameObject go)
        {
            if (cache == null) cache = new List<GameObject>();
            if (!cache.Contains(go)) cache.Add(go);
        }

        // — Application de la logique seuil —
        public void Apply(float health)
        {
            if (cache == null) return;

            bool shouldEnable = health >= enableThreshold;
            bool shouldDisable = health <= disableThreshold;

            foreach (var obj in cache)
            {
                if (obj == null) continue;

                bool targetState = obj.activeSelf;

                if (shouldEnable)  targetState = true;
                if (shouldDisable) targetState = false;

                if (obj.activeSelf != targetState) obj.SetActive(targetState);
            }
        }
    }

    private void UpdateEnvironmentHealth(float currentPollution)
    {
        // currentPollution est entre 0 et 100
        float normalizedRatio = (1f - (currentPollution / 100f)) * 2f - 1f; // Donne un résultat entre -1 et 1
        normalizedRatio = Mathf.Clamp(normalizedRatio, -1f, 1f);

        SetEnvironmentHealth(normalizedRatio);
    }
}
