using CSharpFunctionalExtensions;
using L1.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.Domain.Models
{
    public class Person : AggregateRoot
    {
        protected override Result ExpireCore(DateTime expiredOn, BasicUser expiredBy)
        {
            throw new NotImplementedException();
        }

        protected override Result RestoreCore()
        {
            throw new NotImplementedException();
        }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }

    }
}
