using System;
using UnityEngine;

namespace Util
{
    [Serializable]
    public class SerializableEnum<T> where T : struct, IConvertible
    {
        public T Value
        {
            get { return _enumValue; }
            set { _enumValue = value;  }
        }

        [SerializeField] private string _enumValueAsString;
        [SerializeField] private T _enumValue;
    }
}