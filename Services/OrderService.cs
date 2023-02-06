using System.Collections.Generic;
using System.Threading.Tasks;
using DapperSampleProject.Common;
using DapperSampleProject.ViewModels;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace DapperSampleProject.Services
{
    public class OrderService : IOrderService
    {
        private DapperUtility _dapperUtility;
        public OrderService(DapperUtility dapperUtility)
        {
           _dapperUtility = dapperUtility;
        }
        public async Task<OrderViewModel> GetAsync(int id)
        {
            using(var connection = _dapperUtility.GetConnection())
            {
                //using Dapper.Contrib.Extensions;
              OrderViewModel result = await  connection.GetAsync<OrderViewModel>(id);
              return result;
            }
        }

        public async Task<List<OrderViewModel>> GetAllAsync()
        {
             using(var connection = _dapperUtility.GetConnection())
            {
                //using Dapper.Contrib.Extensions;
              var result = await connection.GetAllAsync<OrderViewModel>();
              return result.ToList();
            }
        }

       public async Task InsertAsync(OrderViewModel model)
       {
            using(var connection = _dapperUtility.GetConnection())
            {
                //using Dapper.Contrib.Extensions;
              await connection.InsertAsync<OrderViewModel>(model);
            }
       }
    }
}