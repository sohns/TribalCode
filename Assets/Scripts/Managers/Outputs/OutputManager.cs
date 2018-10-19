using UnityEngine;
using Enum;
using System.Collections.Generic;
using Managers.Meta;
using Managers.Outputs;

namespace Managers
{
    public class OutputManager : MonoBehaviour, IManager
    {
        public static OutputManager ThisManager;

        private Dictionary<ResourceEnum, GameObject> _resourceDictionary = new Dictionary<ResourceEnum, GameObject>();
        private Dictionary<MetaResourceEnum, GameObject> _metaResourceDictionary = new Dictionary<MetaResourceEnum, GameObject>();

        public void UpdatedMetaResources(List<MetaResourceDisplayInfo> productionresourceDisplayInfos)
        {
            foreach (var productionresourceDisplayInfo in productionresourceDisplayInfos)
            {
                if (!_metaResourceDictionary.ContainsKey(productionresourceDisplayInfo.MetaResourceEnum))
                {
                    continue;
                }

                var singularResourceScript = _metaResourceDictionary[productionresourceDisplayInfo.MetaResourceEnum]
                    .GetComponent<MetaResourceDisplayScript>();
                singularResourceScript.SetValues(productionresourceDisplayInfo);
            }
        }

        public void UpdatedResources(List<ResourceDisplayInfo> resourceDisplayInfos)
        {
            foreach (var resourceDisplayInfo in resourceDisplayInfos)
            {
                if (!_resourceDictionary.ContainsKey(resourceDisplayInfo.ResourceEnum))
                {
                    continue;
                }

                var singularResourceScript = _resourceDictionary[resourceDisplayInfo.ResourceEnum]
                    .GetComponent<ResourceDisplayScript>();
                singularResourceScript.SetValues(resourceDisplayInfo);
            }
        }

        public void ResourceRegistration(ResourceEnum resourceEnum, GameObject registrationGameObject)
        {
            _resourceDictionary.Add(resourceEnum, registrationGameObject);
        }
        
        public void MetaResourceRegistration(MetaResourceEnum metaresourceEnum, GameObject registrationGameObject)
        {
            _metaResourceDictionary.Add(metaresourceEnum, registrationGameObject);
        }

        public SaveInfo Save(SaveInfo saveInfo)
        {
            return saveInfo;
        }

        public void Load(SaveInfo saveInfo)
        {
        }

        public void InitialSetup()
        {
            ThisManager = this;
        }

        public void PostLoad()
        {
            
        }
    }
}