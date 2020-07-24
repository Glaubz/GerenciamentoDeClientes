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
                string origem = "BD_DadosClientes.txt";
                //Caminho do arquivo com Gastos de cada cliente no mês
                string caminhoGastosMensal = "BD_GastosClientes.txt";

                //Objeto do tipo StreamReader para manipulação de leitura de arquivos
                StreamReader dadosClientes = new StreamReader(origem);
                //StreamReader de Gastos Mensais
                StreamReader gastoMensal = new StreamReader(caminhoGastosMensal);
                
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

                    string linha2; //Variável para verificar linhas do segundo arquivo
                    while((linha2 = gastoMensal.ReadLine()) != null){ //Verifica cada linha do arquivo
                        string[] valores = linha2.Split(";");
                        if(valores[0] == id.ToString()){ //Verifica se o numero de Id do segundo arquivo bate com o Id do cliente no primeiro arquivo
                            for(int i=0; i<cliente.GastoMensal.Length; i++){ //Enquanto i for menor que o tamanho do vetor de GastoMensal será definido para cada posição do GastoMensal um valor de valores
                                cliente.GastoMensal[i] = double.Parse(valores[i+1], CultureInfo.InvariantCulture);
                            }
                        }
                    }
                    cliente.gastoAnual(); //Executado método para cálculo do gasto anual de um cliente

                    Console.WriteLine(cliente);
                    Console.WriteLine("Gasto anual: " + cliente.GastoAnual.ToString("F2", CultureInfo.InvariantCulture) + "\n");

                    //Verificado na documentação oficial que as seguintes linhas reiniciam a leitura do StreamReader
                    gastoMensal.DiscardBufferedData(); //Limpa o buffer
                    gastoMensal.BaseStream.Seek(0, SeekOrigin.Begin); //Define de onde iniciar e como será o restante da leitura

                }
                clientes.totalGastos(); //Executado método para deferir o total de gastos de todos os clientes

                //System.Console.WriteLine("Teste");

                dadosClientes.Close();
                gastoMensal.Close();

                Console.Write("GASTO TOTAL DOS CLIENTES: R$" + clientes.GastoTotal.ToString("F2", CultureInfo.InvariantCulture) + "\n");

            }
            catch(Exception m){
                Console.WriteLine("Ocorreu um erro: \n");
                Console.WriteLine(m.Message);
            }

        }
    }
}
