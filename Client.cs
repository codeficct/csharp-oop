using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn {
    public class Client {
        public string name { get; set; }
        public string lastNname { get; set; }
        public int phone { get; set; }
        public string creditCard { get; set; }

        public string FullName {
            get { return name + " " + lastNname; }
        }
    }
}
