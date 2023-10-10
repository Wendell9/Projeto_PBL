using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_base_PBL
{
    internal static class Calculadora
    {
        public static double fatorial(int n)
        {
            int valorFatorial = 1;
            if (n > 0)
            {
                for (int i = n; i > 0; i--)
                {
                    valorFatorial *= i;
                }
            }

            return valorFatorial;
        }
        public static double coseno(double x)
        {
            double precisao_desejada = Math.Pow(10, -9);

            bool precisao_desejada_alcancada = false;

            int k;
            k = 0;

            double f = 0;

            double r;

            while (!precisao_desejada_alcancada)
            {
                if (k == 0)
                {
                    f += 1;
                }
                else if (k >= 1 && k % 2 == 0 && k % 4 != 0)
                {
                    f += (-1) * Math.Pow(x, k) / Calculadora.fatorial(k);
                }
                else if (k >= 1 && k % 4 == 0)
                {
                    f += (Math.Pow(x, k)) / Calculadora.fatorial(k);
                }

                r = (Math.Pow(Math.Abs(x), (k + 1)) / Calculadora.fatorial(k + 1));

                if (r <= precisao_desejada)
                {
                    precisao_desejada_alcancada = true;
                }
                else
                {
                    k += 1;
                }
            }
            return f;
        }

        public static double seno(double x)
        {
            double precisao_desejada = Math.Pow(10, -9);

            bool precisao_desejada_alcancada = false;

            int k;
            k = 0;

            double f = 0;

            double r;

            int i = -1;

            while (!precisao_desejada_alcancada)
            {
                if (k == 1)
                {
                    f += x;
                }
                else if (k % 2 != 0)
                {
                    f += i * Math.Pow(x, k) / Calculadora.fatorial(k);
                    i *= -1;
                }

                r = (1 / Calculadora.fatorial(k + 1)) * Math.Pow(Math.Abs(x), k + 1);

                if (r <= precisao_desejada)
                {
                    precisao_desejada_alcancada = true;
                }
                else
                {
                    k += 1;
                }
            }
            return f;
        }
    }
}
