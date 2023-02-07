﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDoAppASP.NETReact.Models
{
    public partial class ToDoAppContext : DbContext
    {
        public ToDoAppContext()
        {
        }

        public ToDoAppContext(DbContextOptions<ToDoAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tarea> Tareas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local); DataBase=ToDoApp;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK__Tarea__EADE9098FED5FA6B");

                entity.ToTable("Tarea");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
