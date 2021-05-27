using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.Interfaces
{
    public interface IReportStorage
    {
        ReportVisitMedicinesViewModel GetVisitMedicines(VisitBindingModel model);
        List<ReportVisitsViewModel> GetFullListVisits(ReportVisitBindingModel model, int _ClientId);
    }
}
