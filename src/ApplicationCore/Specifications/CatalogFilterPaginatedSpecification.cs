using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId, int? materialId)
            : base()
        {
            Query
                .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId) &&
                (!materialId.HasValue || i.CatalogTypeId == materialId))
                .Paginate(skip, take);
        }
    }
}
