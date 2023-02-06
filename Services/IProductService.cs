using System.Collections.Generic;
using System.Threading.Tasks;
using DapperSampleProject.ViewModels;

namespace DapperSampleProject.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAsync();
        Task<ProductViewModel> GetByIdAsync(int id);
        Task<(List<ProductViewModel>, List<CategoryViewModel>)> GetProductsAndCategoriesAsync();
        Task BulkAddAsync(List<ProductViewModel> products);
        Task AddAsync(ProductViewModel model);
        Task AddWithSPAsync(ProductViewModel model);
        Task UpdateAsync(ProductViewModel model);
        Task BulkUpdateAsync(List<ProductViewModel> model);
        Task DeleteAsync(int id);
        Task BulkDeleteAsync(int[] ids);
        Task<List<CategoryViewModel>> GetCategoryForComboAsync();
        Task<List<SupplierViewModel>> GetSupplierForComboAsync();


    }
}