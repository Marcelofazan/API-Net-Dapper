using System.ComponentModel.DataAnnotations;

namespace ApiMySql.Model
{
    ///<summary>
    /// Classe pessoa que representa um registro de pessoa no banco de dados
    ///</summary>
    public class Pessoa
    {
        public int IdPessoa { get; set; }

        [Required]
        [StringLength(80)]
        public string RazaoSocial { get; set; }

        [StringLength(18)]
        public string CnpjCpf { get; set; }

        [StringLength(120)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Usuario { get; set; }

        [StringLength(12)]
        public string Senha { get; set; }

    }
}