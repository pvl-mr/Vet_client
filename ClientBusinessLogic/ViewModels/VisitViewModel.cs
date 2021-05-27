﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ClientBusinessLogic.ViewModels
{
    public class VisitViewModel
    {
        public int Id { get; set; }

        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Ваш комментарий")]
        public string Comment { get; set; }

        public Dictionary<int, (string petName, string petBreed)> Animals;
        public Dictionary<int, (string serviceName, string description)> Services;

        public int ClientId { get; set; }
    }
}
