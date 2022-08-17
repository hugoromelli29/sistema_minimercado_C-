using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimercado;

public class Funcionario
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Idade { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }

    public void ExibeInformacoes()
    {
        Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n" +
                          $"DADOS DO FUNCIONÁRIO:\n" +
                          $"Nome do funcionário = {Nome}\n" +
                          $"CPF do funcionário = {CPF}\n" +
                          $"Idade do funcionário = {Idade}\n" +
                          $"Cargo do funcionário = {Cargo}\n" +
                          $"Salário do funcionário = {Salario}\n" +
                          $">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
    }
}
