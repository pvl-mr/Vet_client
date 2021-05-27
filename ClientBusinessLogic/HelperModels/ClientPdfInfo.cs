using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.HelperModels
{
    class ClientPdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportVisitsViewModel> VisitAnimalsMedicines { get; set; }
    }
}
