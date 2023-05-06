using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Models.Configurations
{
    class ReportActionConfig
    : IEntityTypeConfiguration<ReportAction>
    {
        public void Configure(EntityTypeBuilder<ReportAction> builder)
        {

        }
    }
}
