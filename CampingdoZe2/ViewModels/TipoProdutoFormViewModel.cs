using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampingdoZe2.Models;

namespace CampingdoZe2.ViewModels
{
    public class TipoProdutoFormViewModel
    {
        public TipoProduto TipoProduto { set; get; }
        public string Title
        {
            get
            {
                if (TipoProduto != null && TipoProduto.Id != 0)
                    return "Editar O tipo do produto";

                return "Novo tipo de produto";
            }
        }
    }
}
