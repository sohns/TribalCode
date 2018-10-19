using System;
using System.Collections.Generic;
using System.Linq;
using Enum;
using Managers.Meta;
using Managers.Outputs;
using UnityEngine;
using Util;
using Random = UnityEngine.Random;

namespace Managers.Resources
{
    public class ResourceManager : IManager
    {
        //TODO define Hash
        private Dictionary<String, ResourceInfo> Resources { get; set; }

        public SaveInfo Save(SaveInfo saveInfo)
        {
            return saveInfo;
        }

        public void Load(SaveInfo saveInfo)
        {
            //TODO: Load this from save
            temp(MetaResourceEnum.Food);
            temp(MetaResourceEnum.Production);
            temp(MetaResourceEnum.Population);

            temp(ResourceEnum.Fish);
            temp(ResourceEnum.Meat);
            temp(ResourceEnum.Berry);
            temp(ResourceEnum.Wood);
            temp(ResourceEnum.Stone);
            temp(ResourceEnum.Clay);
        }

        private void temp(MetaResourceEnum temp)
        {
            var resourceInfo = new ResourceInfo(temp, 0, 100, 0, Random.value);
            Resources.Add(temp.ToString(), resourceInfo);
        }

        private void temp(ResourceEnum temp)
        {
            var resourceInfo = new ResourceInfo(temp, 0, 100, 0, Random.value);
            Resources.Add(temp.ToString(), resourceInfo);
        }

        public void InitialSetup()
        {
            Resources = new Dictionary<string, ResourceInfo>();
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