using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Teste_Q1
{
    class ClienteSC : Cliente
    {
        public string RG { get; set; }

        public void CadastrarClienteSC(List<ClienteSC> ClientesSC, ClienteSC NovoClienteSC)
        {
            //Lê o arquivo ClienteSC
            FileStream arqleclienteSC = new FileStream("ClienteSC.txt", FileMode.OpenOrCreate);
            StreamReader leclienteSC = new StreamReader(arqleclienteSC);

            string linha = " ";
            string[] resultado;

            do
            {
                linha = leclienteSC.ReadLine();
                if (linha != null)
                {
                    resultado = linha.Split(',');
                }
            } while (linha != null);

            leclienteSC.Close();


            //Append = abrirá arquivo existente e continuará escrevendo nele, e se não existir irá criar
            FileStream arqescreveclienteSC = new FileStream("ClienteSC.txt", FileMode.Append);
            StreamWriter escreveclienteSC = new StreamWriter(arqescreveclienteSC);

            int opCadastro = 0;

            do
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("=========================");
                Console.WriteLine("Cadastro de Cliente de SC");
                Console.WriteLine("=========================");
                Console.WriteLine();

                Console.WriteLine("Nome: ");
                NovoClienteSC.nome = Console.ReadLine();
                escreveclienteSC.Write(" Nome: " + NovoClienteSC.nome + ",");

                Console.WriteLine("CPF: ");
                NovoClienteSC.CPF = Console.ReadLine();
                escreveclienteSC.Write(" CPF: " + NovoClienteSC.CPF + ",");

                Console.WriteLine("RG: ");
                NovoClienteSC.RG = Console.ReadLine();
                escreveclienteSC.Write(" RG: " + NovoClienteSC.RG + ",");

                NovoClienteSC.dataCadastro = DateTime.Now;
                escreveclienteSC.Write(" Data de Cadastro: " + NovoClienteSC.dataCadastro + ",");

                Console.WriteLine("Data de Nascimento: (Formato DD/MM/AAAA)");
                NovoClienteSC.dataNascimento = DateTime.Parse(Console.ReadLine());
                escreveclienteSC.Write(" Data de Nascimento: " + NovoClienteSC.dataNascimento + ",");

                Console.WriteLine("Quantidade de telefones que deseja cadastrar: (Mínimo 1)");
                int qtdTelefones = int.Parse(Console.ReadLine());

                if (qtdTelefones <= 0)
                    Console.WriteLine("Quantidade inválida!");

                for (int i = 1; i <= qtdTelefones; i++)
                {
                    Console.WriteLine("Telefone: ");
                    string tel = Console.ReadLine();
                    NovoClienteSC.telefone.Add(tel);
                    escreveclienteSC.Write(" Telefone: " + tel + ",");
                }

                escreveclienteSC.WriteLine(" ");
                escreveclienteSC.Close();

                //Adicionar NovoClienteSC na Lista
                ClientesSC.Add(NovoClienteSC);

                Console.WriteLine();
                Console.WriteLine("Cliente de SC cadastrado com sucesso!");
                Console.WriteLine();

                Console.WriteLine("=====================================");
                Console.WriteLine("Deseja cadastrar outro Cliente do SC?");
                Console.WriteLine("1- Sim");
                Console.WriteLine("2- Não");
                Console.WriteLine("=====================================");
                opCadastro = int.Parse(Console.ReadLine());

            } while (opCadastro != 2);
        }
    }
}
