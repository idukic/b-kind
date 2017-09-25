﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BKind.Web.Infrastructure.Persistance;
using BKind.Web.Model;

namespace BKind.Web.Migrations
{
    [DbContext(typeof(StoriesDbContext))]
    [Migration("20170923214450_StoryVotes")]
    partial class StoryVotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("BKind.Web.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Role");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Role");
                });

            modelBuilder.Entity("BKind.Web.Model.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Deleted");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Status");

                    b.Property<int>("ThumbsUp");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("BKind.Web.Model.StoryVotes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StoryId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("Voted");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("UserId");

                    b.ToTable("StoryVotes");
                });

            modelBuilder.Entity("BKind.Web.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("LastLogin");

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<DateTime>("Registered");

                    b.Property<string>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BKind.Web.Model.Administrator", b =>
                {
                    b.HasBaseType("BKind.Web.Model.Role");


                    b.ToTable("Administrator");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("BKind.Web.Model.Author", b =>
                {
                    b.HasBaseType("BKind.Web.Model.Role");


                    b.ToTable("Author");

                    b.HasDiscriminator().HasValue("Author");
                });

            modelBuilder.Entity("BKind.Web.Model.Reviewer", b =>
                {
                    b.HasBaseType("BKind.Web.Model.Role");


                    b.ToTable("Reviewer");

                    b.HasDiscriminator().HasValue("Reviewer");
                });

            modelBuilder.Entity("BKind.Web.Model.Visitor", b =>
                {
                    b.HasBaseType("BKind.Web.Model.Role");


                    b.ToTable("Visitor");

                    b.HasDiscriminator().HasValue("Visitor");
                });

            modelBuilder.Entity("BKind.Web.Model.Role", b =>
                {
                    b.HasOne("BKind.Web.Model.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BKind.Web.Model.Story", b =>
                {
                    b.HasOne("BKind.Web.Model.Author", "Author")
                        .WithMany("Stories")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BKind.Web.Model.StoryVotes", b =>
                {
                    b.HasOne("BKind.Web.Model.Story", "Story")
                        .WithMany("Votes")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BKind.Web.Model.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
