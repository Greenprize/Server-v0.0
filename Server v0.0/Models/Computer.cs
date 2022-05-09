using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(30, ErrorMessage = "Название компьютера не должно превышать 30 символов")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(80, ErrorMessage = "Название CPU не должно превышать 80 символов")]
        public string CPU { get; set; }
        [StringLength(80, ErrorMessage = "Название видеокарты не должно превышать 80 символов")]
        public string GraphicsCard { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(80, ErrorMessage = "Название RAM не должно превышать 80 символов")]
        public string RAM { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(80, ErrorMessage = "Название материнской карты не должно превышать 80 символов")]
        public string Motherboard { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(80, ErrorMessage = "Название источника питания не должно превышать 80 символов")]
        public string PowerSupply { get; set; }
        [StringLength(80, ErrorMessage = "Название жёсткого диска не должно превышать 80 символов")]
        public string HardDrive { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(80, ErrorMessage = "Название SSD диска не должно превышать 80 символов")]
        public string SSD_Disk { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [StringLength(80, ErrorMessage = "Название корпуса не должно превышать 80 символов")]
        public string Body { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [Range(0, 1000000000, ErrorMessage = "Цена не может быть отрицательной")]
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
    }
}
