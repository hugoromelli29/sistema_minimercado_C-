using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimercado
{
    public class controleModuloProdutos
    {
        #region Adição de objetos
        private void AdicionarObjetos(List<Produto> listaProdutos)
        {
           I: Console.Clear();

           try
            {
                Console.WriteLine("=================================");
                Console.WriteLine("===   CADASTRO DE PRODUTOS    ===");
                Console.WriteLine("=================================\n");
                Console.WriteLine("=== Informe dados do produto ===");

                Produto produto = new();

                Console.WriteLine("Informe o nome do produto: ");
                produto.Nome = Console.ReadLine();
                Console.WriteLine("Informe a marca do produto: ");
                produto.Marca = Console.ReadLine();
                Console.WriteLine("Informe o valor de compra do produto: ");
                produto.Valor_Compra = double.Parse(Console.ReadLine());
                Console.WriteLine("Informe o valor de venda do produto: ");
                produto.Valor_Venda = double.Parse(Console.ReadLine());
                Console.WriteLine("Informe a qtd no estoque do produto: ");
                produto.qtd_Estoque = int.Parse(Console.ReadLine());

                listaProdutos.Add(produto);

                Console.WriteLine("... Produto cadastrado com sucesso! ...");

                produto.ExibeInformacoes();

                Console.ReadKey();
            }
            catch
            {
                MensagemDeErro();
                goto I;
            }
        }
        #endregion

        #region Listagem de objetos
        private void ListarObjetos(List<Produto> listaProdutos)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("===     LISTA DE PRODUTOS     ===");
            Console.WriteLine("=================================\n");

            if (listaProdutos.Count <= 0)
            {
                Console.WriteLine("... Não há produtos cadastrados! ...");
                Console.ReadKey();
                return;
            }

            foreach (Produto item in listaProdutos)
            {
                item.ExibeInformacoes();
            }

            Console.ReadKey();
        }
        #endregion

        #region Métodos auxiliares para pesquisa de objetos
        Produto DevolveObjetoPorCodigo(List<Produto> lista, string codigo)
        {
            return lista.Where(produto /*...localizar objeto...*/ => produto.Codigo /*...pelo código*/ == codigo).FirstOrDefault();
        }


        private List<Produto> DevolveListaObjetosPorNome(List<Produto> lista, string nome)
        {
            var consulta = (
                                 from produto in lista
                                 where produto.Nome == nome
                                 select produto).ToList();
            return consulta;
        }
        #endregion

        #region Pesquisa de objetos
        private void PesquisarObjetos(List<Produto> listaProdutos)
        {
            I: Console.Clear();
            try
            {
                Console.WriteLine("================================");
                Console.WriteLine("===    PESQUISAR PRODUTO     ===");
                Console.WriteLine("================================\n");

                Console.Write("Deseja pesquisar o produto por: (1) CÓDIGO ou (2) NOME ? ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            PesquisaPorCodigo();
                            break;
                        }
                    case 2:
                        {
                            PesquisaPorNome();
                            break;
                        }
                    default:
                            MensagemDeErro();
                            break;
                }
            }
            catch (Exception)
            {
                MensagemDeErro();
                goto I;
            }

            void PesquisaPorCodigo()
            {
                Console.WriteLine("Digite o código do produto a ser localizado:");
                string codigoParaBuscar = Console.ReadLine();

                var produtoBuscado = DevolveObjetoPorCodigo(listaProdutos, codigoParaBuscar);

                if (produtoBuscado == null) Console.WriteLine("Produto não encontrado");
                else produtoBuscado.ExibeInformacoes();

                Console.ReadKey();
            }

            void PesquisaPorNome()
            {
                Console.WriteLine("Digite o nome do produto a ser localizado:");
                string nomeProduto = Console.ReadLine();

                List<Produto> listaObjetos = DevolveListaObjetosPorNome(listaProdutos, nomeProduto);

                if (listaObjetos.Count == 0) Console.WriteLine("Nenhum produto encontrado");

                else
                {
                    foreach (var item in listaObjetos)
                    {
                        item.ExibeInformacoes();
                    }
                }

                Console.ReadKey();
            }
        }
        #endregion

        #region Remoção de objetos
        private void RemoverObjetos(List<Produto> listaProdutos)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("===      REMOVER PRODUTOS     ===");
            Console.WriteLine("=================================");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o código do produto a ser removido: ");
            string codigoProduto = Console.ReadLine();

            int contadorObjetosRemovidos = 0;

            foreach (var item in listaProdutos)
            {
                if (item.Codigo == codigoProduto)
                {
                    listaProdutos.Remove(item);
                    Console.WriteLine("... Produto removido ...");
                    contadorObjetosRemovidos++;
                    break;
                }
            }

            if (contadorObjetosRemovidos == 0) Console.WriteLine("... Produto não encontrado ...");

            Console.ReadKey();
        }
        #endregion

        #region Compra
        void RegistrarCompra(List<Produto> listaProdutos)
        {
            I: Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("===      COMPRA DE PRODUTO     ===");
            Console.WriteLine("==================================");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o código do produto que você comprou:");
            string codigo = Console.ReadLine();

            var produtoBuscado = DevolveObjetoPorCodigo(listaProdutos, codigo);

            if (produtoBuscado == null) Console.WriteLine("Produto não encontrado");
            else
            {
                try
                {
                    Console.WriteLine("Digite a quantidade comprada do produto:");
                    int quantidade = int.Parse(Console.ReadLine());
                    produtoBuscado.Compra(quantidade);
                    Console.WriteLine("... Compra registrada com sucesso! ...\n" +
                    "...       Estoque atualizado       ...\n" +
                    "...        Caixa atualizado        ...");
                }
                catch (Exception)
                {
                    MensagemDeErro();
                    goto I;
                }
            }

            Console.ReadKey();
        }
        #endregion

        #region Venda
        void RegistrarVenda(List<Produto> listaProdutos)
        {
        I: Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("===      VENDA DE PRODUTO      ===");
            Console.WriteLine("==================================");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o código do produto que você vendeu:");
            string codigo = Console.ReadLine();

            var produtoBuscado = DevolveObjetoPorCodigo(listaProdutos, codigo);

            if (produtoBuscado == null) Console.WriteLine("Produto não encontrado");
            else
            {
                try
                {
                    Console.WriteLine("Digite a quantidade vendida do produto:");
                    int quantidade = int.Parse(Console.ReadLine());
                    produtoBuscado.Venda(quantidade);
                    Console.WriteLine("... Venda registrada com sucesso! ...\n" +
                    "...       Estoque atualizado       ...\n" +
                    "...        Caixa atualizado        ...");
                }
                catch (Exception)
                {
                    MensagemDeErro();
                    goto I;
                }
            }

            Console.ReadKey();
        }
        #endregion

        #region Encerrar Módulo
        private void EncerrarModulo()
        {
            Console.Clear();
            Console.WriteLine("=============================================\n\n");
            Console.WriteLine("... Você está deixando o módulo PRODUTOS  ...");
            Console.WriteLine("...           Até a próxima!!!            ...");
            Console.WriteLine("\n\n=============================================\n\n");
            Console.ReadKey();
        }
        #endregion

        #region Mensagem de Erro
        private void MensagemDeErro()
        {
            Console.Clear();
            Console.WriteLine("=============================================\n\n");
            Console.WriteLine("...   Ops! Parece que algo deu errado   ...");
            Console.WriteLine("...        Vamos tentar de novo?        ...");
            Console.WriteLine("\n\n=============================================\n\n");
            Console.ReadKey();
        }
        #endregion

        #region Escrever Cabeçalho
        private void EscreverCabecalho()
        {
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("===                MÓDULO PRODUTOS                  ===");
            Console.WriteLine("=======================================================");
            Console.WriteLine("===        Tecle 1 para: CADASTRAR PRODUTOS         ===");
            Console.WriteLine("===         Tecle 2 para: LISTAR PRODUTOS           ===");
            Console.WriteLine("===        Tecle 3 para: PESQUISAR PRODUTOS         ===");
            Console.WriteLine("===         Tecle 4 para: REMOVER PRODUTOS          ===");
            Console.WriteLine("===    Tecle 5 para: REGISTRAR COMPRA DE PRODUTO    ===");
            Console.WriteLine("===    Tecle 6 para: REGISTRAR VENDA DE PRODUTO     ==="); ;
            Console.WriteLine("===         Tecle 7 para: ENCERRAR O MÓDULO         ===");
            Console.WriteLine("=======================================================\n\n");
        }
        #endregion

        #region Desenhar Menu
        public void DesenharMenu(List<Produto> listaProdutos)
        {
            int opcao = 0;

            while (opcao != 7)
            {
            I: EscreverCabecalho();

                try
                {
                    Console.Write("O que deseja fazer ? ");
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    MensagemDeErro();
                    goto I;
                }


                switch (opcao)
                {
                    case 1:
                        AdicionarObjetos(listaProdutos);
                        break;
                    case 2:
                        ListarObjetos(listaProdutos);
                        break;
                    case 3:
                        PesquisarObjetos(listaProdutos);
                        break;
                    case 4:
                        RemoverObjetos(listaProdutos);
                        break;
                    case 5:
                        RegistrarCompra(listaProdutos);
                        break;
                    case 6:
                        RegistrarVenda(listaProdutos);
                        break;
                    case 7:
                        EncerrarModulo();
                        break;
                    default:
                        MensagemDeErro();
                        break;
                }
            }
        }
        #endregion
    }
}
