﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.UI.Data;

namespace Web.UI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Web.UI.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionMain")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("TEXT");

                    b.HasKey("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("Web.UI.Models.ExamResult", b =>
                {
                    b.Property<int>("ExamResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Puan")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamResultId");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamResult");
                });

            modelBuilder.Entity("Web.UI.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ExamId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MarkA")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkB")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkC")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkD")
                        .HasColumnType("TEXT");

                    b.HasKey("QuestionId");

                    b.HasIndex("ExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Web.UI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Passwword")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Web.UI.Models.Exam", b =>
                {
                    b.HasOne("Web.UI.Models.User", "User")
                        .WithMany("Exams")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web.UI.Models.ExamResult", b =>
                {
                    b.HasOne("Web.UI.Models.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Web.UI.Models.Question", b =>
                {
                    b.HasOne("Web.UI.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Web.UI.Models.Exam", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Web.UI.Models.User", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
