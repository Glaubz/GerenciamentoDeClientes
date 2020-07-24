using System.Collections.Generic;

namespace Atividade_III_Ex6.Entities
{
    public class Clientes
    {
        public List<Cliente> ListaClientes { get; set; } = new List<Cliente>();

        public Clientes(){
        }

        public Clientes(Cliente cliente){
            ListaClientes.Add(cliente);
        }

        public void addCliente(Cliente cliente){
            ListaClientes.Add(cliente);
        }

        public void removeCliente(Cliente cliente){
            ListaClientes.Remove(cliente);
        }

        //Método para mostrar na tela os dados de todos os clientes contidos na lista de clientes
        public void printClientes(){
            System.Console.WriteLine(ListaClientes);
        }

    }
}