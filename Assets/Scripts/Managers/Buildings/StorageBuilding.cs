using System;
using System.Collections.Generic;
using CustomClasses;
using Enum;
using UnityEngine;

namespace Managers.Buildings
{
    public class StorageBuilding : BaseBuilding
    {
        public MetaResourceEnum MetaResourceEnum { get; protected set; }
        public ResourceType ResourceType { get; protected set; }
        public AdvancedNumber BaseStorage { get; protected set; }
        public AdvancedNumber CurrentStorage { get; protected set; }

        public StorageBuilding()
        {
            BuildingType = BuildingType.Storage;
        }

        public override void SetLevels(AdvancedNumber level)
        {
            base.SetLevels(level);
            CurrentStorage = BaseStorage * level;
        }

        public override bool BuyNextLevel()
        {
            if (base.BuyNextLevel())
            {
                CurrentStorage = BaseStorage * Level;
                return true;
            }
            return false;
        }

        public static readonly StorageBuilding BasketYard = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceType = ResourceType.Resource,

            Name = "Basket Yard",
            BaseRate = 1,
            BaseStorage = 10,
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

        public static readonly StorageBuilding StorageYard = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceType = ResourceType.Resource,

            Name = "Storage Yard",
            BaseRate = 1,
            BaseStorage = 10,
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

        public static readonly StorageBuilding Granary = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Food,
            ResourceType = ResourceType.MetaResource,

            Name = "Granary",
            BaseRate = 1,
            BaseStorage = 10,
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

        public static readonly StorageBuilding StoragePit = new StorageBuilding
        {
            MetaResourceEnum = MetaResourceEnum.Production,
            ResourceType = ResourceType.MetaResource,

            Name = "Storage Pit",
            BaseRate = 1,
            BaseStorage = 10,
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