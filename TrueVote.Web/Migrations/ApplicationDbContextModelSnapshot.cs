﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrueVote.Web.Repositories;

#nullable disable

namespace TrueVote.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrueVote.Web.Entities.ReceivedVote", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VoteOptionDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("ReceivedVotes", (string)null);
                });

            modelBuilder.Entity("TrueVote.Web.Entities.VoteOptionDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OptionKey")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("OptionKey");

                    b.ToTable("VoteOptionDetails", (string)null);
                });

            modelBuilder.Entity("TrueVote.Web.Entities.ReceivedVote", b =>
                {
                    b.HasOne("TrueVote.Web.Entities.VoteOptionDetails", "VoteOptionDetails")
                        .WithMany("ReceivedVotes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VoteOptionDetails");
                });

            modelBuilder.Entity("TrueVote.Web.Entities.VoteOptionDetails", b =>
                {
                    b.Navigation("ReceivedVotes");
                });
#pragma warning restore 612, 618
        }
    }
}
