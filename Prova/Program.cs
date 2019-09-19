using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;



namespace Trabalho_programação
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean cont = true;
            List<Inclusao> lista;
            lista = new List<Inclusao>();

            do
            {

                Console.WriteLine("\n");
                Console.WriteLine("Menu de Cadastro");
                Console.WriteLine("Total de produtos:{0}", lista.Count);
                Console.WriteLine("01 - Incluir");
                Console.WriteLine("02 - Alterar");
                Console.WriteLine("03 - Excluir");
                Console.WriteLine("04 - Listar");
                Console.WriteLine("05 - Pesquisar");
                Console.WriteLine("06 - Sair");
                Console.WriteLine("\n");
                Console.WriteLine("Digite sua opção desejada: ");
                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "01":
                        lista.Add(incluirPessoa());
                        break;

                    case "02":

                        Console.WriteLine("\nInforme o ID do usuario em que deseja alterar: ");
                        int searchId = int.Parse(Console.ReadLine());
                        Inclusao buscaID = lista.Find(x => x.Id == searchId);

                        if (buscaID != null)
                        {
                            Console.WriteLine("\nO que deseja alterar: ");
                            Console.WriteLine(" 01 - Produto");
                            Console.WriteLine(" 02 - Quantidade de produtos");
                            Console.WriteLine(" 03 - Data");
                            Console.WriteLine(" 04 - Andar do estoque \n");


                            string opcAlterar = Console.ReadLine();

                            switch (opcAlterar)
                            {
                                case "01":
                                    if (buscaID != null)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Digite o novo Produto: ");
                                        string textoNovo = Console.ReadLine();
                                        buscaID.alteraNome(textoNovo);
                                        foreach (var cadastro in lista)
                                        {
                                            Console.WriteLine(cadastro);
                                        }
                                    }
                                    break;

                                case "02":
                                    if (buscaID != null)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Digite a nova quantidade de produtos");
                                        double produtos = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                        buscaID.Produtos(produtos);
                                        foreach (var cadastro in lista)
                                        {
                                            Console.WriteLine(cadastro);
                                        }
                                    }
                                    break;
                                case "03":
                                    if (buscaID != null)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Digite a nova data: ");
                                        string dataNova = Console.ReadLine();
                                        buscaID.alteraData(dataNova);
                                        foreach (var cadastro in lista)
                                        {
                                            Console.WriteLine(cadastro);
                                        }
                                    }
                                    break;
                                case "04":
                                    if (buscaID != null)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Digite o novo andar de estoque: ");
                                        string estoqueNovo = Console.ReadLine();
                                        buscaID.alteraEstoque(estoqueNovo);
                                        foreach (var cadastro in lista)
                                        {
                                            Console.WriteLine(cadastro);
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("\nDados Invalidos");
                                    }
                                    break;

                            }

                        }
                        else
                        {
                            Console.Write("\nId de produto não existente");
                        }
                        break;

                    case "03":
                        Console.WriteLine("\nExcluir Dados\n");
                        foreach (var cadastro in lista)
                        {
                            Console.WriteLine(cadastro);
                        }

                        Console.WriteLine("\nInforme o ID do produto em que deseja excluir: ");
                        int searchUsuario = int.Parse(Console.ReadLine());
                        Inclusao buscaIDUsuario = lista.Find(x => x.Id == searchUsuario);

                        Console.WriteLine("Tem certeza que deseja excluir  1= Sim  2= Não");
                        int excluir = int.Parse(Console.ReadLine());

                        if (excluir == 1)
                        {

                            if (buscaIDUsuario != null)
                            {
                                lista.Remove(new Inclusao() { Id = searchUsuario });
                                Console.WriteLine("Dados Atualizados:");
                                foreach (var cadastro in lista)
                                {
                                    Console.WriteLine(cadastro);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Id do usuario não existente!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nProssiga");
                        }
                        break;

                    case "04":
                        Console.WriteLine("\n Organização por Id");
                        lista.Sort(delegate (Inclusao p1, Inclusao p2)
                        {
                            return p1.Id.CompareTo(p2.Id);
                        });
                        lista.ForEach(delegate (Inclusao p)
                        {
                            Console.WriteLine(String.Format("\n{0}|{1}|{2}|{3}|{4}", p.Id, p.Data, p.Produto, p.Quantidade, p.Andarestoque));
                        });
                        break;

                    case "05":
                        Console.WriteLine();
                        Console.WriteLine("Pesquisar");

                        Console.Write("Localização por Produto: ");
                        string lopro = Console.ReadLine();
                        Inclusao localizar = lista.Find(x => x.Produto == lopro);
                        if (localizar != null)
                        {
                            Console.WriteLine("/nLocalizado: " + localizar);
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado");
                        }
                        break;
                    case "06":
                        Console.WriteLine("Programa Encerrado");
                        Thread.Sleep(2000);
                        Environment.Exit(1);
                        cont = false;
                        break;


                    default:
                        Console.WriteLine("Opção inexistente");
                        break;
                }

            } while (cont);


        }

        private static Inclusao incluirPessoa()
        {

            Inclusao incluir = new Inclusao();

            Console.WriteLine("\nCadastro de Pessoa");
            Console.WriteLine("ID: ");
            incluir.Id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Data: ");
            incluir.Data= Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Produtos: ");
            incluir.Produto = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Quantidades de produtos: ");
            incluir.Quantidade = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Andar do estoque: ");
            incluir.Andarestoque = float.Parse(Console.ReadLine());


            return incluir;

        }

    }
}