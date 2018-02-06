using System.Collections.Generic;
using Enum;

namespace Buildings
{
    public class StorageBuilding : BaseBuilding
    {
        public MetaResourceEnum MetaResourceEnum { get; protected set; }
        public ResourceType ResourceType { get; protected set; }

        public static readonly StorageBuilding BasketYard = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceType = ResourceType.Resource,

            Name = "Basket Yard",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly StorageBuilding StorageYard = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceType = ResourceType.Resource,

            Name = "Storage Yard",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly StorageBuilding Granary = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceType = ResourceType.MetaResource,

            Name = "Granary",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };

        public static readonly StorageBuilding StoragePit = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceType = ResourceType.MetaResource,

            Name = "Storage Pit",
            BaseRate = 1,
            BaseCost = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, 50},
                {MetaResourceEnum.Production, 100}
            },
            CostIncrease = new Dictionary<MetaResourceEnum, double>
            {
                {MetaResourceEnum.Food, .2},
                {MetaResourceEnum.Production, .3}
            }
        };
    }
}