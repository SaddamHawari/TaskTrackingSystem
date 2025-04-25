using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.Task;
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
    [Authorize(TaskTrackingSystemPermissions.Tasks.Default)]
    public class TaskItemsAppService : ApplicationService, ITransientDependency
    {
        private readonly IRepository<TaskItem, Guid> _taskItemRepository;
        private readonly IGuidGenerator _guidGenerator;

        public TaskItemsAppService(IRepository<TaskItem, Guid> taskItemRepository, IGuidGenerator guidGenerator)
        {
            _taskItemRepository = taskItemRepository;
            _guidGenerator = guidGenerator;
        }

        [Authorize(TaskTrackingSystemPermissions.Tasks.Create)]
        [HttpPost("api/task-items")]
        public async Task<TaskItemDto> CreateAsync(CreateUpdateTaskItemDto input)
        {
            try
            {
                // Create a new TaskItem instance using the constructor or initializer
                var newTaskItem = Activator.CreateInstance<TaskItem>();

                // Set properties individually since the Id property is read-only
                newTaskItem.Title = input.Title;
                newTaskItem.Description = input.Description;
                newTaskItem.ProjectId = input.ProjectId;
                newTaskItem.AssignedToUserId = input.AssignedUserId;
                newTaskItem.DueDate = input.DueDate;
                newTaskItem.Priority = Enum.Parse<TaskPriority>(input.Priority);
                newTaskItem.Status = Enum.Parse<TaskStatus>(input.Status);

                // Use reflection or a helper method to set the Id property if necessary
                typeof(TaskItem).GetProperty("Id")?.SetValue(newTaskItem, _guidGenerator.Create());

                await _taskItemRepository.InsertAsync(newTaskItem);

                return ObjectMapper.Map<TaskItem, TaskItemDto>(newTaskItem);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while creating the task item.");
                throw new UserFriendlyException("An error occurred while creating the task item.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Tasks.Default)]
        [HttpGet("api/task-items")]
        public async Task<List<TaskItemDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input, [FromQuery] string? filter = null)
        {
            try
            {
                var taskItemQueryable = await _taskItemRepository.GetQueryableAsync();

                // Apply general filter (Title or Description)
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    taskItemQueryable = taskItemQueryable.Where(t =>
                        t.Title.Contains(filter) ||
                        t.Description.Contains(filter));
                }

                // Apply pagination
                var taskItems = await taskItemQueryable
                    .OrderBy(t => t.Title) // Optional: Order by Title
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
                    .ToListAsync();

                return ObjectMapper.Map<List<TaskItem>, List<TaskItemDto>>(taskItems);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while retrieving the task items.");
                throw new UserFriendlyException("An error occurred while retrieving the task items.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Tasks.Default)]
        [HttpGet("api/task-items/{id}")]
        public async Task<TaskItemDto> GetAsync(Guid id)
        {
            try
            {
                var taskItem = await _taskItemRepository.GetAsync(id);

                if (taskItem == null)
                {
                    throw new UserFriendlyException("Task item not found.");
                }

                return ObjectMapper.Map<TaskItem, TaskItemDto>(taskItem);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while retrieving the task item.");
                throw new UserFriendlyException("An error occurred while retrieving the task item.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Tasks.Update)]
        [HttpPut("api/task-items/{id}")]
        public async Task<TaskItemDto> UpdateAsync(Guid id, CreateUpdateTaskItemDto input)
        {
            try
            {
                var existingTaskItem = await _taskItemRepository.GetAsync(id);

                existingTaskItem.Title = input.Title;
                existingTaskItem.Description = input.Description;
                existingTaskItem.ProjectId = input.ProjectId;
                existingTaskItem.AssignedToUserId = input.AssignedUserId;
                existingTaskItem.DueDate = input.DueDate;
                existingTaskItem.Priority = Enum.Parse<TaskPriority>(input.Priority);
                existingTaskItem.Status = Enum.Parse<TaskStatus>(input.Status);

                await _taskItemRepository.UpdateAsync(existingTaskItem);

                return ObjectMapper.Map<TaskItem, TaskItemDto>(existingTaskItem);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while updating the task item.");
                throw new UserFriendlyException("An error occurred while updating the task item.");
            }
        }

        [Authorize(TaskTrackingSystemPermissions.Tasks.Delete)]
        [HttpDelete("api/task-items/{id}")]
        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var taskItem = await _taskItemRepository.GetAsync(id);
                if (taskItem == null)
                {
                    throw new UserFriendlyException("Task item not found.");
                }
                await _taskItemRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while deleting the task item.");
                throw new UserFriendlyException("An error occurred while deleting the task item.");
            }
        }
    }
}
}
