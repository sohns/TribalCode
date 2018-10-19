using System.Collections.Generic;
using Enum;
using Managers.Buildings;
using Util;

namespace Managers.Meta
{
    public class SaveInfo
    {
        public Dictionary<ResourceEnum, AdvancedNumber> ResourcesCount { get; set; }
        public Dictionary<ResourceEnum, AdvancedNumber> ResourcesRate { get; set; }
        public Dictionary<MetaResourceEnum, AdvancedNumber> MetaResourcesCount { get; set; }
        public Dictionary<MetaResourceEnum, AdvancedNumber> MetaResourcesRate { get; set; }
        public Dictionary<BuildingEnum, AdvancedNumber> Buildings { get; set; }
    }
}