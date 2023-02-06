using System.Threading.Tasks;
using DapperSampleProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperSampleProject.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
           _orderService = orderService;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetAllAsync();
            return View(result);
        }
    }
}