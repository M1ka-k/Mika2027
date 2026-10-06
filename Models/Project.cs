using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mika2027.Models
{
    class Project
    {
        public string Name { get; set; }
        public List<Yarn> Yarns { get; set; } = new List<Yarn>();
        public int HookSize { get; set; }
        public int Yartage { get; set; }
        public bool IsFreeHand {  get; set; }
    }
}
