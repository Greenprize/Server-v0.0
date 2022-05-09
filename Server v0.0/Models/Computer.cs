using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(30, ErrorMessage = "�������� ���������� �� ������ ��������� 30 ��������")]
        public string Title { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(80, ErrorMessage = "�������� CPU �� ������ ��������� 80 ��������")]
        public string CPU { get; set; }
        [StringLength(80, ErrorMessage = "�������� ���������� �� ������ ��������� 80 ��������")]
        public string GraphicsCard { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(80, ErrorMessage = "�������� RAM �� ������ ��������� 80 ��������")]
        public string RAM { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(80, ErrorMessage = "�������� ����������� ����� �� ������ ��������� 80 ��������")]
        public string Motherboard { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(80, ErrorMessage = "�������� ��������� ������� �� ������ ��������� 80 ��������")]
        public string PowerSupply { get; set; }
        [StringLength(80, ErrorMessage = "�������� ������� ����� �� ������ ��������� 80 ��������")]
        public string HardDrive { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(80, ErrorMessage = "�������� SSD ����� �� ������ ��������� 80 ��������")]
        public string SSD_Disk { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [StringLength(80, ErrorMessage = "�������� ������� �� ������ ��������� 80 ��������")]
        public string Body { get; set; }
        [Required(ErrorMessage = "������ ���� ����������� � ����������")]
        [Range(0, 1000000000, ErrorMessage = "���� �� ����� ���� �������������")]
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
    }
}
