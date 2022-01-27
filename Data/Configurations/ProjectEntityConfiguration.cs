﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Summary).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.IsDeleted).HasDefaultValueSql("true");
        }
    }
}
