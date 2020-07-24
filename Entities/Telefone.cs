using System.Collections.Generic;
using System.Text;

namespace Atividade_III_Ex6.Entities
{
    public class Telefone
    {
        public List<string> Telefones { get; set; } = new List<string>();

        public Telefone(){
        }

        public void addTelefone(string telefone){
            if(Telefones.Contains(telefone))
            {
                System.Console.WriteLine("Número já existe");
            }
            else
            {
                Telefones.Add(telefone);
            }
        }

        public void removeTelefone(string telefone){
            Telefones.Remove(telefone);
        }

        public string printTelefone(){
            StringBuilder texto = new StringBuilder();
            foreach(string tel in Telefones){
                texto.Append(tel);
            }
            return texto.ToString();
        }

        /*public void printTelefones(){
            System.Console.WriteLine(Telefones);
        }*/

    }
}