using System.Collections.Generic;
using Enum;

namespace Buildings
{
    public interface IBuilding
    {
        string Name { get; }
        int Level { get; }
        double BaseRate { get; }
        double CurrentRate { get; }
        Dictionary<MetaResourceEnum, double> BaseCost { get; }
        Dictionary<MetaResourceEnum, double> CostIncrease { get; }
        Dictionary<MetaResourceEnum, double> CurrentCost { get; }

        bool BuyNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts);
        void PayForNextLevel(ref Dictionary<MetaResourceEnum, double> currentAmounts);
        void UpdateRate();
        void UpdateCost();
        void SetLevels(int level);
    }
}