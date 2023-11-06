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
            bool intercepta;

            if (projetil.Altura < 0)
            {
                Console.WriteLine("Infelizmente o projétil não foi capaz de atingir o alvo");
                intercepta = false;
                PosicaoObjetos(intercepta, tempo, projetil, meteoro);
            }
            else if (Math.Round(projetil.Altura,3) == Math.Round(meteoro.Altura,3))
            {
                intercepta = true;
                PosicaoObjetos(intercepta, tempo, projetil, meteoro);
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
                intercepta = false;
                PosicaoObjetos(intercepta, tempo, projetil, meteoro);
                Console.WriteLine("Infelizmente o projétil não foi capaz de atingir o alvo");
            }
        }
        public static void PosicaoObjetos(bool intercepta, double tempo, Projetil p, Meteoro m)
        {
            double posicaoxProjetil;
            double posicaoyProjetil;
            double posicaoyMeteoro;
            if (intercepta)
            {
                for (double i = 0; i != tempo; i++)
                {
                    if (i > tempo)
                    {
                        i = tempo;
                        posicaoxProjetil = i * p.Vox;
                        posicaoyProjetil = p.SetAltura(i);
                        posicaoyMeteoro = m.SetAltura(i);
                        Console.WriteLine("Posição do projetil");
                        Console.WriteLine($"Posição x:{posicaoxProjetil} Posição y:{posicaoyProjetil}, tempo:{i}");
                        Console.WriteLine("Posição do meteoro");
                        Console.WriteLine($"Posição x:{m.DistanciaDoCanhao} Posição y:{posicaoyMeteoro}, tempo:{i}");
                        break;
                    }
                    posicaoxProjetil = i * p.Vox;
                    posicaoyProjetil = p.SetAltura(i);
                    posicaoyMeteoro = m.SetAltura(i);
                    Console.WriteLine("Posição do projetil");
                    Console.WriteLine($"Posição x:{posicaoxProjetil} Posição y:{posicaoyProjetil}, tempo:{i}");
                    Console.WriteLine("Posição do meteoro");
                    Console.WriteLine($"Posição x:{m.DistanciaDoCanhao} Posição y:{posicaoyMeteoro}, tempo:{i}");
                }
            }
            else
            {
                double tempoDeDescidaProjetil;
                double tempoDeDescidaMeteoro;
                tempoDeDescidaProjetil = 2 * p.Voy / p.Gravidade;
                tempoDeDescidaMeteoro = Math.Sqrt((m.AlturaInicial * 2) / m.Gravidade);
                double i = 0;
                posicaoyProjetil = p.AlturaInicial;
                posicaoyMeteoro = m.AlturaInicial;
                do
                {
                    i++;
                    if (i > tempoDeDescidaProjetil && posicaoyProjetil != 0)
                    {
                        i = tempoDeDescidaProjetil;
                    }
                    if (i > tempoDeDescidaProjetil && posicaoyMeteoro != 0)
                    {
                        i = tempoDeDescidaMeteoro;
                    }
                    posicaoxProjetil = i * p.Vox;
                    posicaoyProjetil = p.SetAltura(i);
                    posicaoyMeteoro = m.SetAltura(i);
                    if (posicaoyMeteoro < 0)
                    {
                        posicaoyMeteoro = 0;
                    }
                    if (posicaoyProjetil < 0)
                    {
                        posicaoyProjetil = 0;
                    }
                    Console.WriteLine("Posição do projetil");
                    Console.WriteLine($"Posição x:{posicaoxProjetil} Posição y:{posicaoyProjetil}, tempo:{i}");
                    Console.WriteLine("Posição do meteoro");
                    Console.WriteLine($"Posição x:{m.DistanciaDoCanhao} Posição y:{posicaoyMeteoro}, tempo:{i}");
                } while (posicaoyMeteoro != 0 || posicaoyProjetil != 0);
            }
        }
    }

}
