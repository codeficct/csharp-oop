using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn
{
    class Ticket
    {
        // Properties
        public int id { get; set; }
        public string client { get; set; }
        public int phone { get; set; }
        public int dni { get; set; }
        public DateTime date { get; set; }
        public string product { get; set; }
        public int productCount { get; set; }

        // Methods
        public double determinePrice()
        {
            switch (product)
            {
                case "PS4 + 1 MANDO DS4": return 2049;
                case "PS4 + 2 MANDO DS4": return 1899;
                case "PS3 (500GB)": return 1349;
                case "MANDO PS4/DS4": return 219;
                case "MANDO PS3/DS4": return 199;
            }
            return 0;
        }

        public double calculateTotalPrice()
        {
            return productCount * determinePrice();
        }
    }
}
