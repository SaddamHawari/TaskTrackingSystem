using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.Report;
using TaskTrackingSystem.Entity;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using TaskTrackingSystem.Permissions;

namespace TaskTrackingSystem.AppServices
{
    [Authorize(TaskTrackingSystemPermissions.Reporting.Default)]
    public class ReportingAppService : ApplicationService
    {
        private readonly IRepository<TimeLog, Guid> _timeLogRepository;

        public ReportingAppService(IRepository<TimeLog, Guid> timeLogRepository)
        {
            _timeLogRepository = timeLogRepository;
        }

        [Authorize(TaskTrackingSystemPermissions.Reporting.View)]
        [HttpGet("api/reports/get-total-hours")]
        public async Task<List<ReportDto>> GetTotalHoursAsync(ReportFilterDto filter)
        {
            try
            {
                var queryable = await _timeLogRepository.GetQueryableAsync(); // Get IQueryable<TimeLog>

                var query = queryable
                    .WhereIf(filter.ProjectId.HasValue, t => t.TaskItem.ProjectId == filter.ProjectId)
                    .WhereIf(filter.UserId.HasValue, t => t.UserId == filter.UserId)
                    .WhereIf(filter.TaskId.HasValue, t => t.TaskItemId == filter.TaskId)
                    .WhereIf(filter.StartDate.HasValue, t => t.LogDate >= filter.StartDate)
                    .WhereIf(filter.EndDate.HasValue, t => t.LogDate <= filter.EndDate);

                var result = await query
                    .GroupBy(t => new { t.TaskItem.ProjectId, t.UserId, t.TaskItemId })
                    .Select(g => new ReportDto
                    {
                        ProjectId = g.Key.ProjectId,
                        UserId = g.Key.UserId,
                        TaskId = g.Key.TaskItemId,
                        TotalHours = g.Sum(t => (double)t.HoursWorked)
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while generating the report.");
                throw new UserFriendlyException("An error occurred while generating the report.");
            }
        }
    }
}
