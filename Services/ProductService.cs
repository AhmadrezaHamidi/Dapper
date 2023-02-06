using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DapperSampleProject.ViewModels;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using DapperSampleProject.Common;

namespace DapperSampleProject.Services
{
    public class ProductService : IProductService
    {
        // private IConfiguration configuration;
        // public ProductService(IConfiguration configuration)
        // {
        //     this.configuration = configuration;
        // }

        private DapperUtility dapperUtility;
        public ProductService(DapperUtility dapperUtility)
        {
            this.dapperUtility = dapperUtility;
        }

        public async Task AddAsync(ProductViewModel model)
        {
            var sql = @"Insert Products(ProductName,CategoryID,SupplierID,UnitPrice)
                        VALUES(@ProductName,@CategoryID,@SupplierID,@UnitPrice)";
            using (var connection = dapperUtility.GetConnection())
            {
                await connection.ExecuteAsync(sql, model);
            }
        }

        // public async Task AddWithSPAsync(ProductViewModel model){
        //     var sql = "SP_Products_Insert";
        //     using(var connection = dapperUtility.GetConnection())
        //     {
        //         await connection.ExecuteAsync(sql, 
        //         new {ProductName = model.ProductName,CategoryID = model.CategoryId,
        //         SupplierID = model.SupplierId, UnitPrice = model.UnitPrice},
        //         commandType: CommandType.StoredProcedure);
        //     }
        // }

        public async Task BulkAddAsync(List<ProductViewModel> products)
        {
            var sql = @"Insert Products(ProductName,CategoryID,SupplierID,UnitPrice)
                        VALUES(@ProductName,@CategoryID,@SupplierID,@UnitPrice)";
            using (var connection = dapperUtility.GetConnection())
            {
                await connection.ExecuteAsync(sql, products);
            }
        }

        public async Task AddWithSPAsync(ProductViewModel model)
        {
            var sql = "SP_Products_Insert";
            using (var connection = dapperUtility.GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductName", model.ProductName);
                parameters.Add("CategoryId", model.CategoryId);
                parameters.Add("SupplierId", model.SupplierId);
                parameters.Add("UnitPrice", model.UnitPrice);
                parameters.Add("Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

                int id = parameters.Get<int>("Id");
            }
        }

        public async Task UpdateAsync(ProductViewModel model)
        {
            var sql = @"UPDATE Products
                        SET ProductName=@ProductName,CategoryID=@CategoryID,
                        SupplierID=@SupplierID,UnitPrice=@UnitPrice
                        Where ProductID=@ProductID";

            using (var connection = dapperUtility.GetConnection())
            {
                await connection.ExecuteAsync(sql, model);
            }
        }

        public async Task BulkUpdateAsync(List<ProductViewModel> model)
        {
            var sql = @"UPDATE Products
                        SET ProductName=@ProductName,CategoryID=@CategoryID,
                        SupplierID=@SupplierID,UnitPrice=@UnitPrice
                        Where ProductID=@ProductID";

            using (var connection = dapperUtility.GetConnection())
            {
                await connection.ExecuteAsync(sql, model);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "Delete Products Where ProductId=@id";
            using (var connection = dapperUtility.GetConnection())
            {
                await connection.ExecuteAsync(sql, new { id = id });
            }
        }

        public async Task BulkDeleteAsync(int[] ids)
        {

            var items = new List<ProductViewModel>();
            for (var i = 0; i < ids.Length; i++)
            {
                items.Add(new ProductViewModel { ProductId = ids[i] });
            }
            var sql = "Delete Products Where ProductId=@ProductId";
            using (var connection = dapperUtility.GetConnection())
            {
                await connection.ExecuteAsync(sql, items);
            }
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var sql = @"Select ProductId,ProductName,CategoryID,SupplierID,UnitPrice
                        FROM Products
                        Where ProductID=@ProductID";
            using (var conenction = dapperUtility.GetConnection())
            {
                return await conenction.QuerySingleOrDefaultAsync<ProductViewModel>(sql, new { ProductID = id });
            }
        }

        public async Task<List<ProductViewModel>> GetAsync()
        {
            //1-ConnectionString
            //var connectionString = configuration.GetConnectionString("NorthwindConnection");
            //var connectionString2 = configuration["ConnectionStrings:NorthwindConnection"];

            //2-Sql Query or Stored Procedure(SP)
            var query = @"Select ProductID, ProductName, UnitPrice,
                P.CategoryID, P.SupplierID, C.CategoryName, S.CompanyName
                FROM Products as P 
                INNER JOIN Categories  as C on P.CategoryID = C.CategoryID
                INNER JOIN Suppliers as S on P.SupplierID = S.SupplierID";

            //3-Create instance IDbConnection
            using (var connection = dapperUtility.GetConnection())
            {
                var result = await connection.QueryAsync<ProductViewModel>(query);
                return result.ToList();
            }

        }

        public async Task<(List<ProductViewModel>, List<CategoryViewModel>)> GetProductsAndCategoriesAsync()
        {
            var sql = "Select * From Products;Select * From Categories";
            using (var connection = dapperUtility.GetConnection())
            {
                var result = await connection.QueryMultipleAsync(sql);
                var products = await result.ReadAsync<ProductViewModel>();
                var categories = await result.ReadAsync<CategoryViewModel>();
                return (products.ToList(), categories.ToList());
            }
        }
        
        public async Task<List<CategoryViewModel>> GetCategoryForComboAsync()
        {
            using (var connection = dapperUtility.GetConnection())
            {
                var query = "select CategoryId,CategoryName from Categories";
                var result = await connection.QueryAsync<CategoryViewModel>(query);
                return result.ToList();
            }
        }

        public async Task<List<SupplierViewModel>> GetSupplierForComboAsync()
        {
            using (var connection = dapperUtility.GetConnection())
            {
                var query = "select SupplierID, CompanyName From Suppliers";
                var result = await connection.QueryAsync<SupplierViewModel>(query);
                return result.ToList();
            }
        }
    }
}
