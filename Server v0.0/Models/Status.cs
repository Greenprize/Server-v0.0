using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(20, ErrorMessage = "�������� ������� �� ������ ��������� 20 ��������")]
        public string Title { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Order> Orders { get; set; }
    }
}
