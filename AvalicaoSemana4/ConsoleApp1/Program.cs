using System;
using System.Collections.Generic;
using System.Linq;

namespace pessoa;

class Program
{
    static void Main()
    {
        Academia academia = new Academia();

        int opcao = 10;

        do{
            Console.WriteLine("Menu");
            Console.WriteLine("1- Cadastrar Treinador");
            Console.WriteLine("2- Cadastrar Cliente");
            Console.WriteLine("3- Treinadores com idade entre dois valores");
            Console.WriteLine("4- Clientes com idade entre dois valores");
            Console.WriteLine("5- Clientes com IMC maior que um valor informado");
            Console.WriteLine("6- Clientes em ordem alfabética");
            Console.WriteLine("7- Clientes do mais velho para mais novo");
            Console.WriteLine("8- Treinadores e clientes aniversariantes do mês informado");
            Console.WriteLine("9- Sair");
            Console.Write("Digite a opção: ");
            opcao = int.Parse(Console.ReadLine()!);

            if(opcao == 1) {
                Console.Write("Digite o Nome: ");
                string nome = Console.ReadLine()!;
                Console.Write("Digite a data de nascimento(dd, mm, yyyy): ");
                string inputData = Console.ReadLine()!;
                DateTime dataNascimento = DateTime.Parse(inputData);
                Console.Write("Digite o CPF(minimo 11 digitos): ");
                string cpf = Console.ReadLine()!;
                Console.Write("Digite o CREF: ");
                string cref = Console.ReadLine()!;

                Treinador treinador1 = new Treinador(nome, dataNascimento, cpf, cref);

                academia.CadastrarTreinador(treinador1);

            }else if(opcao == 2) {
                Console.Write("Digite o Nome: ");
                string nome = Console.ReadLine()!;
                Console.Write("Digite a data de nascimento(dd, mm, yyyy): ");
                string inputData = Console.ReadLine()!;
                DateTime dataNascimento = DateTime.Parse(inputData);
                Console.Write("Digite o CPF(minimo 11 digitos): ");
                string cpf = Console.ReadLine()!;
                Console.Write("Digite a altura: ");
                double altura = double.Parse(Console.ReadLine()!);
                Console.Write("Digite o peso: ");
                double peso = double.Parse(Console.ReadLine()!);

                Cliente cliente1 = new Cliente(nome, dataNascimento, cpf, altura, peso);
                academia.CadastrarCliente(cliente1);

            }else if(opcao == 3) {
                Console.WriteLine("Digite o valor 1: ");
                int valor1 = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Digite o valor 2: ");
                int valor2 = int.Parse(Console.ReadLine()!);

                var treinadoresRel = academia.ObterTreinadoresPorIdade(30, 50);
                foreach (var treinador in treinadoresRel)
                {
                    Console.WriteLine($"{treinador.Nome}, {treinador.Idade} anos");
                }
            }else if(opcao == 4) {
                Console.WriteLine("Digite o valor 1: ");
                int valor1 = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Digite o valor 2: ");
                int valor2 = int.Parse(Console.ReadLine()!);
                var clientesRelatorio2 = academia.ObterClientesPorIdade(25, 35);
                foreach (var cliente in clientesRelatorio2)
                {
                    Console.WriteLine($"{cliente.Nome}, {cliente.Idade} anos");
                }

            }else if(opcao == 5) {
                Console.Write("Digite o IMC: ");
                double imc = double.Parse(Console.ReadLine()!);
                var clientesRelatorio3 = academia.ObterClientesPorIMC(imc);
                foreach (var cliente in clientesRelatorio3)

                {
                    
                    Console.WriteLine($"{cliente.Nome}, IMC: {cliente.CalcularIMC}");
                }
            }else if(opcao == 6) {
                var clientesRelatorio4 = academia.ObterClientesOrdemAlfabetica();
                foreach (var cliente in clientesRelatorio4)
                {
                    Console.WriteLine(cliente.Nome);
                }
            }else if(opcao == 7) {
                var clientesRelatorio5 = academia.ObterClientesPorIdadeDecrescente();
                foreach (var cliente in clientesRelatorio5)
                {
                    Console.WriteLine($"{cliente.Nome}, {cliente.Idade} anos");
                }
            }else if(opcao == 8) {
                Console.Write("Digite o mês: ");
                int mes = int.Parse(Console.ReadLine()!);
                var aniversariantes = academia.ObterAniversariantesDoMes(mes);
                foreach (var pessoa in aniversariantes)
                {
                    Console.WriteLine($"{pessoa.Nome}, {pessoa.DataNascimento.Day}/{pessoa.DataNascimento.Month}");
                }

            }else if(opcao == 9) {
                Console.WriteLine("Saindo...");
            }else {
                Console.WriteLine("Opção inválida!");
            }



        }while(opcao != 9);

    }
    
}
    