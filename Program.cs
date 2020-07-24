using System;
using Atividade_III_Ex6.Entities;
using System.IO;
using System.Globalization;

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
                //Caminho do arquivo com Gastos de cada cliente no mês
                string caminhoGastosMensal = @"/home/glauber/Documentos/Projetos_C#/Exs_OO/Atividade_III/BD_Ex6-Atividade3/BD_GastosClientes.txt";

                //Objeto do tipo StreamReader para manipulação de leitura de arquivos
                StreamReader dadosClientes = new StreamReader(origem);
                //StreamReader de Gastos Mensais
                StreamReader gastosMensal = new StreamReader(caminhoGastosMensal);
                
                string linha; //Variável para guardar cada linha

                //Laço while que pega linha por linha do arquivo de dadosClientes para tratamento
                while((linha = dadosClientes.ReadLine()) != null){
                    string[] dado = linha.Split("|"); //Cria um vetor à partir da divisão de elementos da linha

                    Telefone telefone = new Telefone(); //Feito criação de objeto Telefone

                    //As linha abaixo pegam cada dado do vetor e instanciam em variáveis específicas
                    int id = int.Parse(dado[0]);
                    string nome = dado[1];
                    string email = dado[2];
                    telefone.addTelefone(dado[3]); //É adicionado ao objeto telefone
                    string rua = dado[4];
                    string numero = dado[5];
                    string cidade = dado[6];

                    Endereco endereco = new Endereco(rua, numero, cidade);
                    Cliente cliente = new Cliente(id, nome, email, endereco, telefone);

                    clientes.addCliente(cliente);
                    System.Console.WriteLine(cliente);

                    string linha2 = null; //Variável para verificar linhas do segundo arquivo
                    while((linha2 = gastosMensal.ReadLine()) != null){ //Verifica cada linha do arquivo
                        string[] valores = linha2.Split(";");
                        if(valores[0] == id.ToString()){ //Verifica se o numero de Id do segundo arquivo bate com o Id do cliente no primeiro arquivo
                            for(int i=0; i<cliente.GastoMensal.Length; i++){
                                cliente.GastoMensal[i] = double.Parse(valores[i+1], CultureInfo.InvariantCulture);
                            }
                        }
                    }

                }

                System.Console.WriteLine("Teste");

                dadosClientes.Close();

            }
            catch(Exception m){
                Console.WriteLine("Ocorreu um erro: \n");
                Console.WriteLine(m.Message);
            }

        }
    }
}
