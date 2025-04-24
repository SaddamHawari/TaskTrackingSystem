using AutoMapper;
using TaskTrackingSystem.DTOs.Project;
using TaskTrackingSystem.DTOs.Task;
using TaskTrackingSystem.DTOs.TimeLog;
using TaskTrackingSystem.Entity;

namespace TaskTrackingSystem;

public class TaskTrackingSystemApplicationAutoMapperProfile : Profile
{
    public TaskTrackingSystemApplicationAutoMapperProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<CreateUpdateProjectDto, Project>();

        CreateMap<TaskItem, TaskItemDto>();
        CreateMap<CreateUpdateTaskItemDto, TaskItem>();

        CreateMap<TimeLog, TimeLogDto>();
        CreateMap<CreateUpdateTimeLogDto, TimeLog>();
    }
}
