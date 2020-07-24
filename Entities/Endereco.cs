namespace Atividade_III_Ex6.Entities
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }

        public Endereco(){
        }

        public Endereco(string rua, string numero, string cidade)
        {
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
        }

        public override string ToString(){
            return "Endereço: " + Rua + ", " + Numero + " - " + Cidade;
        }

    }
}