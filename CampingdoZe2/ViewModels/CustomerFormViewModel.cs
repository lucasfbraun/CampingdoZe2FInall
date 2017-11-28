using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampingdoZe2.Models;

namespace CampingdoZe2.ViewModels
{
    public class CustomerFormViewModel
    {

        public Customer Customer { set; get; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Editar Cliente";

                return "Novo cliente";
            }
        }
    }
}