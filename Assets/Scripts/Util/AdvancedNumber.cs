using System;
using UnityEngine.Experimental.XR;

namespace Util
{
    public class AdvancedNumber
    {
        private double _thisNumber;

        public AdvancedNumber(double thisNumber)
        {
            this._thisNumber = thisNumber;
        }

        public static AdvancedNumber operator +(AdvancedNumber a, AdvancedNumber b)
        {
            return new AdvancedNumber(a._thisNumber + b._thisNumber);
        }

        public static AdvancedNumber operator -(AdvancedNumber a, AdvancedNumber b)
        {
            return new AdvancedNumber(a._thisNumber + b._thisNumber);
        }

        public static AdvancedNumber operator *(AdvancedNumber a, AdvancedNumber b)
        {
            return new AdvancedNumber(a._thisNumber * b._thisNumber);
        }

        public static AdvancedNumber operator /(AdvancedNumber a, AdvancedNumber b)
        {
            return new AdvancedNumber(a._thisNumber / b._thisNumber);
        }

        public static bool operator <(AdvancedNumber a, AdvancedNumber b)
        {
            return a._thisNumber < b._thisNumber;
        }

        public static bool operator >(AdvancedNumber a, AdvancedNumber b)
        {
            return a._thisNumber > b._thisNumber;
        }

        public static bool operator ==(AdvancedNumber a, AdvancedNumber b)
        {
            return a._thisNumber == b._thisNumber;
        }

        public static bool operator !=(AdvancedNumber a, AdvancedNumber b)
        {
            return a._thisNumber != b._thisNumber;
        }

        public void Bound(AdvancedNumber min, AdvancedNumber max)
        {
            if (this < min)
            {
                _thisNumber = min._thisNumber;
            }
            else if (this > max)
            {
                _thisNumber = max._thisNumber;
            }
        }

        public override String ToString()
        {
            return _thisNumber.ToString();
        }

        public double ThisNumber
        {
            get { return _thisNumber; }
        }

        protected bool Equals(AdvancedNumber other)
        {
            return _thisNumber.Equals(other._thisNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AdvancedNumber) obj);
        }

        public override int GetHashCode()
        {
            return _thisNumber.GetHashCode();
        }

        public static implicit operator AdvancedNumber(double value)
        {
            return new AdvancedNumber(value);
        }
    }
}