using Projeto_base_PBL.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_base_PBL
{
    public static class InterfaceUsuario
    {
        public static void InsereDados()
        {
            double velocidadeInicial;
            double anguloDaTrajetoria;

            Console.WriteLine("Bem vindo ao simulador de acertar o alvo");
            Console.Write("Insira o valor do ângulo do canhão em graus: ");
            anguloDaTrajetoria = double.Parse(Console.ReadLine());
            Console.Write("Insira o valor da velocidade do projétil: ");
            velocidadeInicial = double.Parse(Console.ReadLine());

            Projetil projetil = new Projetil(velocidadeInicial, anguloDaTrajetoria);
            Meteoro meteoro = new Meteoro();
            VerificaIntercepta(projetil, meteoro);
        }

        public static void VerificaIntercepta(Projetil projetil, Meteoro meteoro)
        {
            double tempo;
            tempo = meteoro.DistanciaDoCanhao / projetil.Vox;
            meteoro.SetAltura(tempo);
            projetil.SetAltura(tempo);

            if (projetil.Altura < 0)
            {
                Console.WriteLine("Infelizmente o projétil não foi capaz de atingir o alvo");
            }
            else if (projetil.Altura == meteoro.Altura)
            {
                Console.WriteLine($"O projétil atingiu o alvo no ponto x:{meteoro.DistanciaDoCanhao} y:{meteoro.Altura}.\n" +
                    $"O alvo foi acertado no instante {tempo}");
                if (projetil.AlturaMaximaProjetil > projetil.Altura)
                {
                    Console.WriteLine("O alvo foi acertado na trajetória descendente");
                }
                else
                {
                    Console.WriteLine("O alvo foi acertado na trajetória ascendente");
                }
            }
            else
            {
                Console.WriteLine("Infelizmente o projétil não foi capaz de atingir o alvo");
                Console.WriteLine("Altura do meteoro: " + meteoro.Altura);
                Console.WriteLine("Altura do projetil: " + projetil.Altura);
            }
        }
    }
}
