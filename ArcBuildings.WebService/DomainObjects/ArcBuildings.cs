using System;
using System.Collections.Generic;
using System.Text;

namespace ArcBuildings.DomainObjects
{
    public class ArcBuildings : DomainObject
    {
        public string Functionality { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string Applicant { get; set; }
    }
}
