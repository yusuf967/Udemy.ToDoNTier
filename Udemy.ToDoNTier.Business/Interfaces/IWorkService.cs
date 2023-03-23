using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Dtos.WorkDtos;

namespace Udemy.ToDoNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto workCreateDto);

        Task<IDto> GetById<IDto>(int id);

        Task Remove(int id);
        Task Update (WorkUpdateDto workUpdateDto);
    }
}
