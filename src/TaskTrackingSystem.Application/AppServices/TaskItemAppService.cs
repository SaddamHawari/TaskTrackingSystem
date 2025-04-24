using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.Task;
using TaskTrackingSystem.Entity;
using TaskTrackingSystem.Repository.IRepository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskTrackingSystem.AppServices
{
    [RemoteService] // Ensure it's exposed as a remote service
    [Route("api/app/task-items")] // Updated route
    public class TaskItemAppService :
        CrudAppService<
        TaskItem,
        TaskItemDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateTaskItemDto>,
        ITaskItemAppService
    {
        public TaskItemAppService(IRepository<TaskItem, Guid> repository) : base(repository)
        {
        }

        [HttpGet("{id}")] // Explicit HTTP GET for retrieving a single task item
        public override Task<TaskItemDto> GetAsync(Guid id) => base.GetAsync(id);

        [HttpGet] // Explicit HTTP GET for retrieving a list of task items
        public override Task<PagedResultDto<TaskItemDto>> GetListAsync(PagedAndSortedResultRequestDto input) => base.GetListAsync(input);

        [HttpPost] // Explicit HTTP POST for creating a task item
        public override Task<TaskItemDto> CreateAsync(CreateUpdateTaskItemDto input) => base.CreateAsync(input);

        [HttpPut("{id}")] // Explicit HTTP PUT for updating a task item
        public override Task<TaskItemDto> UpdateAsync(Guid id, CreateUpdateTaskItemDto input) => base.UpdateAsync(id, input);

        [HttpDelete("{id}")] // Explicit HTTP DELETE for deleting a task item
        public override Task DeleteAsync(Guid id) => base.DeleteAsync(id);
    }
}
