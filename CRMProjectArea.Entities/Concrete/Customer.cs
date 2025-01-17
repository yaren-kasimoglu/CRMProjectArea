﻿using CRMProjectArea.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Phone { get; set; }

        public string? Adress { get; set; }

    }
}
