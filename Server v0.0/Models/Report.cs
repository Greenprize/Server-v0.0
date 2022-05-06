using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        [Required(ErrorMessage = "Данное поле обязательно к заполнению")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [StringLength(1000, ErrorMessage = "Название корпуса не должно превышать 1000 символов")]
        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Название корпуса не должно превышать 100 символов")]
        public string Link { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ReportOrder> ReportOrders { get; set; }
    }
}
