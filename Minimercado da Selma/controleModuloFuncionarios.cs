using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimercado
{
    public class controleModuloFuncionarios
    {
        #region Adição de objetos
        private void AdicionarObjetos(List<Funcionario> listaFuncionarios)
        {
        I: Console.Clear();

            try
            {
                Console.WriteLine("====================================");
                Console.WriteLine("===  CADASTRO DE FUNCIONÁRIOS    ===");
                Console.WriteLine("====================================\n");
                Console.WriteLine("=== Informe dados do funcionário ===");

                Funcionario funcionario = new();

                Console.WriteLine("Informe o nome do funcionário: ");
                funcionario.Nome = Console.ReadLine();
                Console.WriteLine("Informe o CPF do funcionário: ");
                funcionario.CPF = Console.ReadLine();
                Console.WriteLine("Informe a idade do funcionário: ");
                funcionario.Idade = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o cargo do funcionário: ");
                funcionario.Cargo = Console.ReadLine();
                Console.WriteLine("Informe o salário do funcionário: ");
                funcionario.Salario = double.Parse(Console.ReadLine());

                listaFuncionarios.Add(funcionario);

                Console.WriteLine("... Funcionário cadastrado com sucesso! ...");

                funcionario.ExibeInformacoes();

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
        private void ListarObjetos(List<Funcionario> listaFuncionarios)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("===   LISTA DE FUNCIONÁRIOS   ===");
            Console.WriteLine("=================================\n");

            if (listaFuncionarios.Count <= 0)
            {
                Console.WriteLine("... Não há funcionários cadastrados! ...");
                Console.ReadKey();
                return;
            }

            foreach (Funcionario item in listaFuncionarios)
            {
                item.ExibeInformacoes();
            }

            Console.ReadKey();
        }
        #endregion

        #region Pesquisa de objetos
        private void PesquisarObjetos(List<Funcionario> listaFuncionarios)
        {
        I: Console.Clear();
            try
            {
                Console.WriteLine("================================");
                Console.WriteLine("===  PESQUISAR FUNCIONÁRIO   ===");
                Console.WriteLine("================================\n");

                Console.Write("Deseja pesquisar o funcionário por: (1) CPF ou (2) NOME ? ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            PesquisaCpf();
                            break;
                        }
                    case 2:
                        {
                            PesquisaNome();
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

            void PesquisaCpf()
            {
                Console.WriteLine("Digite o CPF do funcionário a ser localizado:");
                string cpfParaBuscar = Console.ReadLine();

                Funcionario ConsultaFuncionario(string cpf)
                {
                    return listaFuncionarios.Where(funcionario => funcionario.CPF == cpf).FirstOrDefault();
                }

                var funcionarioBuscado = ConsultaFuncionario(cpfParaBuscar);

                if (funcionarioBuscado == null) Console.WriteLine("Funcionário não encontrado");
                else funcionarioBuscado.ExibeInformacoes();

                Console.ReadKey();
            }

            void PesquisaNome()
            {
                Console.WriteLine("Digite o nome do funcionário a ser localizado:");
                string nomeFuncionario = Console.ReadLine();

                List<Funcionario> DevolveListaObjetos(string nome)
                {
                    var consulta = (
                                         from funcionario in listaFuncionarios
                                         where funcionario.Nome == nome
                                         select funcionario).ToList();
                    return consulta;
                }

                List<Funcionario> listaObjetos = DevolveListaObjetos(nomeFuncionario);

                if (listaObjetos.Count == 0) Console.WriteLine("Nenhum funcionário encontrado");

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
        private void RemoverObjetos(List<Funcionario> listaFuncionarios)
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("===    REMOVER FUNCIONÁRIOS   ===");
            Console.WriteLine("=================================");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o CPF do funcionário a ser removido: ");
            string cpfFuncionario = Console.ReadLine();

            int contadorObjetosRemovidos = 0;

            foreach (var item in listaFuncionarios)
            {
                if (item.CPF == cpfFuncionario)
                {
                    listaFuncionarios.Remove(item);
                    Console.WriteLine("... Funcionário removido ...");
                    contadorObjetosRemovidos++;
                    break;
                }
            }

            if (contadorObjetosRemovidos == 0) Console.WriteLine("... Funcionário não encontrado ...");

            Console.ReadKey();
        }
        #endregion

        #region Encerrar Módulo
        private void EncerrarModulo()
        {
            Console.Clear();
            Console.WriteLine("=================================================\n\n");
            Console.WriteLine("... Você está deixando o módulo FUNCIONÁRIOS ...");
            Console.WriteLine("...            Até a próxima!!!              ...");
            Console.WriteLine("\n\n=================================================\n\n");
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
            Console.WriteLine("================================================");
            Console.WriteLine("===           MÓDULO FUNCIONÁRIOS            ===");
            Console.WriteLine("================================================");
            Console.WriteLine("===   Tecle 1 para: CADASTRAR FUNCIONÁRIOS   ===");
            Console.WriteLine("===    Tecle 2 para: LISTAR FUNCIONÁRIOS     ===");
            Console.WriteLine("===   Tecle 3 para: PESQUISAR FUNCIONÁRIOS   ===");
            Console.WriteLine("===    Tecle 4 para: REMOVER FUNCIONÁRIOS    ===");
            Console.WriteLine("===      Tecle 5 para: ENCERRAR O MÓDULO     ===");
            Console.WriteLine("================================================\n\n");
        }
        #endregion

        #region Desenhar Menu
        public void DesenharMenu(List<Funcionario> listaFuncionarios)
        {
            int opcao = 0;

            while (opcao != 5)
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
                        AdicionarObjetos(listaFuncionarios);
                        break;
                    case 2:
                        ListarObjetos(listaFuncionarios);
                        break;
                    case 3:
                        PesquisarObjetos(listaFuncionarios);
                        break;
                    case 4:
                        RemoverObjetos(listaFuncionarios);
                        break;
                    case 5:
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
