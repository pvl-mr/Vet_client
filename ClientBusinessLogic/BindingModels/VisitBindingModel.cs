using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.BindingModels
{
    public class VisitBindingModel : BindingModel
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<int> ServiceIds { get; set; }

        public List<int> AnimalIds { get; set; }
    }
}
