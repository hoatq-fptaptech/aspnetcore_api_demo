using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Entities;

public partial class T2203eContext : DbContext
{
    public T2203eContext()
    {
        //Scaffold - DbContext "\connection string"
        // Microsoft.EntityFrameworkCore.SqlServer - OutputDir Entities - Force

        //dotnet ef dbcontext scaffold "connection string"
        // Microsoft.EntityFrameworkCore.SqlServer --output-dir=Entities --force
    }

    public T2203eContext(DbContextOptions<T2203eContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433; Database=T2203E;User Id=sa;Password=sa123456;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Thumbnail).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
