using System;
using System.Collections.Generic;
using CustomClasses;
using Enum;
using UnityEngine;

namespace Managers.Buildings
{
    public class PopulationAssignmentBuildings : BaseBuilding
    {
        public ResourceEnum ResourceEnum { get; private set; }
        public AdvancedNumber CurrentPopulation { get; private set; }
        public AdvancedNumber PopulationCapBase { get; private set; }
        public AdvancedNumber PopulationCapCurrent { get; private set; }

        public PopulationAssignmentBuildings()
        {
            BuildingType = BuildingType.PopulationAssignment;
        }

        public void SetLevels(AdvancedNumber level, AdvancedNumber currentPopulation)
        {
            base.SetLevels(level);
            CurrentPopulation = currentPopulation;
            PopulationCapCurrent = PopulationCapBase * level;
            SetRate();
        }

        public override bool BuyNextLevel()
        {
            if (!base.BuyNextLevel())
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

        public override void SetLevels(AdvancedNumber level)
        {
            throw new NotImplementedException();
        }

        public AdvancedNumber AddPopulation(AdvancedNumber popToAdd)
        {
            var newPopulation = CurrentPopulation + popToAdd;
            if (newPopulation > PopulationCapCurrent)
            {
                CurrentPopulation = PopulationCapCurrent;
                SetRate();
                return newPopulation - PopulationCapCurrent;
            }
            CurrentPopulation = newPopulation;
            SetRate();
            return 0;
        }

        private void SetRate()
        {
            CurrentRate = BaseRate * CurrentPopulation;
        }

        public static readonly PopulationAssignmentBuildings Fishery = new PopulationAssignmentBuildings
        {
            ResourceEnum = ResourceEnum.Fish,

            Name = "Fishery",
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
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
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
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
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
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
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
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
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
                {MetaResourceEnum.Food, 5},
                {MetaResourceEnum.Production, 10}
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