﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiSubscribe.Contexts;

#nullable disable

namespace WebApiSubscribe.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240410125558_Subscriber Added")]
    partial class SubscriberAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.SubscribeEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AdvertisingUpdates")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DailyNewsletter")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EventUpdates")
                        .HasColumnType("bit");

                    b.Property<bool>("Podcasts")
                        .HasColumnType("bit");

                    b.Property<bool>("StartupWeekly")
                        .HasColumnType("bit");

                    b.Property<bool>("WeekinReview")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });
#pragma warning restore 612, 618
        }
    }
}
