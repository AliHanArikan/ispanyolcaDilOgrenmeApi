using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : DbContext  
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<SpanishTopic> SpanishTopics { get; set; }
        public DbSet<SpanishSubTopic> SpanishSubTopics { get; set; }

        public DbSet<SpanishLecture> SpanishLectures { get; set; }

        public DbSet<SpanishExam> SpanishExams { get; set; }

        public DbSet<SpanishShortDescription> SpanishShortDescriptions { get; set; }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpanishSubTopic>()
                .HasOne(sst => sst.SpanishTopic)
                .WithMany(st => st.SpanishSubTopics)
                .HasForeignKey(sst => sst.SpanishTopicId);

            modelBuilder.Entity<SpanishLecture>()
                .HasOne(sl => sl.SpanishSubTopic)
                .WithOne()
                .HasForeignKey<SpanishLecture>(sl => sl.SpanishSubTopicId);

            modelBuilder.Entity<SpanishExam>()
            .HasOne(se => se.SpanishLecture)
            .WithMany(sl => sl.SpanishExam) // SpanishLecture sınıfında bir ICollection<SpanishExam> özelliği olmalıdır
            .HasForeignKey(se => se.SpanishLectureId);

            modelBuilder.Entity<SpanishShortDescription>()
                .HasOne(se => se.SpanishLecture)
                .WithMany(ssd => ssd.SpanishShortDescriptions)
                .HasForeignKey(se => se.SpanishLectureId);




        }

    }
}
