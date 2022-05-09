using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(20, ErrorMessage = "Название корпуса не должно превышать 20 символов")]
        public string Title { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Order> Orders { get; set; }
    }
}
