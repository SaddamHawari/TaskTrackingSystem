using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.Project;
using TaskTrackingSystem.Entity;
using TaskTrackingSystem.Permissions;
using TaskTrackingSystem.Repository.IRepository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace TaskTrackingSystem.AppServices
{
    [Authorize(TaskTrackingSystemPermissions.Projects.Default)]
    public class ProjectAppService : ApplicationService, ITransientDependency
    {
        private readonly IRepository<Project, Guid> _projectRepository;
        private readonly IGuidGenerator _guidGenerator;


        public ProjectAppService(IRepository<Project, Guid> projectRepository, IGuidGenerator guidGenerator)
        {
            _projectRepository = projectRepository;
            _guidGenerator = guidGenerator;
        }

        [Authorize(TaskTrackingSystemPermissions.Projects.Create)]
        [HttpPost("api/projects")]
        public async Task<ProjectDto> CreateAsync(CreateUpdateProjectDto input)
        {
            try
            {
                var newProject = new Project
                {
                    Name = input.Name,
                    Description = input.Description,
                    CreatorId = CurrentUser.Id, // Assuming the current user is the creator
                    StartDate = input.StartDate,
                    EndDate = input.EndDate,
                    Status = input.Status
                };

                await _projectRepository.InsertAsync(newProject);

                return ObjectMapper.Map<Project, ProjectDto>(newProject);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Project could not be created.");
                throw new UserFriendlyException("An error occurred while creating the project.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Projects.Default)]
        [HttpGet("api/projects")]
        public async Task<List<ProjectDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input, [FromQuery] string? filter = null)
        {
            try
            {
                var projectQueryable = await _projectRepository.GetQueryableAsync();

                // Apply general filter (Name or Description)
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    projectQueryable = projectQueryable.Where(p =>
                        p.Name.Contains(filter) ||
                        p.Description.Contains(filter));
                }

                // Apply pagination
                var projects = await projectQueryable
                    .OrderBy(p => p.Name) // Optional: Order by Name
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
                    .ToListAsync();

                return ObjectMapper.Map<List<Project>, List<ProjectDto>>(projects);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while retrieving the projects.");
                throw new UserFriendlyException("An error occurred while retrieving the projects.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Projects.Default)]
        [HttpGet("api/projects/{id}")]
        public async Task<ProjectDto> GetAsync(Guid id)
        {
            try
            {
                var project = await _projectRepository.GetAsync(id);

                if (project == null)
                {
                    throw new UserFriendlyException("Project not found.");
                }

                return ObjectMapper.Map<Project, ProjectDto>(project);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while retrieving the project.");
                throw new UserFriendlyException("An error occurred while retrieving the project.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Projects.Update)]
        [HttpPut("api/projects/{id}")]
        public async Task<ProjectDto> UpdateAsync(Guid id, CreateUpdateProjectDto input)
        {
            try
            {
                var existingProject = await _projectRepository.GetAsync(id);

                existingProject.Name = input.Name;
                existingProject.Description = input.Description;
                existingProject.StartDate = input.StartDate;
                existingProject.EndDate = input.EndDate;
                existingProject.Status = input.Status;

                await _projectRepository.UpdateAsync(existingProject);

                return ObjectMapper.Map<Project, ProjectDto>(existingProject);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while updating the project.");
                throw new UserFriendlyException("An error occurred while updating the project.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Projects.Delete)]
        [HttpDelete("api/projects/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var existingProject = await _projectRepository.GetAsync(id);
                if (existingProject == null)
                {
                    throw new UserFriendlyException("Project not found.");
                }
                await _projectRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while deleting the project.");
                throw new UserFriendlyException("An error occurred while deleting the project.");
            }
        }
    }
}
}
