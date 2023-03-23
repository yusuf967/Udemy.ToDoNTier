using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.ToDoNTier.Entities.Domains
{
    public class Work:BaseEntity
    {
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
