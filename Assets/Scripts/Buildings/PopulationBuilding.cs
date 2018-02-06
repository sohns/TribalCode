using System.Collections.Generic;
using Enum;

namespace Buildings
{
    public class PopulationBuilding : BaseBuilding
    {
        public ResourceEnum ResourceEnum { get; private set; }
        public int CurrentPopulation { get; private set; }
        public double PopulationCapBase { get; private set; }
        public double PopulationCapCurrent { get; private set; }

        public void SetLevels(int level, int currentPopulation)
        {
            base.SetLevels(level);
            CurrentPopulation = currentPopulation;
            PopulationCapCurrent = PopulationCapBase * level;
        }

        public override bool BuyNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts)
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

        public static readonly PopulationBuilding Fishery = new PopulationBuilding
        {
            ResourceEnum = ResourceEnum.Fish,

            Name = "Fishery",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationBuilding HuntingLodge = new PopulationBuilding
        {
            ResourceEnum = ResourceEnum.Meat,

            Name = "Hunting Lodge",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationBuilding GatheringHut = new PopulationBuilding
        {
            ResourceEnum = ResourceEnum.Berry,

            Name = "Gathering Hut",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationBuilding LumberCamp = new PopulationBuilding
        {
            ResourceEnum = ResourceEnum.Wood,

            Name = "Lumber Camp",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationBuilding Quarry = new PopulationBuilding
        {
            ResourceEnum = ResourceEnum.Stone,

            Name = "Quarry",
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
            },
            PopulationCapBase = 10
        };

        public static readonly PopulationBuilding ClayPit = new PopulationBuilding
        {
            ResourceEnum = ResourceEnum.Clay,

            Name = "Clay Pit",
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
            },
            PopulationCapBase = 10
        };
    }
}