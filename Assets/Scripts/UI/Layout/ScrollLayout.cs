using NUnit.Framework;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Unity.Cinemachine.CinemachineSplineRoll;

public class ScrollLayout : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] ScrollSlotLayout scrollSlotLayout;
    //[SerializeField] List<Data> allData;
    public void Init()
    {
        //foreach (Data data in allData)
        //{
        //    var currentLayout = Instantiate(scrollSlotLayout, content.transform);
        //    currentLayout.Init();
        //}
    }

    //#if UNITY_EDITOR
    //    [ContextMenu("Load All Data")]
    //    public void LoadAllResourcesInEditor()
    //    {
    //        allData = AssetDatabase.FindAssets("t:ErrorData")
    //            .Select(AssetDatabase.GUIDToAssetPath)
    //            .Select(AssetDatabase.LoadAssetAtPath<ErrorData>)
    //            .ToList();

    //        EditorUtility.SetDirty(this);
    //    }
    //#endif
}
