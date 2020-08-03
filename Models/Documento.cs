using System.ComponentModel.DataAnnotations;
using System;

namespace apidigitaldoc.Models
{

    public class Documento
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(250, ErrorMessage = "Este campo deve conter entre 3 e 250 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 250 caracteres")]

        public string UrlDocumento { get; set; }

        public int UsuarioId{ get; set; }

        public Usuario Usuario{ get; set; }
        
    }

}