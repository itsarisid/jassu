using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models
{
    public class UserModal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ReportRoles { get; set; }
        public bool IsActive { get; set; }

        public List<ReportModal> Reports { get; set; }
    }
}