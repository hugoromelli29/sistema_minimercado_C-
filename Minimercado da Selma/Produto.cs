using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimercado
{
    public class Produto
    {
        public string Codigo { get; private set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Valor_Compra { get; set; }
        public double Valor_Venda { get; set; }
        public int qtd_Estoque { get; set; }

        #region Construtor
        public Produto()
        {
            Codigo = Guid.NewGuid().ToString().Substring(0, 8);
        }
        #endregion

        public void ExibeInformacoes()
        {
            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n" +
                $"DADOS DO PRODUTO:\n" +
                $"Código do produto = {Codigo}\n" +
                $"Nome do produto = {Nome}\n" +
                $"Marca do produto = {Marca}\n" +
                $"Valor de compra do produto = {Valor_Compra}\n" +
                $"Valor de venda do produto = {Valor_Venda}\n" +
                $"Quantidade no estoque do produto = {qtd_Estoque}\n" +
                $">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
        }

        public void Venda(int qtdVendida)
        {
            qtd_Estoque = qtd_Estoque - qtdVendida;
        }
        public void Compra(int qtdComprada)
        {
            qtd_Estoque = qtd_Estoque + qtdComprada;
        }
    }
}
