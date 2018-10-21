
namespace CustomClasses
{
    public class AdvancedMath
    {
        public static AdvancedNumber Power(AdvancedNumber start, AdvancedNumber power)
        {
            if (power == 0)
            {
                return 1;
            }
            var toReturn = start;
            while (power > 1)
            {
                toReturn *= start;
                power--;
            }
            return toReturn;
        }

        public static AdvancedNumber Min(AdvancedNumber a, AdvancedNumber b)
        {
            return a <= b ? a : b;
        }
    }
}