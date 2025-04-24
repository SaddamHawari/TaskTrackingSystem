using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.Task;
using TaskTrackingSystem.Entity;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskTrackingSystem.Properties
{
    public class TaskItemAppService : CrudAppService<
        TaskItem, TaskItemDto, Guid, PagedAndSortedResultRequestDto,
        CreateUpdateTaskItemDto, CreateUpdateTaskItemDto>, IApplicationService
    {
        public TaskItemAppService(IRepository<TaskItem, Guid> repository) : base(repository)
        {
        }
    }
}
