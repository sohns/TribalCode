using System.Collections.Generic;
using CustomClasses;
using Enum;

namespace Managers.Buildings
{
    public class ConverterBuilding : BaseBuilding
    {
        public MetaResourceEnum MetaResourceEnum { get; private set; }
        public ResourceEnum ResourceEnum { get; private set; }

        public ConverterBuilding()
        {
            BuildingType = BuildingType.Converter;
        }
        
        //Define them
        public static readonly ConverterBuilding SmokeHut = new ConverterBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Fish,

            Name = "Smoke Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly ConverterBuilding ButcherHut = new ConverterBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Meat,

            Name = "Butcher Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly ConverterBuilding JuiceHut = new ConverterBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceEnum = ResourceEnum.Berry,

            Name = "Juice Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly ConverterBuilding LumberHut = new ConverterBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceEnum = ResourceEnum.Wood,

            Name = "Lumber Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly ConverterBuilding MasonHut = new ConverterBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceEnum = ResourceEnum.Stone,

            Name = "Mason Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly ConverterBuilding KilnHut = new ConverterBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceEnum = ResourceEnum.Clay,

            Name = "Kiln Hut",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, AdvancedNumber>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };
    }
}