using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.HelperModels
{
    class WordTextProperties
    {
        public string Size { get; set; }

        public bool Bold { get; set; }

        public JustificationValues JustificationValues { get; set; }
    }
}
