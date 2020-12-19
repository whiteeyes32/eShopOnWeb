using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class CatalogMaterial : BaseEntity, IAggregateRoot
    {
        public string Material { get; private set; }
        public CatalogMaterial(string material)
        {
            Material = material;
        }
    }
}
