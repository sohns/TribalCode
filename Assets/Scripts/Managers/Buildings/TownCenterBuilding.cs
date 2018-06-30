using System.Collections.Generic;
using Enum;
using Util;

namespace Managers.Buildings
{
    public class TownCenterBuilding : BaseBuilding
    {
        //So much more

        public TownCenterBuilding()
        {
            BuildingType = BuildingType.TownCenter;
        }

        public override bool BuyNextLevel(ref Dictionary<MetaResourceEnum, AdvancedNumber> currentAmounts)
        {
            //Cannot Level ATM
            return false;
        }

        public override void SetLevels(int level)
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