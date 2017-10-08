using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Entity.Abstract
{
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
