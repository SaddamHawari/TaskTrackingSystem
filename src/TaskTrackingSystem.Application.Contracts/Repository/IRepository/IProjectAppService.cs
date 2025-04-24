using System;
using TaskTrackingSystem.DTOs.Project;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services; 

namespace TaskTrackingSystem.Repository.IRepository
{
    public interface IProjectAppService:
        ICrudAppService<
            ProjectDto, 
            Guid, 
            PagedAndSortedResultRequestDto, 
            CreateUpdateProjectDto>
    {

    }
}
