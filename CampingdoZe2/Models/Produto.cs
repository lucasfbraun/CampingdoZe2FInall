using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampingdoZe2.Models
{
   
    public class Produto
    {
         
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Quantidade{ get; set; }

        public double Valor { get; set; }


    }
}