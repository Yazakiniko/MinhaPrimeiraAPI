using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MinhaAPI.Model
{

    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public string numero_CPF {  get; set; }
        public string nome_Completo {  get; set; }
        public string email {  get; set; }
        public int celular { get; set; }
        public string cargo { get; set; }
        public DateTime data_Cadastro { get; set; }
        public string status { get; set; } 


        public Usuario(string numero_CPF, string nome_Completo, string email, int celular, string cargo, DateTime data_Cadastro, string status)
        {
            this.numero_CPF = numero_CPF ?? throw new ArgumentNullException(nameof(numero_CPF));
            this.nome_Completo = nome_Completo ?? throw new ArgumentNullException(nameof(nome_Completo));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.celular = celular;
            this.cargo = cargo ?? throw new ArgumentNullException(nameof(cargo));
            this.data_Cadastro = data_Cadastro;
            this.status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}
