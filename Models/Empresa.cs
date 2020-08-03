using System.ComponentModel.DataAnnotations;

namespace apidigitaldoc.Models
{

    public class Empresa
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(18, ErrorMessage = "Este campo deve conter entre 14 e 18 caracteres")]
        [MinLength(14, ErrorMessage = "Este campo deve conter entre 14 e 18 caracteres")]
        public string CNPJ { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }   

    }

}