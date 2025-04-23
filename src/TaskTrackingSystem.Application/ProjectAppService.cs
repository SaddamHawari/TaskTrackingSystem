using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs;
using TaskTrackingSystem.Entity;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskTrackingSystem
{
    public class ProjectAppService : CrudAppService<
        Project, ProjectDto, Guid, PagedAndSortedResultRequestDto,
        CreateUpdateProjectDto, CreateUpdateProjectDto>, IApplicationService
    {
        public ProjectAppService(IRepository<Project, Guid> repository) : base(repository)
        {
        }
    }
}
