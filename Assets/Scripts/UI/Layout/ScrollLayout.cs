using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Unity.Cinemachine.CinemachineSplineRoll;

public class ScrollLayout : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] ScrollSlotLayout scrollSlotLayout;
    [SerializeField] List<UpgradesObjectsData> allData;
    [SerializeField] bool isEcoScroll;

    public void Init()
    {
        var filteredData = allData
            .Where(data => data.isEco == isEcoScroll)
            .OrderBy(data => data.basePrice);

        foreach (UpgradesObjectsData data in filteredData)
        {
            var currentLayout = Instantiate(scrollSlotLayout, content.transform);
            currentLayout.Init(data);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Load All Data")]
    public void LoadAllResourcesInEditor()
    {
        allData = AssetDatabase.FindAssets("t:UpgradesObjectsData")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<UpgradesObjectsData>)
            .ToList();

        EditorUtility.SetDirty(this);
    }
#endif
}
