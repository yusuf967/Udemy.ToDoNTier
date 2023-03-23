
using AutoMapper;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Business.Interfaces;
using Udemy.ToDoNTier.Business.ValidationRules;
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
        private readonly IValidator<WorkCreateDto> createDtoValidator;
        private readonly IValidator<WorkUpdateDto> updateDtoValidator;
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator = null, IValidator<WorkUpdateDto> updateDtoValidator = null)
        {
            _uow = uow;
            _mapper = mapper;
            this.createDtoValidator = createDtoValidator;
            this.updateDtoValidator = updateDtoValidator;
        }

        public async Task Create(WorkCreateDto workCreateDto)
        {
            var validationResult = createDtoValidator.Validate(workCreateDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(workCreateDto));
                await _uow.SaveChanges();
            }

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
            var deletedEntity = await _uow.GetRepository<Work>().GetFilter(x => x.Id == id);
            if (deletedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(deletedEntity);
                await _uow.SaveChanges();
            }
        }

        public async Task Update(WorkUpdateDto workUpdateDto)
        {
            var validationResult = updateDtoValidator.Validate(workUpdateDto);
            if (validationResult.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(workUpdateDto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto), updatedEntity);
                    await _uow.SaveChanges();
                }
            }
        }
    }
}
