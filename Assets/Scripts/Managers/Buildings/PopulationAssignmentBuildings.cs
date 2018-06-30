using System.Collections.Generic;
using Enum;
using Util;

namespace Managers.Buildings
{
    public class PopulationAssignmentBuildings : BaseBuilding
    {
        public ResourceEnum ResourceEnum { get; private set; }
        public int CurrentPopulation { get; private set; }
        public AdvancedNumber PopulationCapBase { get; private set; }
        public AdvancedNumber PopulationCapCurrent { get; private set; }

        public PopulationAssignmentBuildings()
        {
            BuildingType = BuildingType.PopulationAssignment;
        }

        public void SetLevels(int level, int currentPopulation)
        {
            base.SetLevels(level);
            CurrentPopulation = currentPopulation;
            PopulationCapCurrent = PopulationCapBase * level;
        }

        public override bool BuyNextLevel(ref Dictionary<MetaResourceEnum, AdvancedNumber> currentAmounts)
        {
            if (!base.BuyNextLevel(ref currentAmounts))
            {
                return false;
            }
            UpdatePopulationCap();
            return true;
        }

        private void UpdatePopulationCap()
        {
            PopulationCapCurrent = PopulationCapBase * Level;
        }

        public static readonly PopulationAssignmentBuildings Fishery = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Fish,

            Name = "Fishery",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationAssignmentBuildings HuntingLodge = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Meat,

            Name = "Hunting Lodge",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationAssignmentBuildings GatheringHut = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Berry,

            Name = "Gathering Hut",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationAssignmentBuildings LumberCamp = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Wood,

            Name = "Lumber Camp",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationAssignmentBuildings Quarry = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Stone,

            Name = "Quarry",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationAssignmentBuildings ClayPit = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Clay,

            Name = "Clay Pit",
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
            },
            PopulationCapBase = 10
        };
    }
}