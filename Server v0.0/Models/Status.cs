using System.ComponentModel.DataAnnotations;

namespace Server_v0._0.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [StringLength(15)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
