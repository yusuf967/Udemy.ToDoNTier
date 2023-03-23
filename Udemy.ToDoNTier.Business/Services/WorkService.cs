
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Business.Interfaces;
using Udemy.ToDoNTier.DataAccess.UnitOfWork;
using Udemy.ToDoNTier.Dtos.Interfaces;
using Udemy.ToDoNTier.Dtos.WorkDtos;
using Udemy.ToDoNTier.Entities.Domains;

namespace Udemy.ToDoNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public WorkService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(WorkCreateDto workCreateDto)
        {
            await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(workCreateDto));
            await _uow.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            //var list = await _uow.GetRepository<Work>().GetAll();
            //var workList = new List<WorkListDto>();
            //if (list != null && list.Count > 0)
            //{
            //    foreach (var work in list)
            //    {
            //        workList.Add(new()
            //        {
            //            Id = work.Id,
            //            Defination = work.Defination,
            //            IsCompleted = work.IsCompleted,
            //        });
            //    }
            //}
            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetFilter(x => x.Id == id));
        }

        public async Task Remove(int id)
        {
            _uow.GetRepository<Work>().Remove(id);

            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto workUpdateDto)
        {
            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto));
            await _uow.SaveChanges();
        }
    }
}
