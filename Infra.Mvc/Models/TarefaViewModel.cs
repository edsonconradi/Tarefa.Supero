using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infra.Mvc.Models
{
    public class TarefaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Hora { get; set; }
        public string Data { get; set; }
        public bool Concluida { get; set; }
        public string Responsavel { get; set; }
    }
}