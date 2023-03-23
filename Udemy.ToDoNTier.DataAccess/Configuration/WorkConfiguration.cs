using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Entities.Domains;

namespace Udemy.ToDoNTier.DataAccess.Configuration
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Defination).HasMaxLength(300);
            builder.Property(x => x.Defination).IsRequired(true);

            builder.Property(x => x.IsCompleted).IsRequired(true);
        }
    }
}
