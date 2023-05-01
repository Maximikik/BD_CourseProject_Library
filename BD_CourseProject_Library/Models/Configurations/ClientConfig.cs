﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BD_CourseProject_Library.Models.Configurations
{
    public class ClientConfig
    : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasIndex(entity => entity.PhoneNumber).IsUnique();
        }
    }
}
