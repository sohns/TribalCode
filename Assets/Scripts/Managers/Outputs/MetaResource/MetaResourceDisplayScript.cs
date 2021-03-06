﻿using System;
using Enum;

namespace Managers.Outputs.MetaResource
{
    public class MetaResourceDisplayScript : BaseMetaResourceDisplayScript
    {
        public MetaResourceEnum MetaResourceEnum;

        private void Start()
        {
            OutputManager.ThisManager.MetaResourceRegistration(MetaResourceEnum, gameObject);
        }
        public void SetValues(MetaResourceDisplayInfo productionresourceDisplayInfo)
        {
            if (productionresourceDisplayInfo.MetaResourceEnum != MetaResourceEnum)
            {
                throw new ArgumentException("using the wrong production resource enum:" + productionresourceDisplayInfo.MetaResourceEnum + "correct production resource enum:" + MetaResourceEnum);
            }

            base.SetValues(productionresourceDisplayInfo);
        }
    }
}