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

            optionsBuilder.UseSqlServer("");
        }

        public DbSet<SpanishTopic> SpanishTopics { get; set; }
        public DbSet<SpanishSubTopic> SpanishSubTopics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpanishSubTopic>()
                .HasOne(sst => sst.SpanishTopic)
                .WithMany(st => st.SpanishSubTopics)
                .HasForeignKey(sst => sst.SpanishTopicId);


        }

    }
}
