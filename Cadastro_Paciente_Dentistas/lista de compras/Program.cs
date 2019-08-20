using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_compras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Lista de compras";
            Lista_compras lista = new Lista_compras();
            bool situacao = true;
            string arquivo = @"C:\\aula arquivo texto\Lista de Compras.txt";
            while (situacao)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Criar lista! Digite 1");
                    Console.WriteLine("");
                    Console.WriteLine("Ler sua lista! Digite 2");
                    Console.WriteLine("");
                    Console.WriteLine("Sair! Digite 3");
                    int operacao = Convert.ToInt32(Console.ReadLine());

                    switch (operacao)
                    {
                        case 1:
                            StreamWriter sw = new StreamWriter(arquivo,true);
                            Console.Clear();
                            Console.WriteLine("Escreva sua lista!");
                            lista.Lista_conteudo = Console.ReadLine();
                            sw.WriteLine("Lista: "+  lista.Lista_conteudo);
                            sw.WriteLine("");
                            sw.Dispose();
                            Console.WriteLine("");
                            Console.WriteLine("Criado com sucesso!");
                            Console.ReadKey();
                            break;
                        case 2:
                            StreamReader sr = new StreamReader(arquivo);
                            Console.Clear();
                            
                            if (File.Exists(arquivo))
                            {
                                try
                                {
                                        String linha;
                                        // Lê linha por linha até o final do arquivo
                                        while ((linha = sr.ReadLine()) != null)
                                        {
                                            Console.WriteLine(linha);
                                        }
                                    
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine(" O arquivo " + arquivo + "não foi localizado !");
                            }
                            Console.ReadKey();
                            sr.Dispose();
                            break;
                        case 3:
                            situacao = false;
                            break;
                        default:
                            Console.WriteLine("Digite um numero valido!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }

        }


    }
}


