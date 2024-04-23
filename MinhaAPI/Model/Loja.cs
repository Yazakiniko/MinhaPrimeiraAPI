using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaAPI.Model
{

    [Table("Loja")]
    public class Loja
    {
        [Key]
        public string numero_CNPJ { get; set; }
        public string razao_Social { get; set; }
        public string nome_Fantasia { get; set; }
        public DateTime dataAbertura { get; set; }
        public DateTime dataEncerrada { get; set; }
        public string status { get; set; }
        public string endereco { get; set; }
        public int telefone { get; set; }
        public string proprietario {  get; set; }


        public Loja(string numero_CNPJ, string razao_Social, string nome_Fantasia, DateTime dataAbertura, DateTime dataEncerrada, string status, string endereco, int telefone, string proprietario)
        {
            this.numero_CNPJ = numero_CNPJ ?? throw new ArgumentNullException(nameof(numero_CNPJ));
            this.razao_Social = razao_Social ?? throw new ArgumentNullException(nameof(razao_Social));
            this.nome_Fantasia = nome_Fantasia ?? throw new ArgumentNullException(nameof(nome_Fantasia));
            this.dataAbertura = dataAbertura;
            this.dataEncerrada = dataEncerrada;
            this.status = status ?? throw new ArgumentNullException(nameof(status));
            this.endereco = endereco ?? throw new ArgumentNullException( nameof(endereco));
            this.telefone = telefone;
            this.proprietario = proprietario ?? throw new ArgumentNullException(nameof(proprietario)); 

        }
    }


}
