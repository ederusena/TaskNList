using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNList.Models;

namespace TaskNList.EntityConfigs
{
  public class TodoEntityConfig : IEntityTypeConfiguration<Todo>
  {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todo");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(t => t.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Date)
                .HasColumnName("Date")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(t => t.IsCompleted)
                .HasColumnName("IsCompleted")
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);
    }
  }
}