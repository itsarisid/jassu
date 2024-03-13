using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models
{
    public class ReportModal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}