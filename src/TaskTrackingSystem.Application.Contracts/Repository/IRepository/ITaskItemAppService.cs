using System;
using TaskTrackingSystem.DTOs.Task;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TaskTrackingSystem.Repository.IRepository
{
    public interface ITaskItemAppService :
        ICrudAppService<TaskItemDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateTaskItemDto>
    {

    }
}
