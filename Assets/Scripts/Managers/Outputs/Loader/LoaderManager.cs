using System;
using System.Collections.Generic;
using CustomClasses;
using Enum;
using Managers.Meta;
using Random = UnityEngine.Random;

namespace Managers.Outputs.Loader
{
    public class LoaderManager
    {
        public static SaveInfo GetSave(LoaderEnum loaderEnum)
        {
            var saveInfo = new SaveInfo();
            switch (loaderEnum)
            {
                case LoaderEnum.FakeInfo:

                    var resourcesCount = new Dictionary<ResourceEnum, AdvancedNumber>();
                    var resourcesRate = new Dictionary<ResourceEnum, AdvancedNumber>();
                    var metaResourcesCount = new Dictionary<MetaResourceEnum, AdvancedNumber>();
                    var metaResourcesRate = new Dictionary<MetaResourceEnum, AdvancedNumber>();

                    SetFakeData<MetaResourceEnum, Dictionary<MetaResourceEnum, AdvancedNumber>,
                        Dictionary<MetaResourceEnum, AdvancedNumber>>(TempMeta, metaResourcesCount, metaResourcesRate);

                    SetFakeData<ResourceEnum, Dictionary<ResourceEnum, AdvancedNumber>,
                        Dictionary<ResourceEnum, AdvancedNumber>>(TempResource, resourcesCount, resourcesRate);


                    var building = new Dictionary<BuildingEnum, AdvancedNumber>();
                    var useless = new Dictionary<BuildingEnum, AdvancedNumber>();

                    SetFakeData<BuildingEnum, Dictionary<BuildingEnum, AdvancedNumber>,
                        Dictionary<BuildingEnum, AdvancedNumber>>(TempBuilding, building, useless);

                    saveInfo.Buildings = building;
                    saveInfo.ResourcesCount = resourcesCount;
                    saveInfo.ResourcesRate = resourcesRate;
                    saveInfo.MetaResourcesCount = metaResourcesCount;
                    saveInfo.MetaResourcesRate = metaResourcesRate;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("loaderEnum", loaderEnum, null);
            }
            return saveInfo;
        }

        private static void SetFakeData<TP, TS, TQ>(Action<TP, TS, TQ> action, TS s, TQ q)
        {
            foreach (var aEnum in (TP[]) System.Enum.GetValues(typeof(TP)))
            {
                action(aEnum, s, q);
            }
        }

        private static void TempBuilding<T>(BuildingEnum temp, T count, T useless)
            where T : Dictionary<BuildingEnum, AdvancedNumber>
        {
            count.Add(temp, 1);
        }

        private static void TempMeta<T>(MetaResourceEnum temp, T count, T rate)
            where T : Dictionary<MetaResourceEnum, AdvancedNumber>
        {
            if (temp == MetaResourceEnum.None)
            {
                return;
            }
            count.Add(temp, 0);
            rate.Add(temp, Random.value);
        }

        private static void TempResource<T>(ResourceEnum temp, T count, T rate)
            where T : Dictionary<ResourceEnum, AdvancedNumber>
        {
            if (temp == ResourceEnum.None)
            {
                return;
            }
            count.Add(temp, 0);
            rate.Add(temp, Random.value);
        }
    }
}