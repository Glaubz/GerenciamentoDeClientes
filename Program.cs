using System;
using Atividade_III_Ex6.Entities;
using System.IO;

namespace Atividade_III_Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Clientes clientes = new Clientes();

                //Variável que contém o caminho do arquivo
                string origem = @"/home/glauber/Documentos/Projetos_C#/Exs_OO/Atividade_III/BD_Ex6-Atividade3/BD_DadosClientes.txt";

                //Objeto do tipo StreamReader para manipulação de leitura de arquivos
                StreamReader dadosClientes = new StreamReader(origem);
                
                string linha; //Variável para guardar cada linha

                //
                while((linha = dadosClientes.ReadLine()) != null){
                    string[] dado = linha.Split("|");

                    Telefone telefone = new Telefone();

                    int id = int.Parse(dado[0]);
                    string nome = dado[1];
                    string email = dado[2];
                    telefone.addTelefone(dado[3]);
                    string rua = dado[4];
                    string numero = dado[5];
                    string cidade = dado[6];

                    Endereco endereco = new Endereco(rua, numero, cidade);
                    Cliente cliente = new Cliente(id, nome, email, endereco, telefone);

                    clientes.addCliente(cliente);
                    System.Console.WriteLine(cliente);
                }

                dadosClientes.Close();

            }
            catch(Exception m){
                Console.WriteLine("Ocorreu um erro: \n");
                Console.WriteLine(m.Message);
            }

        }
    }
}
