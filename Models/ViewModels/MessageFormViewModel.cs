using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel.Models.ViewModels
{
    public class MessageFormViewModel
    {
        public Message Message { get; set; }
        public ICollection<Tipo> Tipos { get; set; }
    }
}
