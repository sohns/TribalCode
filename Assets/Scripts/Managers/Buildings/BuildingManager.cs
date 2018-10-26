using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using CustomClasses;
using Enum;
using Managers.Meta;
using Managers.Outputs.Building;
using Managers.Outputs.MetaResource;
using Managers.Resources;
using UnityEngine;

namespace Managers.Buildings
{
    public class BuildingManager : MonoBehaviour, IManager
    {
        public static BuildingManager ThisManager;
        private Dictionary<BuildingType, List<BaseBuilding>> _buildings;
        private Dictionary<BuildingEnum, BaseBuilding> _buildingsByEnum;
        private Stack<BuildingEnum> _toBuild = new Stack<BuildingEnum>();

        public BaseBuilding GetBuildingInfo(BuildingEnum buildingEnum)
        {
            return _buildingsByEnum[buildingEnum];
        }

        public SaveInfo Save(SaveInfo saveInfo)
        {
            return saveInfo;
        }

        public void Load(SaveInfo saveInfo)
        {
            _buildingsByEnum = new Dictionary<BuildingEnum, BaseBuilding>();
            foreach (var saveInfoBuilding in saveInfo.Buildings)
            {
                BaseBuilding baseBuilding;
                switch (saveInfoBuilding.Key)
                {
                    case BuildingEnum.BasketYard:
                        baseBuilding = StorageBuilding.BasketYard;
                        break;
                    case BuildingEnum.StorageYard:
                        baseBuilding = StorageBuilding.StorageYard;
                        break;
                    case BuildingEnum.Granary:
                        baseBuilding = StorageBuilding.Granary;
                        break;
                    case BuildingEnum.StoragePit:
                        baseBuilding = StorageBuilding.StoragePit;
                        break;
                    case BuildingEnum.SmokeHut:
                        baseBuilding = ConverterBuilding.SmokeHut;
                        break;
                    case BuildingEnum.ButcherHut:
                        baseBuilding = ConverterBuilding.ButcherHut;
                        break;
                    case BuildingEnum.JuiceHut:
                        baseBuilding = ConverterBuilding.JuiceHut;
                        break;
                    case BuildingEnum.LumberHut:
                        baseBuilding = ConverterBuilding.LumberHut;
                        break;
                    case BuildingEnum.MasonHut:
                        baseBuilding = ConverterBuilding.MasonHut;
                        break;
                    case BuildingEnum.KilnHut:
                        baseBuilding = ConverterBuilding.KilnHut;
                        break;
                    case BuildingEnum.Fishery:
                        baseBuilding = PopulationAssignmentBuildings.Fishery;
                        break;
                    case BuildingEnum.HuntingLodge:
                        baseBuilding = PopulationAssignmentBuildings.HuntingLodge;
                        break;
                    case BuildingEnum.GatheringHut:
                        baseBuilding = PopulationAssignmentBuildings.GatheringHut;
                        break;
                    case BuildingEnum.LumberCamp:
                        baseBuilding = PopulationAssignmentBuildings.LumberCamp;
                        break;
                    case BuildingEnum.Quarry:
                        baseBuilding = PopulationAssignmentBuildings.Quarry;
                        break;
                    case BuildingEnum.ClayPit:
                        baseBuilding = PopulationAssignmentBuildings.ClayPit;
                        break;
                    case BuildingEnum.TownCenter:
                        baseBuilding = TownCenterBuilding.TownCenter;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (baseBuilding.BuildingType == BuildingType.PopulationAssignment)
                {
                    ((PopulationAssignmentBuildings) baseBuilding).SetLevels(saveInfoBuilding.Value, 0);
                }
                else
                {
                    baseBuilding.SetLevels(saveInfoBuilding.Value);
                }

                _buildingsByEnum.Add(saveInfoBuilding.Key, baseBuilding);
            }
            _buildings = new Dictionary<BuildingType, List<BaseBuilding>>();
            foreach (var aEnum in (BuildingType[]) System.Enum.GetValues(typeof(BuildingType)))
            {
                _buildings.Add(aEnum, new List<BaseBuilding>());
            }
            foreach (var simpleBuilding in _buildingsByEnum)
            {
                _buildings[simpleBuilding.Value.BuildingType].Add(simpleBuilding.Value);
            }
        }

        public void Advance(float speed)
        {
            //TODO: More then one at a time
            if (_toBuild.Count > 0)
            {
                var typeToBuild = _toBuild.Pop();
                var building = _buildingsByEnum[typeToBuild];
                if (!building.BuyNextLevel())
                {
                    //_toBuild.Push(typeToBuild);
                }
                else
                {
                    _buildingsByEnum[typeToBuild] = building;
                }
            }
            var resources = ResourceManager.ThisManager.Resources;
            var metaResources = ResourceManager.ThisManager.MetaResources;
            var resourcesRate = new Dictionary<ResourceEnum, AdvancedNumber>();
            var metaResourcesRate = new Dictionary<MetaResourceEnum, AdvancedNumber>();
            foreach (var info in _buildings[BuildingType.PopulationAssignment])
            {
                var building = (PopulationAssignmentBuildings) info;
                //TODO:Assign population...
                building.AddPopulation(1);
                var rate = building.CurrentRate;
                resourcesRate = UpdateDictionary(resourcesRate, building.ResourceEnum, rate);
            }
            foreach (var info in _buildings[BuildingType.Converter])
            {
                var building = (ConverterBuilding) info;
                var rate = building.CurrentRate;
                if (resourcesRate[building.ResourceEnum] < 0)
                {
                    continue;
                }

                if (resourcesRate[building.ResourceEnum] < rate)
                {
                    var newCover = AdvancedMath.Min(resources[building.ResourceEnum].Value / speed,
                        rate - resourcesRate[building.ResourceEnum]);
                    rate = newCover + resourcesRate[building.ResourceEnum];
                }
                resourcesRate = UpdateDictionary(resourcesRate, building.ResourceEnum, -rate);
                metaResourcesRate = UpdateDictionary(metaResourcesRate, building.MetaResourceEnum, rate);
            }
            foreach (var info in _buildings[BuildingType.Storage])
            {
                var building = (StorageBuilding) info;
                switch (building.ResourceType)
                {
                    case ResourceType.MetaResource:
                        metaResources[building.MetaResourceEnum].MaxValue = building.CurrentStorage;
                        break;
                    case ResourceType.Resource:
                        foreach (var resourceEnum in EnumUtils.GetResourceEnums(building.MetaResourceEnum))
                        {
                            resources[resourceEnum].MaxValue = building.CurrentStorage;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var info in resourcesRate)
            {
                resources[info.Key].ChangeValue = info.Value;
            }
            foreach (var info in metaResourcesRate)
            {
                metaResources[info.Key].ChangeValue = info.Value;
            }
            ResourceManager.ThisManager.Resources = resources;
            ResourceManager.ThisManager.MetaResources = metaResources;
        }

        public void AddBuilding(BuildingEnum buildingToAdd)
        {
            _toBuild.Push(buildingToAdd);
        }

        private T UpdateDictionary<T, TA>(T dictionary, TA key, AdvancedNumber updateValue)
            where T : Dictionary<TA, AdvancedNumber>
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, 0);
            }
            dictionary[key] += updateValue;
            return dictionary;
        }

        public void InitialSetup()
        {
            ThisManager = this;
        }

        public void PostLoad()
        {
        }

        public List<BaseBuildingDisplayInfo> GetBuildingInfo()
        {
            return (from info in _buildingsByEnum
                let building = info.Value
                select new BaseBuildingDisplayInfo
                {
                    Level = building.Level.ToString(),
                    Name = building.Name,
                    BuildingEnum = info.Key,
                    BuildingType = building.BuildingType
                }).ToList();
        }
    }
}