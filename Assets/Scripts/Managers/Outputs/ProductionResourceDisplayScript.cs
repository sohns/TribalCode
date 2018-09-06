using Enum;
using System;
using UnityEngine;

namespace Managers.Outputs
{
    public class ProductionResourceDisplayScript : MetaResourceDisplayPrefabScript
    {
        public MetaResourceEnum MetaResourceEnum;

        private void Start()
        {
            MetaOutputManager.AnotherOutputManager.ResourceRegistration(MetaResourceEnum, gameObject);
        }
        public void SetValues(ProductionResourceDisplayInfo productionresourceDisplayInfo)
        {
            if (productionresourceDisplayInfo.MetaResourceEnum != MetaResourceEnum)
            {
                throw new ArgumentException("using the wrong production resource enum:" + productionresourceDisplayInfo.MetaResourceEnum + "correct production resource enum:" + MetaResourceEnum);
            }

            base.SetValues(productionresourceDisplayInfo);
        }
    }
}