using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.Interfaces
{
    public interface IImplementingStatistics
    {
        List<VisitViewModel> GetVisitsStatistics(ReportBindingModel model, int _ClientId);
/*        List<VisitViewModel> GetAllVisitsStatistics(ReportBindingModel model, int _ClientId);
        List<AnimalViewModel> GetTourByMonthStatistic(StatisticBindingModel model, int _ClientId);
        List<AnimalViewModel> GetAllTourByMonthStatistic(StatisticBindingModel model);
        List<ExcursionViewModel> GetAllExcursionStatistics(ReportBindingModel model);*/
    }
}
