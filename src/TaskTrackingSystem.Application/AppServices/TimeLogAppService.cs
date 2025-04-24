using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackingSystem.DTOs.TimeLog;
using TaskTrackingSystem.Entity;
using TaskTrackingSystem.Repository.IRepository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TaskTrackingSystem.AppServices
{
    [RemoteService] // Disable remote service to avoid route conflicts
    [Route("api/app/time-logs")] // Updated route
    public class TimeLogAppService :
        CrudAppService<
        TimeLog,
        TimeLogDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateTimeLogDto>,
        ITimeLogAppService
    {
        public TimeLogAppService(IRepository<TimeLog, Guid> repository) : base(repository)
        {
        }

        [HttpGet("{id}")] // Explicit HTTP GET for retrieving a single time log
        public override Task<TimeLogDto> GetAsync(Guid id) => base.GetAsync(id);

        [HttpGet] // Explicit HTTP GET for retrieving a list of time logs
        public override Task<PagedResultDto<TimeLogDto>> GetListAsync(PagedAndSortedResultRequestDto input) => base.GetListAsync(input);

        [HttpPost] // Explicit HTTP POST for creating a time log
        public override Task<TimeLogDto> CreateAsync(CreateUpdateTimeLogDto input) => base.CreateAsync(input);

        [HttpPut("{id}")] // Explicit HTTP PUT for updating a time log
        public override Task<TimeLogDto> UpdateAsync(Guid id, CreateUpdateTimeLogDto input) => base.UpdateAsync(id, input);

        [HttpDelete("{id}")] // Explicit HTTP DELETE for deleting a time log
        public override Task DeleteAsync(Guid id) => base.DeleteAsync(id);
    }
}
