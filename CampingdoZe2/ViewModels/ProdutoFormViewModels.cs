using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampingdoZe2.Models;

namespace CampingdoZe2.ViewModels
{
    public class ProdutoFormViewModels
    {
        public Produto Produto { get; set; }
        public string Title
        {
            get
            {
                if (Produto != null && Produto.Id != 0)
                    return "Editar Produto";

                return "Novo produto";
            }
        }
    }
}