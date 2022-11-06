using Lib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FormsServer.Entities;

namespace FormsServer.MyDbContext
{
    public class DbChat:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MyMessage> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbChat()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                           Database=DbChat.db;Trusted_Connection=True;");
        }
    }
}
