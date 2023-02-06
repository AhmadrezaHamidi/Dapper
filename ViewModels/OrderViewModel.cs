using System;
using Dapper.Contrib.Extensions;

namespace DapperSampleProject.ViewModels
{
    [Table("Orders")]
    public class OrderViewModel
    {
        [Key]
        public int OrderId { get; set; }
        public int EmployeeId  { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}