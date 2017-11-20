using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampingdoZe2.Models;

namespace CampingdoZe2.ViewModels
{
    public class CustomerFormViewModel
    {

        public Customer Customers { set; get; }
        public string Title
        {
            get
            {
                if (Customers != null && Customers.Id != 0)
                    return "Editar Cliente";

                return "Novo cliente";
            }
        }
    }
}
