using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClientBusinessLogic.ViewModels
{
    public class ReportVisitsViewModel
    {
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        [DisplayName("Животное")]
        public string AnimalName { get; set; }

        [DisplayName("Медикамент")]
        public string MedicineName { get; set; }

    }
}
