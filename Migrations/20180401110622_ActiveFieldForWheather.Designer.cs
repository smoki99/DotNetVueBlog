﻿// <auto-generated />
using DotNetVueBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DotNetVueBlog.Migrations
{
    [DbContext(typeof(WheatherContext))]
    [Migration("20180401110622_ActiveFieldForWheather")]
    partial class ActiveFieldForWheather
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("DotNetVueBlog.Models.Wheather", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFormatted");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Summary");

                    b.Property<int>("TemperatureC");

                    b.HasKey("ID");

                    b.ToTable("Wheather");
                });
#pragma warning restore 612, 618
        }
    }
}
