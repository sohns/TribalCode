using System.Collections.Generic;
using Enum;
using Util;

namespace Managers.Buildings
{
    public class Converter : BaseBuilding
    {
        public MetaResourceEnum MetaResourceEnum { get; private set; }
        public ResourceEnum ResourceEnum { get; private set; }

        public Converter()
        {
            BuildingType = BuildingType.Converter;
        }

        //Define them
        public static readonly Converter SmokeHut = new Converter
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Fish,

            Name = "Smoke Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
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
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
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
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
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
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
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
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
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
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };
    }
}