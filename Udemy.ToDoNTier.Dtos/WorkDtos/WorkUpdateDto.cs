using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Dtos.Interfaces;

namespace Udemy.ToDoNTier.Dtos.WorkDtos
{
    public class WorkUpdateDto:IDto
    {
        [Range(1,int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
