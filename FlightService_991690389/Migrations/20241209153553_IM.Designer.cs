﻿// <auto-generated />
using FlightService_991690389.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightService_991690389.Migrations
{
    [DbContext(typeof(FlightContext))]
    [Migration("20241209153553_IM")]
    partial class IM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("FlightService_991690389.Model.Flight", b =>
                {
                    b.Property<int>("flightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("flightId");

                    b.ToTable("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}