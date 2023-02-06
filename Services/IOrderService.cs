using System.Collections.Generic;
using System.Threading.Tasks;
using DapperSampleProject.ViewModels;

namespace DapperSampleProject.Services
{
    public interface IOrderService
    {
         Task<List<OrderViewModel>> GetAllAsync();
         Task<OrderViewModel> GetAsync(int id);
         Task InsertAsync(OrderViewModel model);
    }
}