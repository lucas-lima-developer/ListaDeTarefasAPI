﻿// <auto-generated />
using System;
using ListaDeTarefas.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListaDeTarefas.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230912181331_FixTableName")]
    partial class FixTableName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ListaDeTarefas.Domain.Entities.Tarefa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("CompletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
