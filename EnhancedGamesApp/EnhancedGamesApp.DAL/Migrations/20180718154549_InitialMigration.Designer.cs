﻿// <auto-generated />
using EnhancedGamesApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnhancedGamesApp.DAL.Migrations
{
    [DbContext(typeof(EnhancedGamesAppDbContext))]
    [Migration("20180718154549_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnhancedGamesApp.DAL.Entities.Game", b =>
                {
                    b.Property<string>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("FourKConfirmed");

                    b.Property<bool>("HdrRenderingAvailable");

                    b.Property<string>("Publisher")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Key");

                    b.ToTable("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
