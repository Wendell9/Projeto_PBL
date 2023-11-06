using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_base_PBL.Objetos
{
    public class Projetil : Objetos_Na_Atmosfera
    {
        public double VelocidadeInicial { get; private set; }
        public double AnguloDaTrajetoria { get; private set; }
        public double AlturaMaximaProjetil { get; private set; }
        public double Vox { get; private set; }

        public Projetil(double velocidadeInicial, double anguloDaTrajetoria) 
        {
            VelocidadeInicial = velocidadeInicial;
            AnguloDaTrajetoria = anguloDaTrajetoria*(Math.PI/180.0);
            Vox = velocidadeInicial * Math.Cos(AnguloDaTrajetoria);
            Voy = velocidadeInicial * Math.Sin(AnguloDaTrajetoria);
            AlturaMaximaProjetil = Math.Pow(Voy, 2) / (2 * Gravidade);
            Gravidade = 9.8;
            AlturaInicial = 0;
        }
    }
}
