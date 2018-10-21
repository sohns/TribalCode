using System;
using System.Collections.Generic;
using System.Linq;
using Enum;
using Managers.Meta;
using Managers.Outputs.MetaResource;
using Managers.Outputs.Resource;
using UnityEngine;

namespace Managers.Resources
{
    public class ResourceManager : MonoBehaviour, IManager
    {
        public static ResourceManager ThisManager;

        //TODO define Hash
        public Dictionary<ResourceEnum, ResourceInfo> Resources { get; set; }
        public Dictionary<MetaResourceEnum, ResourceInfo> MetaResources { get; set; }

        public SaveInfo Save(SaveInfo saveInfo)
        {
            return saveInfo;
        }

        public void Load(SaveInfo saveInfo)
        {
            Resources = new Dictionary<ResourceEnum, ResourceInfo>();
            MetaResources = new Dictionary<MetaResourceEnum, ResourceInfo>();
            foreach (var info in saveInfo.ResourcesCount)
            {
                var resourceInfo = new ResourceInfo(info.Key, info.Value, 100, 0, saveInfo.ResourcesRate[info.Key]);
                Resources.Add(info.Key, resourceInfo);
            }
            foreach (var info in saveInfo.MetaResourcesCount)
            {
                var resourceInfo = new ResourceInfo(info.Key, info.Value, 100, 0, saveInfo.MetaResourcesRate[info.Key]);
                MetaResources.Add(info.Key, resourceInfo);
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
            foreach (var resource in MetaResources)
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
            return (from resource in MetaResources
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