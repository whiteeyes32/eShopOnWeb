using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces
{
    public interface ICatalogMaterialService
    {
        Task<List<CatalogMaterial>> List();
        Task<CatalogMaterial> GetById(int id);
    }
}
