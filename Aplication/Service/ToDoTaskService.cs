using Aplication.Dto;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entitis;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Exceptions;

namespace Aplication.Service
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IToDoTaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ToDoTaskService(IToDoTaskRepository taskRepository, IMapper mapper, ILogger<ToDoTaskService> logger)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ToDoTaskDto>> GetAllAsynch(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            _logger.LogInformation($" Get all tasks | page number: {pageNumber} | page size: {pageSize} | sort field: {sortField} | ascending: {ascending} | filter by: {filterBy}");

            var tasks = await _taskRepository.GetAllAsynch(pageNumber, pageSize, sortField, ascending, filterBy);
            return _mapper.Map<IEnumerable<ToDoTaskDto>>(tasks);
        }

        public async Task<int> GetAllCountAsynch(string filterBy)
        {
            return await _taskRepository.GetAllCountAsynch(filterBy);
        }

        public async Task<ToDoTaskDto> GetByIdAsynch(int id)
        {
            _logger.LogInformation($" Get task by id | id: {id}");

            var task = await _taskRepository.GetByIdAsynch(id);

            if (task == null)
                throw new NotFoundException("Task does not exist");

            return _mapper.Map<ToDoTaskDto>(task);
        }

        public async Task<ToDoTaskDto> AddAsynch(CreateToDoTaskDto createTaskDto)
        {
            _logger.LogInformation($" Create new task | title: {createTaskDto.Title} | description: {createTaskDto.Description} | deadline: {createTaskDto.DeadLine}");

            var newTask = _mapper.Map<ToDoTask>(createTaskDto);

            var result = await _taskRepository.AddAsynch(newTask);

            return _mapper.Map<ToDoTaskDto>(result);
        }


        public async Task UpdateAsynch(UpdateToDoTaskDto updateTaskDto)
        {
            _logger.LogInformation($" Update existing task | id: {updateTaskDto.Id} | title: {updateTaskDto.Title} | description: {updateTaskDto.Title} | deadline: {updateTaskDto.DeadLine}");

            var existingTask = await _taskRepository.GetByIdAsynch(updateTaskDto.Id);

            if(existingTask == null)
                throw new NotFoundException("Task does not exist");

            var task = _mapper.Map(updateTaskDto, existingTask);

            await _taskRepository.UpdateAsynch(task);
        }

        public async Task DeleteAsynch(int id)
        {
            _logger.LogInformation($" Delete existing task | id: {id}");

            var task = await _taskRepository.GetByIdAsynch(id);

            if (task == null)
                throw new NotFoundException("Task does not exist");

            await _taskRepository.DeleteAsynch(task);
        }
    }
}
