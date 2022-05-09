using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Некорректная электронная почта")]
        [StringLength(40, ErrorMessage = "Электронная почта не должна превышать 40 символов")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(15, ErrorMessage = "Некорректный номер телефона", MinimumLength = 11)]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Order> Orders { get; set; }
    }
}
