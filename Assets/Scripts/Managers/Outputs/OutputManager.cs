using System.Collections.Generic;
using Enum;
using Managers.Buildings;
using Managers.Meta;
using Managers.Outputs.Building;
using Managers.Outputs.MetaResource;
using Managers.Outputs.MouseOver;
using Managers.Outputs.Resource;
using Managers.Resources;
using UnityEngine;

namespace Managers.Outputs
{
    public class OutputManager : MonoBehaviour, IManager
    {
        public static OutputManager ThisManager;

        private readonly Dictionary<ResourceEnum, GameObject> _resourceDictionary =
            new Dictionary<ResourceEnum, GameObject>();

        private readonly Dictionary<MetaResourceEnum, GameObject> _metaResourceDictionary =
            new Dictionary<MetaResourceEnum, GameObject>();

        private readonly Dictionary<BuildingEnum, GameObject> _buildingDictionary =
            new Dictionary<BuildingEnum, GameObject>();

        private GameObject _mouseOver;

        public BuildingEnum BuildingEnum;

        public void Advance(float speed)
        {
            UpdatedMetaResources();
            UpdatedResources();
            UpdateBuildings();
        }

       

        private void UpdateBuildings()
        {
            var infos = BuildingManager.ThisManager.GetBuildingInfo();
            foreach (var info in infos)
            {
                if (!_buildingDictionary.ContainsKey(info.BuildingEnum))
                {
                    continue;
                }

                var singularResourceScript = _buildingDictionary[info.BuildingEnum]
                    .GetComponent<BaseBuildingDisplayScript>();
                singularResourceScript.SetValues(info);
            }
        }

        private void UpdatedMetaResources()
        {
            var productionresourceDisplayInfos = ResourceManager.ThisManager
                .GetProductionResourceDisplayInfos();
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

        private void UpdatedResources()
        {
            var resourceDisplayInfos = ResourceManager.ThisManager
                .GetResourceDisplayInfos();
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

        public void SetMouseOver(BuildingEnum buildingEnum)
        {
            if (_mouseOver == null)
            {
                return;
            }
            _mouseOver.GetComponent<MouseOverBaseDisplay>()
                .SetInfo(BuildingManager.ThisManager.GetBuildingInfo(BuildingEnum));
        }

        public void ResourceRegistration(ResourceEnum resourceEnum, GameObject registrationGameObject)
        {
            _resourceDictionary.Add(resourceEnum, registrationGameObject);
        }

        public void MetaResourceRegistration(MetaResourceEnum metaresourceEnum, GameObject registrationGameObject)
        {
            _metaResourceDictionary.Add(metaresourceEnum, registrationGameObject);
        }

        public void BuildingRegistration(BuildingEnum buildingEnum, GameObject registrationGameObject)
        {
            _buildingDictionary.Add(buildingEnum, registrationGameObject);
        }

        public void MouseOverRegistration(GameObject o)
        {
            _mouseOver = o;
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