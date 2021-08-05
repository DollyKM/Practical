using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public partial class CompanyRecordModel
    {
        public int RecordID { get; set; }
        public Nullable<int> EmpId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Experience { get; set; }
        public string Designation { get; set; }
    }
}