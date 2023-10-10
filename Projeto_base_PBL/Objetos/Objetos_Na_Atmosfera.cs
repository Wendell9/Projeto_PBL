using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_base_PBL.Objetos
{
    public class Objetos_Na_Atmosfera
    {
        protected double Gravidade=10;
        public double Altura { get; protected set; }
        protected double Voy;

        public virtual void SetAltura(double tempo)
        {
            Altura = Voy * tempo - (Gravidade / 2) * Math.Pow(tempo, 2);
        }
    }
}
