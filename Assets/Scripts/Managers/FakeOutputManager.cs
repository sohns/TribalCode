using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Enum;
using Managers.Outputs;
using UnityEngine;

public class FakeOutputManager : MonoBehaviour
{
    public static FakeOutputManager OutputManager;
    public static FakeOutputManager MetaOutputManager;

    public GameObject ResourceDisplay, MetaResourceDisplay;
    public GameObject ResourceDisplayPrefab, MetaResourceDisplayPrefab;

    public void GenerateResource(List<ResourceDisplayInfo> resourceDisplayInfos)
    {
        /*CleanObject<BaseResourceDisplayPrefabScript>(ResourceDisplay);
        foreach (var resourceDisplayInfo in resourceDisplayInfos)
        {
            var clone = CreateObject(ResourceDisplayPrefab, ResourceDisplay);
            var script = clone.GetComponent<BaseResourceDisplayPrefabScript>();
            script.SetValues(resourceDisplayInfo);
        }*/
    }

    public void GenerateMetaResource(List<ProductionResourceDisplayInfo> productionresourceDisplayInfos)
    {
        /*CleanObject<MetaResourceDisplayPrefabScript>(MetaResourceDisplay);
        foreach (var productionresourceDisplayInfo in productionresourceDisplayInfos)
        {
            var clone = CreateObject(MetaResourceDisplayPrefab, MetaResourceDisplay);
            var script = clone.GetComponent<MetaResourceDisplayPrefabScript>();
            script.SetValues(productionresourceDisplayInfo);
        }*/
    }

    // Use this for initialization
    void Awake()
    {
        OutputManager = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private GameObject CreateObject(GameObject prefab, GameObject parent)
    {
        var clone = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        clone.transform.SetParent(parent.transform);
        return clone;
    }

    private void CleanObject<T>(GameObject parent)
    {
        var toDestroy = (from Transform childTransform in parent.transform
            where childTransform.GetComponent<T>() != null
            select childTransform.gameObject).ToList();
        foreach (var objectToDestroy in toDestroy)
        {
            Destroy(objectToDestroy);
        }
    }

    public void DisplayAdvance(List<ResourceDisplayInfo> resourceDisplayInfos,
        List<ProductionResourceDisplayInfo> productionResourceDisplayInfos)
    {
        var resourceMap =
            resourceDisplayInfos.ToDictionary(resourceDisplayInfo => resourceDisplayInfo.ResourceEnum);
        foreach (Transform childTransform in ResourceDisplay.transform)
        {
            var script = childTransform.GetComponent<ResourceDisplayScript>();
            //TODO:script.SetValues(resourceMap[script.ResourceEnum]);
        }


        var metaResourceMap =
            productionResourceDisplayInfos.ToDictionary(resourceDisplayInfo => resourceDisplayInfo.MetaResourceEnum);
        foreach (Transform childTransform in MetaResourceDisplay.transform)
        {
            var script = childTransform.GetComponent<ProductionResourceDisplayScript>();
            //TODO:script.SetValues(metaResourceMap[script.MetaResourceEnum]);
        }
    }
}