﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecretSanta.Data;

namespace SecretSanta.Data.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20210611192724_groupkeychanges")]
    partial class groupkeychanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupsGroupId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("SecretSanta.Data.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GiverAndReceiver")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GiverUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReceiverUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AssignmentID");

                    b.HasAlternateKey("GiverAndReceiver");

                    b.HasIndex("GiverUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ReceiverUserId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("SecretSanta.Data.Gift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasAlternateKey("Title", "UserId");

                    b.ToTable("Gift");
                });

            modelBuilder.Entity("SecretSanta.Data.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GroupId");

                    b.HasAlternateKey("Name");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("SecretSanta.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasAlternateKey("FirstName", "LastName");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Luis",
                            LastName = "Garcia"
                        },
                        new
                        {
                            UserId = 2,
                            FirstName = "Jeff",
                            LastName = "Kapplan"
                        },
                        new
                        {
                            UserId = 3,
                            FirstName = "Terry",
                            LastName = "Crews"
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("SecretSanta.Data.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecretSanta.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecretSanta.Data.Assignment", b =>
                {
                    b.HasOne("SecretSanta.Data.User", "Giver")
                        .WithMany()
                        .HasForeignKey("GiverUserId");

                    b.HasOne("SecretSanta.Data.Group", null)
                        .WithMany("Assignments")
                        .HasForeignKey("GroupId");

                    b.HasOne("SecretSanta.Data.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverUserId");

                    b.Navigation("Giver");

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("SecretSanta.Data.Group", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
