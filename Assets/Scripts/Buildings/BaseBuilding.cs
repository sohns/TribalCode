using System.Collections.Generic;
using Enum;

namespace Buildings
{
    public class BaseBuilding
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }
        public double BaseRate { get; protected set; }
        public double CurrentRate { get; protected set; }
        public Dictionary<MetaResourceEnum, double> BaseCost { get; protected set; }
        public Dictionary<MetaResourceEnum, double> CostIncrease { get; protected set; }
        public Dictionary<MetaResourceEnum, double> CurrentCost { get; protected set; }

        public virtual void SetLevels(int level)
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

        public virtual bool BuyNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts)
        {
            foreach (var costInfo in CurrentCost)
            {
                if (!currentAmounts.ContainsKey(costInfo.Key))
                {
                    return false;
                }
                if (currentAmounts[costInfo.Key] < costInfo.Value)
                {
                    return false;
                }
            }
            PayForNextLevel(ref currentAmounts);
            UpdateRate();
            UpdateCost();
            return true;
        }

        protected virtual void PayForNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts)
        {
            foreach (var costInfo in CurrentCost)
            {
                currentAmounts[costInfo.Key] -= costInfo.Value;
            }
        }

        protected virtual void UpdateRate()
        {
            CurrentRate = Level * BaseRate;
        }

        protected virtual void UpdateCost()
        {
            foreach (var costKey in CurrentCost.Keys)
            {
                CurrentCost[costKey] *= 1 + CostIncrease[costKey];
            }
        }
    }
}