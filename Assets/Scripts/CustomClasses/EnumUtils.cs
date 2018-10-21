using System;
using System.Collections.Generic;
using Enum;

namespace CustomClasses
{
    public class EnumUtils
    {
        public static List<ResourceEnum> GetResourceEnums(MetaResourceEnum metaResourceEnum)
        {
            var toReturn = new List<ResourceEnum>();
            switch (metaResourceEnum)
            {
                case MetaResourceEnum.None:
                    throw new ArgumentOutOfRangeException("metaResourceEnum", metaResourceEnum, null);
                    break;
                case MetaResourceEnum.Food:
                    toReturn.Add(ResourceEnum.Fish);
                    toReturn.Add(ResourceEnum.Meat);
                    toReturn.Add(ResourceEnum.Berry);
                    break;
                case MetaResourceEnum.Production:
                    toReturn.Add(ResourceEnum.Wood);
                    toReturn.Add(ResourceEnum.Stone);
                    toReturn.Add(ResourceEnum.Clay);
                    break;
                case MetaResourceEnum.Population:
                    throw new ArgumentOutOfRangeException("metaResourceEnum", metaResourceEnum, null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("metaResourceEnum", metaResourceEnum, null);
            }
            return toReturn;
        }
    }
}