﻿using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterSpecification : Specification<CatalogItem>
    {
        public CatalogFilterSpecification(int? brandId, int? typeId, int? materialId)
        {
            Query.Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId) && (!materialId.HasValue || i.CatalogTypeId == typeId));
        }
    }
}
