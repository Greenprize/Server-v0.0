using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server_v0._0
{
    public class ReportOrder
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid ReportId { get; set; }
        public Report Report { get; set; }
    }
}
