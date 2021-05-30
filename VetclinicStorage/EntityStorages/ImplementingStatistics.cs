using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace VetclinicStorage.EntityStorages
{
    public class ImplementingStatistics : IImplementingStatistics
    {
        public List<VisitViewModel> GetVisitsStatistics(ReportBindingModel model, int _ClientId)
        {
            throw new NotImplementedException();
        }
    }
}
