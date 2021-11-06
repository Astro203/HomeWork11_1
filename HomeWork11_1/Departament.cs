using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_1
{
    class Departament
    {
        public string Name { get; set; }
        public int DepartamentID { get; set; }

        public Departament(string Name, int DepartamentID)
        {
            this.Name = Name;
            this.DepartamentID = DepartamentID;
        }
        
    }

    
}
