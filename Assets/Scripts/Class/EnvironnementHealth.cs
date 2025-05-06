using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EnvironmentManager : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float environmentHealth = 0f;

    public Volume postProcess;
    public AnimationCurve saturationCurve;

    private ColorAdjustments colorAdjustments;

    void Start()
    {
        postProcess.profile = Instantiate(postProcess.profile);

        if (postProcess.profile.TryGet(out ColorAdjustments colorAdj))
        {
            colorAdjustments = colorAdj;

            colorAdjustments.saturation.overrideState = true;
        }
        else
        {
            Debug.LogError("Color Adjustments not found in Volume Profile!");
        }
    }

    void Update()
    {
        if (colorAdjustments != null)
        {
            float satValue = saturationCurve.Evaluate(environmentHealth);
            colorAdjustments.saturation.value = satValue;
        }
    }

    public void AdjustEnvironment(float delta)
    {
        environmentHealth = Mathf.Clamp(environmentHealth + delta, -1f, 1f);
    }
}