using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimercado
{
    public class Caixa
    {
        public static double valorCaixa = 5000;

        public double ValorCaixa
        {
            get
            {
                return valorCaixa;
            }
            private set
            {
                valorCaixa = value;
            }
        }

        public void AdicionaCaixa(double valor) { ValorCaixa += valor; }

        public void ReduzCaixa(double valor) { ValorCaixa -= valor; }
    }

}
