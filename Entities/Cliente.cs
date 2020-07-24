namespace Atividade_III_Ex6.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
        public double[] GastoMensal { get; set; } = new double[12];

        public Cliente()
        {
        }

        public Cliente(int id, string nome, string email, Endereco endereco, Telefone telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
        }

        public override string ToString(){
            return Id + ", " + Nome + ", " + Email + ", " + Endereco + ", ";
        }
        
    }
}