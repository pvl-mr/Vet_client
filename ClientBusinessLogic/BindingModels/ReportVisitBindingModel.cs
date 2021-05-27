using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.BindingModels
{
    public class ReportVisitBindingModel
    {
        public string FileName { get; set; }
        public int ClientId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<VisitViewModel> Visits { get; set; }
    }
}
