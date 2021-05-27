using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.HelperModels
{
    public class ClientWordExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportVisitMedicinesViewModel> VisitMedicines { get; set; }
    }
}
