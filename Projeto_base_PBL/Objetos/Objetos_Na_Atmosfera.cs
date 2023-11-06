using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_base_PBL.Objetos
{
    public class Objetos_Na_Atmosfera
    {
        public double Gravidade { get; protected set; }
        public double AlturaInicial { get; protected set; }
        public double Altura { get; protected set; }
        public double Voy { get; protected set; }

        public virtual double SetAltura(double tempo)
        {
            Altura = Voy * tempo - (Gravidade / 2) * Math.Pow(tempo, 2);
            return Altura;
        }

    }
}
