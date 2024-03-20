﻿// <auto-generated />
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240318115244_spanishLecture_added")]
    partial class spanishLecture_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.SpanishLecture", b =>
                {
                    b.Property<int>("SpanishLectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpanishLectureId"), 1L, 1);

                    b.Property<string>("SpanishSubTopicContents1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpanishSubTopicContents2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpanishSubTopicId")
                        .HasColumnType("int");

                    b.Property<string>("SpanishSubTopicImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpanishSubTopicIsActive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpanishSubTopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpanishLectureId");

                    b.HasIndex("SpanishSubTopicId")
                        .IsUnique();

                    b.ToTable("SpanishLectures");
                });

            modelBuilder.Entity("EntityLayer.SpanishSubTopic", b =>
                {
                    b.Property<int>("SpanishSubTopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpanishSubTopicId"), 1L, 1);

                    b.Property<int>("SpanishTopicId")
                        .HasColumnType("int");

                    b.Property<string>("SubTopicDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTopicDescription2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTopicPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpanishSubTopicId");

                    b.HasIndex("SpanishTopicId");

                    b.ToTable("SpanishSubTopics");
                });

            modelBuilder.Entity("EntityLayer.SpanishTopic", b =>
                {
                    b.Property<int>("SpanishTopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpanishTopicId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LessonLevel")
                        .HasColumnType("int");

                    b.Property<string>("SpanishTopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpanishTopicId");

                    b.ToTable("SpanishTopics");
                });

            modelBuilder.Entity("EntityLayer.SpanishLecture", b =>
                {
                    b.HasOne("EntityLayer.SpanishSubTopic", "SpanishSubTopic")
                        .WithOne()
                        .HasForeignKey("EntityLayer.SpanishLecture", "SpanishSubTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpanishSubTopic");
                });

            modelBuilder.Entity("EntityLayer.SpanishSubTopic", b =>
                {
                    b.HasOne("EntityLayer.SpanishTopic", "SpanishTopic")
                        .WithMany("SpanishSubTopics")
                        .HasForeignKey("SpanishTopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpanishTopic");
                });

            modelBuilder.Entity("EntityLayer.SpanishTopic", b =>
                {
                    b.Navigation("SpanishSubTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
