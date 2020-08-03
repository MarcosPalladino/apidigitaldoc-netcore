using System.ComponentModel.DataAnnotations;

namespace apidigitaldoc.Models
{

    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(14, ErrorMessage = "Este campo deve conter entre 11 e 14 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve conter entre 11 e 14 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(5, ErrorMessage = "Este campo deve conter no minimo 5 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter até 60 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter entre 5 e 60 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }

}