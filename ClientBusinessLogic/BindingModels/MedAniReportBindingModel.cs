using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.BindingModels
{
    public class MedAniReportBindingModel : BindingModel
    {
        public string FileName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
