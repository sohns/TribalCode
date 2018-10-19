using System;
using System.Collections.Generic;
using System.Linq;
using Enum;
using Managers.Meta;
using Managers.Outputs;
using UnityEngine;

namespace Managers.Resources
{
    public class ResourceManager : MonoBehaviour, IManager
    {
        public static ResourceManager ThisManager;

        //TODO define Hash
        private Dictionary<String, ResourceInfo> Resources { get; set; }

        public SaveInfo Save(SaveInfo saveInfo)
        {
            return saveInfo;
        }

        public void Load(SaveInfo saveInfo)
        {
            Resources = new Dictionary<string, ResourceInfo>();
            foreach (var info in saveInfo.ResourcesCount)
            {
                var resourceInfo = new ResourceInfo(info.Key, info.Value, 100, 0, saveInfo.ResourcesRate[info.Key]);
                Resources.Add(info.Key.ToString(), resourceInfo);
            }
            foreach (var info in saveInfo.MetaResourcesCount)
            {
                var resourceInfo = new ResourceInfo(info.Key, info.Value, 100, 0, saveInfo.MetaResourcesRate[info.Key]);
                Resources.Add(info.Key.ToString(), resourceInfo);
            }
        }

        public void InitialSetup()
        {
            ThisManager = this;
        }

        public void PostLoad()
        {
            
        }


        public void Advance(float speed)
        {
            foreach (var resource in Resources)
            {
                resource.Value.Advance(speed);
            }
        }

        public List<ResourceDisplayInfo> GetResourceDisplayInfos()
        {
            return (from resource in Resources
                where resource.Value.ResourceEnum != ResourceEnum.None
                select new ResourceDisplayInfo
                {
                    Change = String.Format("{0:F2}", resource.Value.ChangeValue.ThisNumber),
                    Name = resource.Value.ResourceEnum.ToString(),
                    Value = String.Format("{0:F2}", resource.Value.Value.ThisNumber),
                    ResourceEnum = resource.Value.ResourceEnum
                }).ToList();
        }

        public List<MetaResourceDisplayInfo> GetProductionResourceDisplayInfos()
        {
            return (from resource in Resources
                where resource.Value.MetaResourceEnum != MetaResourceEnum.None
                      && resource.Value.MetaResourceEnum != MetaResourceEnum.Population
                select new MetaResourceDisplayInfo
                {
                    Change = String.Format("{0:F2}", resource.Value.ChangeValue.ThisNumber),
                    Name = resource.Value.MetaResourceEnum.ToString(),
                    Value = String.Format("{0:F2}", resource.Value.Value.ThisNumber),
                    MetaResourceEnum = resource.Value.MetaResourceEnum
                }).ToList();
        }
    }
}