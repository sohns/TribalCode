using CustomClasses;
using Enum;

namespace Managers.Resources
{
    public class ResourceInfo
    {
        public MetaResourceEnum MetaResourceEnum { get; protected set; }
        public ResourceEnum ResourceEnum { get; protected set; }
        public AdvancedNumber Value { get; protected set; }
        public AdvancedNumber MaxValue { get; protected internal set; }
        public AdvancedNumber MinValue { get; protected internal set; }
        public AdvancedNumber ChangeValue { get; protected internal set; }

        public ResourceInfo(MetaResourceEnum metaResourceEnum, AdvancedNumber value, AdvancedNumber maxValue,
            AdvancedNumber minValue, AdvancedNumber changeValue)
        {
            MetaResourceEnum = metaResourceEnum;
            ResourceEnum = ResourceEnum.None;
            Value = value;
            MaxValue = maxValue;
            MinValue = minValue;
            ChangeValue = changeValue;
        }

        public ResourceInfo(ResourceEnum resourceEnum, AdvancedNumber value, AdvancedNumber maxValue,
            AdvancedNumber minValue, AdvancedNumber changeValue)
        {
            MetaResourceEnum = MetaResourceEnum.None;
            ResourceEnum = resourceEnum;
            Value = value;
            MaxValue = maxValue;
            MinValue = minValue;
            ChangeValue = changeValue;
        }

        public void Advance(float speed)
        {
            Value += ChangeValue * speed;
            Value.Bound(MinValue, MaxValue);
        }

        public void Pay(AdvancedNumber toPay)
        {
            Value -= toPay;
            Value.Bound(MinValue, MaxValue);
        }
    }
}