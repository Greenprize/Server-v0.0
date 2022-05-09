using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Range(0, 1000000000, ErrorMessage = "Цена не может быть отрицательной")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        public int ClientId { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ReportOrder> ReportOrders { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
        public Client Client { get; set; }
        public Status Status { get; set; }
    }
}
