using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_base_PBL.Objetos
{
    public class Meteoro : Objetos_Na_Atmosfera
    {
        public double DistanciaDoCanhao { get; private set; }

        public Meteoro()
        {
            DistanciaDoCanhao = 649.5190528;
            AlturaInicial = 375;
            Voy = 0;
            Gravidade = 9.8;
        }

        public override double SetAltura(double tempo)
        {
            Altura = AlturaInicial - (Gravidade / 2) * Math.Pow(tempo, 2);
            return Altura;
        }
    }
}
