
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampingdoZe2.Models
{
    public class TipoProduto
    {
        public int Id { set; get; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Nome { set; get; }
    }
    }
