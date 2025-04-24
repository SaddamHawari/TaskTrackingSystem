using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.TimeLog;
using TaskTrackingSystem.Entity;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskTrackingSystem.Properties
{
    public class TimeLogAppService : CrudAppService<
        TimeLog, TimeLogDto, Guid, PagedAndSortedResultRequestDto,
        CreateUpdateTimeLogDto, CreateUpdateTimeLogDto>, IApplicationService
    {
        public TimeLogAppService(IRepository<TimeLog, Guid> repository) : base(repository)
        {
        }
    }
}
