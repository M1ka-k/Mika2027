using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mika2027.Models
{
    class Yarn
    {
        public string Name { get; set; }
        public string? Brand { get; set; }
        public int Weight { get; set; }
        public double Grams { get; set; }
        public double Yards { get; set; }
        public List<Material> Materials { get; set; } = new();
        public List<String> Colors { get; set; }
        public int Skeins { get; set; }
        public string? ColorLot { get; set; }
        public bool IsNaturalFibers { get; set; }

        public bool IsMachineWashable { get; set; }
        public bool IsVarigated { get; set; }
        public string? Image { get; set; }
        
    }
}
