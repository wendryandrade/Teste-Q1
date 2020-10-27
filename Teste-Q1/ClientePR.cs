using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Teste_Q1
{
    class ClientePR : Cliente
    {

        public void CadastrarClientePR(List<ClientePR> ClientesPR, ClientePR NovoClientePR)
        {
            //Lê o arquivo ClientePR
            FileStream arqleclientePR = new FileStream("ClientePR.txt", FileMode.OpenOrCreate);
            StreamReader leclientePR = new StreamReader(arqleclientePR);

            string linha = " ";
            string[] resultado;

            do
            {
                linha = leclientePR.ReadLine();
                if (linha != null)
                {
                    resultado = linha.Split(',');
                }
            } while (linha != null);

            leclientePR.Close();


            //Append = abrirá arquivo existente e continuará escrevendo nele, e se não existir irá criar
            FileStream arqescreveclientePR = new FileStream("ClientePR.txt", FileMode.Append);
            StreamWriter escreveclientePR = new StreamWriter(arqescreveclientePR);


            int opCadastro = 0;

            do
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("=========================");
                Console.WriteLine("Cadastro de Cliente do PR");
                Console.WriteLine("=========================");
                Console.WriteLine();

                Console.WriteLine("Nome: ");
                NovoClientePR.nome = Console.ReadLine();
                escreveclientePR.Write(" Nome: " + NovoClientePR.nome + ",");

                Console.WriteLine("CPF: ");
                NovoClientePR.CPF = Console.ReadLine();
                escreveclientePR.Write(" CPF: " + NovoClientePR.CPF + ",");

                NovoClientePR.dataCadastro = DateTime.Now;
                escreveclientePR.Write(" Data de Cadastro: " + NovoClientePR.dataCadastro + ",");

                Console.WriteLine("Data de Nascimento: (Formato DD/MM/AAAA)");
                NovoClientePR.dataNascimento = DateTime.Parse(Console.ReadLine());
                escreveclientePR.Write(" Data de Nascimento: " + NovoClientePR.dataNascimento + ",");

                //Calcula idade
                TimeSpan idade = (dataCadastro - dataNascimento);
                int idadeanos = idade.Days / 365;

                if (idadeanos < 18)
                {
                    Console.WriteLine();
                    Console.WriteLine("Não é possível o cadastro de menores de 18 anos!");
                }

                else
                {
                    Console.WriteLine("Quantidade de telefones que deseja cadastrar: (Mínimo 1)");
                    int qtdTelefones = int.Parse(Console.ReadLine());

                    if (qtdTelefones <= 0)
                        Console.WriteLine("Quantidade inválida!");

                    for (int i = 1; i <= qtdTelefones; i++)
                    {
                        Console.WriteLine("Telefone: ");
                        string tel = Console.ReadLine();
                        NovoClientePR.telefone.Add(tel);
                        escreveclientePR.Write(" Telefone: " + tel + ",");
                    }

                    escreveclientePR.WriteLine(" ");
                    escreveclientePR.Close();

                    //Adicionar NovoClientePR na Lista
                    ClientesPR.Add(NovoClientePR);

                    Console.WriteLine();
                    Console.WriteLine("Cliente do PR cadastrado com sucesso!");
                    Console.WriteLine();

                }

                Console.WriteLine();
                Console.WriteLine("=====================================");
                Console.WriteLine("Deseja cadastrar outro Cliente do PR?");
                Console.WriteLine("1- Sim");
                Console.WriteLine("2- Não");
                Console.WriteLine("=====================================");
                opCadastro = int.Parse(Console.ReadLine());

            } while (opCadastro != 2);
        }
    }
}
