using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Entities
{
    public class ElevadorEntrada
    {
        public int Andar { get; set; }
        public char Elevador { get; set; }
        public char Turno { get; set; }
    }
}
