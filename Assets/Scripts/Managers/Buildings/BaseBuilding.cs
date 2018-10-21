using System.Collections.Generic;
using CustomClasses;
using Enum;
using Managers.Resources;
using UnityEngine;

namespace Managers.Buildings
{
    public class BaseBuilding
    {
        public string Name { get; protected set; }
        public AdvancedNumber Level { get; protected set; }
        public AdvancedNumber BaseRate { get; protected set; }
        public AdvancedNumber CurrentRate { get; protected set; }
        public BuildingType BuildingType { get; protected set; }
        public Dictionary<MetaResourceEnum, AdvancedNumber> BaseCost { get; protected set; }
        public Dictionary<MetaResourceEnum, AdvancedNumber> CostIncrease { get; protected set; }
        public Dictionary<MetaResourceEnum, AdvancedNumber> CurrentCost { get; protected set; }

        public virtual void SetLevels(AdvancedNumber level)
        {
            Level = level;
            CurrentRate = BaseRate;
            CurrentCost = BaseCost;
            //Level -1 because first level is just base
            for (var count = 0; count < level - 1; count++)
            {
                UpdateCost();
            }
            UpdateRate();
        }

        public virtual bool BuyNextLevel()
        {
            var currentAmounts = ResourceManager.ThisManager.MetaResources;
            foreach (var costInfo in CurrentCost)
            {
                if (!currentAmounts.ContainsKey(costInfo.Key))
                {
                    return false;
                }
                if (currentAmounts[costInfo.Key].Value < costInfo.Value)
                {
                    return false;
                }
            }
            foreach (var costInfo in CurrentCost)
            {
                currentAmounts[costInfo.Key].Pay(costInfo.Value);
            }
            UpdateRate();
            UpdateCost();
            Level++;
            ResourceManager.ThisManager.MetaResources = currentAmounts;
            return true;
        }

        protected virtual void PayForNextLevel(ref Dictionary<MetaResourceEnum, AdvancedNumber> currentAmounts)
        {
        }

        protected virtual void UpdateRate()
        {
            CurrentRate = Level * BaseRate;
        }

        protected virtual void UpdateCost()
        {
            var keys = new List<MetaResourceEnum>(CurrentCost.Keys);
            foreach (var costKey in keys)
            {
                CurrentCost[costKey] *= 1 + CostIncrease[costKey];
            }
        }
    }
}