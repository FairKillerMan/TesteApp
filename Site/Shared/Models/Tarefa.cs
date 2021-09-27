using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site.Shared.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
