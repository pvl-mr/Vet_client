using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.ViewModels
{
    public class ReportVisitMedicinesViewModel
    {
        public DateTime VisitDate { get; set; }
        public List<MedicineDinamicViewModel> Medicines { get; set; }
    }
}
