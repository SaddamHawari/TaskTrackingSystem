using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.Project;
using TaskTrackingSystem.Entity;
using TaskTrackingSystem.Repository.IRepository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskTrackingSystem.AppServices
{
    [RemoteService] // Disable remote service to avoid route conflicts
    [Route("api/app/projects")] // Updated route
    public class ProjectAppService : CrudAppService<
        Project,
        ProjectDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateProjectDto>,
        IProjectAppService
    {
        public ProjectAppService(IRepository<Project, Guid> repository) : base(repository)
        {
        }

        [HttpGet("{id}")] // Explicit HTTP GET for retrieving a single project
        public override Task<ProjectDto> GetAsync(Guid id) => base.GetAsync(id);

        [HttpGet] // Explicit HTTP GET for retrieving a list of projects
        public override Task<PagedResultDto<ProjectDto>> GetListAsync(PagedAndSortedResultRequestDto input) => base.GetListAsync(input);

        [HttpPost] // Explicit HTTP POST for creating a project
        public override Task<ProjectDto> CreateAsync(CreateUpdateProjectDto input) => base.CreateAsync(input);

        [HttpPut("{id}")] // Explicit HTTP PUT for updating a project
        public override Task<ProjectDto> UpdateAsync(Guid id, CreateUpdateProjectDto input) => base.UpdateAsync(id, input);

        [HttpDelete("{id}")] // Explicit HTTP DELETE for deleting a project
        public override Task DeleteAsync(Guid id) => base.DeleteAsync(id);
    }
}
