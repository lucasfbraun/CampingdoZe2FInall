﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampingdoZe2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
    }
}