using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mika2027.Models
{
    public class Yarn
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

        public string FiberSummary => GetFiberSummary();
        public string DetailsSummary => GetDetailsSummary();


        public string GetFiberSummary()
        {
            if (Materials is null || Materials.Count == 0)
            {
                return string.Empty;
            }

            var names = new List<string>(Materials.Count);
            foreach (var m in Materials)
            {
                names.Add(m.FiberName);
            }

            return string.Join(" • ", names);
        }

        public string GetDetailsSummary()
        {
            return $"{Skeins} skein(s) • {Grams}g • {Yards}yds";
        }

    }


}
