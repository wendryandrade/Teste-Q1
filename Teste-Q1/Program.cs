using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Teste_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            int opescolhida = 0;

            do
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("=======================");
                    Console.WriteLine("Clientes de SC e do PR");
                    Console.WriteLine("=======================");
                    Console.WriteLine();

                    Console.WriteLine("1- Cadastrar Cliente de SC");
                    Console.WriteLine("2- Cadastrar Cliente do PR");
                    Console.WriteLine("3- Relatório de Clientes por Nome");
                    Console.WriteLine("4- Relatório de Clientes por Data de Cadastro");
                    Console.WriteLine("5- Relatório de Clientes por Data de Nascimento");
                    Console.WriteLine("6- Sair");
                    opescolhida = int.Parse(Console.ReadLine());

                    List<ClienteSC> ClientesSC = new List<ClienteSC>();
                    List<ClientePR> ClientesPR = new List<ClientePR>();

                    //1- Cadastrar Cliente de SC
                    if (opescolhida == 1)
                    {
                        ClienteSC NovoClienteSC = new ClienteSC();
                        NovoClienteSC.CadastrarClienteSC(ClientesSC, NovoClienteSC);
                    }

                    //2- Cadastrar Cliente do PR
                    else if (opescolhida == 2)
                    {
                        ClientePR NovoClientePR = new ClientePR();
                        NovoClientePR.CadastrarClientePR(ClientesPR, NovoClientePR);
                    }

                    //3- Relatório de Clientes por Nome
                    else if (opescolhida == 3)
                    {
                        RelatorioNome();
                    }

                    //4- Relatório de Clientes por Data de Cadastro
                    else if (opescolhida == 4)
                    {
                        RelatorioDataCadastro();
                    }

                    //5- Relatório de Clientes por Data de Nascimento
                    else if (opescolhida == 5)
                    {
                        RelatorioDataNascimento();
                    }

                    //6- Sair
                    else if (opescolhida == 6)
                    {
                        break;
                    }

                    //Qualquer número diferente das opções disponíveis
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Opção inválida!");
                }

            } while (opescolhida != 6);
        }



        //Relatório por Nome
        public static void RelatorioNome()
        {
            int opPesqNome = 0;

            do
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine("Relatório de Cliente por Nome");
                    Console.WriteLine("=============================");
                    Console.WriteLine();

                    Console.WriteLine("Digite o Nome que deseja pesquisar:");
                    string nomePesquisar = Console.ReadLine();


                    //Lê o arquivo ClientePR
                    FileStream arqleclientePR = new FileStream("ClientePR.txt", FileMode.OpenOrCreate);
                    StreamReader leclientePR = new StreamReader(arqleclientePR);

                    string linha = " ";
                    string[] resultado;
                    string respostaNome = " ";

                    do
                    {
                        linha = leclientePR.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');


                            if (resultado[0] == (" Nome: " + nomePesquisar))
                            {
                                respostaNome = resultado[1];
                                Console.Write("\n\n" + linha);
                            }
                        }

                    } while (linha != null);

                    leclientePR.Close();


                    //Lê o arquivo ClienteSC
                    FileStream arqleclienteSC = new FileStream("ClienteSC.txt", FileMode.OpenOrCreate);
                    StreamReader leclienteSC = new StreamReader(arqleclienteSC);

                    do
                    {
                        linha = leclienteSC.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');


                            if (resultado[0] == (" Nome: " + nomePesquisar))
                            {
                                respostaNome = resultado[1];
                                Console.Write("\n\n" + linha);
                            }
                        }

                    } while (linha != null);

                    leclienteSC.Close();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Deseja pesquisar outro Cliente pelo Nome?");
                    Console.WriteLine("1- Sim");
                    Console.WriteLine("2- Não");
                    Console.WriteLine("=========================================");
                    opPesqNome = int.Parse(Console.ReadLine());

                    if (opPesqNome != 1 && opPesqNome != 2)
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("Opção inválida!");
                }

            } while (opPesqNome == 1);
        }



        //Relatório por Data de Cadastro
        public static void RelatorioDataCadastro()
        {
            int opPesqDataCadastro = 0;

            do
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Relatório de Cliente por Data de Cadastro");
                    Console.WriteLine("=========================================");
                    Console.WriteLine();

                    Console.WriteLine("Digite a Data de Cadastro que deseja pesquisar: (Formato: (DD/MM/AAAA)");
                    string dataCadastroPesquisar = Console.ReadLine();


                    //Lê o arquivo ClientePR
                    FileStream arqleclientePR = new FileStream("ClientePR.txt", FileMode.OpenOrCreate);
                    StreamReader leclientePR = new StreamReader(arqleclientePR);

                    string linha = " ";
                    string[] resultado;
                    string respostaDataCadastro = " ";

                    do
                    {
                        linha = leclientePR.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');

                            if (resultado[2].StartsWith(" Data de Cadastro: " + dataCadastroPesquisar))
                            {
                                respostaDataCadastro = resultado[2];
                                Console.Write("\n\n" + linha);
                            }
                        }

                    } while (linha != null);

                    leclientePR.Close();


                    //Lê o arquivo ClienteSC
                    FileStream arqleclienteSC = new FileStream("ClienteSC.txt", FileMode.OpenOrCreate);
                    StreamReader leclienteSC = new StreamReader(arqleclienteSC);

                    do
                    {
                        linha = leclienteSC.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');


                            if (resultado[3].StartsWith(" Data de Cadastro: " + dataCadastroPesquisar))
                            {
                                respostaDataCadastro = resultado[3];
                                Console.Write("\n\n" + linha);
                            }
                        }

                    } while (linha != null);

                    leclienteSC.Close();


                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("Deseja pesquisar outro Cliente pela Data de Cadastro?");
                    Console.WriteLine("1- Sim");
                    Console.WriteLine("2- Não");
                    Console.WriteLine("=====================================================");
                    opPesqDataCadastro = int.Parse(Console.ReadLine());

                    if (opPesqDataCadastro != 1 && opPesqDataCadastro != 2)
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine("Opção inválida!");
                }

            } while (opPesqDataCadastro == 1);
        }



        //Relatório por Data de Nascimento
        public static void RelatorioDataNascimento()
        {
            int opPesqDataNasc = 0;

            do
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine("===========================================");
                    Console.WriteLine("Relatório de Cliente por Data de Nascimento");
                    Console.WriteLine("===========================================");
                    Console.WriteLine();

                    Console.WriteLine("Digite a Data de Nascimento que deseja pesquisar: (Formato: (DD/MM/AAAA)");
                    string dataNascPesquisar = Console.ReadLine();


                    //Lê o arquivo ClientePR
                    FileStream arqleclientePR = new FileStream("ClientePR.txt", FileMode.OpenOrCreate);
                    StreamReader leclientePR = new StreamReader(arqleclientePR);

                    string linha = " ";
                    string[] resultado;
                    string respostaDataNasc = " ";

                    do
                    {
                        linha = leclientePR.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');


                            if (resultado[3] == (" Data de Nascimento: " + dataNascPesquisar + " 00:00:00"))
                            {
                                respostaDataNasc = resultado[3];
                                Console.Write("\n\n" + linha);
                            }
                        }

                    } while (linha != null);

                    leclientePR.Close();

                    //Lê o arquivo ClienteSC
                    FileStream arqleclienteSC = new FileStream("ClienteSC.txt", FileMode.OpenOrCreate);
                    StreamReader leclienteSC = new StreamReader(arqleclienteSC);

                    do
                    {
                        linha = leclienteSC.ReadLine();
                        if (linha != null)
                        {
                            resultado = linha.Split(',');


                            if (resultado[4] == (" Data de Nascimento: " + dataNascPesquisar + " 00:00:00"))
                            {
                                respostaDataNasc = resultado[4];
                                Console.Write("\n\n" + linha);
                            }
                        }

                    } while (linha != null);

                    leclienteSC.Close();

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("Deseja pesquisar outro Cliente pela Data de Nascimento?");
                    Console.WriteLine("1- Sim");
                    Console.WriteLine("2- Não");
                    Console.WriteLine("=======================================================");
                    opPesqDataNasc = int.Parse(Console.ReadLine());

                    if (opPesqDataNasc != 1 && opPesqDataNasc != 2)
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                }

                catch(Exception e)
                {
                    Console.WriteLine("Opção inválida!");
                }

            } while (opPesqDataNasc == 1);
        }
    }
}

