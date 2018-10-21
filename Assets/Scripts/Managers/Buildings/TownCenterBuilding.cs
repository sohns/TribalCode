using System.Collections.Generic;
using CustomClasses;
using Enum;

namespace Managers.Buildings
{
    public class TownCenterBuilding : BaseBuilding
    {
        //So much more

        public TownCenterBuilding()
        {
            BuildingType = BuildingType.TownCenter;
        }

        public override bool BuyNextLevel()
        {
            //Cannot Level ATM
            return false;
        }

        public override void SetLevels(AdvancedNumber level)
        {
            //Cannot Set Level
            base.SetLevels(level);
        }


        public static readonly TownCenterBuilding TownCenter = new TownCenterBuilding
        {
            Name = "Town Center",
            BaseRate = .1,
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