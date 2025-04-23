using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace TaskTrackingSystem.DTOs
{
    public class ProjectDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateUpdateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
