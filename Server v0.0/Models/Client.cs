using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(100, ErrorMessage = "��� �� ������ ��������� 100 ��������")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "������������ ����������� �����")]
        [StringLength(40, ErrorMessage = "����������� ����� �� ������ ��������� 40 ��������")]
        public string Email { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(15, ErrorMessage = "������������ ����� ��������", MinimumLength = 11)]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Order> Orders { get; set; }
    }
}
