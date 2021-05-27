using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.ViewModels
{
    public class MedAniReportViewModel
    {
        public DateTime Date { get; set; }

        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public string MedicineName { get; set; }
        public string ClientUserName { get; set; }

    }
}
