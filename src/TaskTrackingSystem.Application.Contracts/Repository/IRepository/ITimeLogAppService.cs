using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.TimeLog;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TaskTrackingSystem.Repository.IRepository
{
    public interface ITimeLogAppService :
        ICrudAppService<TimeLogDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateTimeLogDto>
    {

    }
}
