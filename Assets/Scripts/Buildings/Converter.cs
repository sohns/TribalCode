using System.Collections.Generic;
using Enum;

namespace Buildings
{
    public class Converter : IBuilding
    {
        public MetaResourceEnum MetaResourceEnum { get; private set; }
        public ResourceEnum ResourceEnum { get; private set; }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public double BaseRate { get; private set; }
        public double CurrentRate { get; private set; }
        public Dictionary<MetaResourceEnum, double> BaseCost { get; private set; }
        public Dictionary<MetaResourceEnum, double> CostIncrease { get; private set; }
        public Dictionary<MetaResourceEnum, double> CurrentCost { get; private set; }


        public void SetLevels(int level)
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

        public bool BuyNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts)
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

        public void PayForNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts)
        {
            foreach (var costInfo in CurrentCost)
            {
                currentAmounts[costInfo.Key] -= costInfo.Value;
            }
        }

        public void UpdateRate()
        {
            CurrentRate = Level * BaseRate;
        }

        public void UpdateCost()
        {
            foreach (var costKey in CurrentCost.Keys)
            {
                CurrentCost[costKey] *= 1 + CostIncrease[costKey];
            }
        }

        //Define them
        public static readonly Converter SmokeHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Fish,

            Name = "Smoke Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CurrentCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly Converter ButcherHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Meat,

            Name = "Butcher Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CurrentCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly Converter JuiceHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Berry,

            Name = "Juice Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CurrentCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly Converter LumberHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceEnum = ResourceEnum.Wood,

            Name = "Lumber Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CurrentCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly Converter MasonHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceEnum = ResourceEnum.Stone,

            Name = "Mason Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CurrentCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly Converter KilnHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceEnum = ResourceEnum.Clay,

            Name = "Kiln Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CurrentCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };
    }
}