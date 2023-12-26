using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdminPanel.Models.Enums;

namespace AdminPanel.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Mensagem")]
        [StringLength(140, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Mensagem { get; set; }
        
        public Tipo Tipo { get; set; }

        [Display(Name = "Tipo")]
        public int TipoId { get; set; }

        public Message() { }

        public Message(int id, string name, string email, string mensagem, Tipo tipo)
        {
            Id = id;
            Name = name;
            Email = email;
            Mensagem = mensagem;
            Tipo = tipo;
        }

       
    }
}
