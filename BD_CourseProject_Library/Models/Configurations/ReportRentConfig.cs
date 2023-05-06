using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_CourseProject_Library.Models.Configurations
{
    class ReportRentConfig
    : IEntityTypeConfiguration<ReportRent>
    {
        public void Configure(EntityTypeBuilder<ReportRent> builder)
        {

         }
    }
}
