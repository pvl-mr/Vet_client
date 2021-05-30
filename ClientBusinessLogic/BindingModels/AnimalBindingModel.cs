using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.BindingModels
{
    public class AnimalBindingModel : BindingModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
    }
}
