using minimercado;

#region Criação da lista de funcionários
List<Funcionario> listaFuncionarios = new List<Funcionario>()
        {
            new Funcionario() {Nome = "João", CPF = "572.469.915.00", Idade = 16, Cargo = "Ajudante geral", Salario = 1080},
            new Funcionario() {Nome = "Maria", CPF = "244.573.659.10", Idade = 22, Cargo = "Caixa", Salario = 1520},
            new Funcionario() {Nome = "Márcia", CPF = "127.594.227.63", Idade = 49, Cargo = "Gerente", Salario = 3100}
        };
#endregion

#region Criação da lista de produtos
List<Produto> listaProdutos = new List<Produto>()
        {
            new Produto() {Nome = "arroz", Marca = "Tio João", Valor_Compra = 19.80, Valor_Venda = 23.99, qtd_Estoque = 12},
            new Produto() {Nome = "arroz", Marca = "Camil", Valor_Compra = 17.1, Valor_Venda = 22.99, qtd_Estoque = 2},
            new Produto() {Nome = "feijao", Marca = "Camil", Valor_Compra = 3.75, Valor_Venda = 7.99, qtd_Estoque = 5},
            new Produto() {Nome = "tapioca", Marca = "Rocha", Valor_Compra = 2.5, Valor_Venda = 6.99, qtd_Estoque = 9},
        };
#endregion

#region Desenho menu programa principal
int opcao = 0;

while (opcao != 3)
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
            new controleModuloProdutos().DesenharMenu(listaProdutos);
            break;
        case 2:
            new controleModuloFuncionarios().DesenharMenu(listaFuncionarios);
            break;
        case 3:
            EncerrarAplicacao();
            break;
        default:
            MensagemDeErro();
            break;
    }
}
#endregion

void MensagemDeErro()
{

    Console.Clear();
    Console.WriteLine("=============================================\n\n");
    Console.WriteLine("...   Ops! Parece que algo deu errado   ...");
    Console.WriteLine("...        Vamos tentar de novo?        ...");
    Console.WriteLine("\n\n=============================================\n\n");
    Console.ReadKey();

}

void EscreverCabecalho() 
{
    Console.Clear();
    Console.WriteLine("=====================================================");
    Console.WriteLine("===         MINIMERCADO DA SELMA                  ===");
    Console.WriteLine("===                                              ====");
    Console.WriteLine("===         BEM VINDO AO SISTEMA!                 ===");
    Console.WriteLine("=====================================================");
    Console.WriteLine("===   Tecle 1 para: ACESSAR O MÓDULO [PRODUTOS]   ===");
    Console.WriteLine("=== Tecle 2 para: ACESSAR O MÓDULO [FUNCIONÁRIOS] ===");
    Console.WriteLine("===       Tecle 3 para: ENCERRAR A APLICAÇÃO      ===");
    Console.WriteLine("=====================================================\n\n");
}

void EncerrarAplicacao()
{
    Console.Clear();
    Console.WriteLine("=================================================\n\n");
    Console.WriteLine("...     Você está encerrando a aplicação      ...");
    Console.WriteLine("...             Até a próxima!!!              ...");
    Console.WriteLine("\n\n=================================================\n\n");
    Console.ReadKey();
}
