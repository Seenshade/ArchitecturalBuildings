using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitecturalBuildings.DomainObjects
{
    public class ArcBuildings : DomainObject
    {
        public string Name { get; set; }
        public string Functionality { get; set; }
        public string Location { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string Applicant { get; set; }

        
    }
}
