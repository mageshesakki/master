using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.IO;

namespace GlobussoftTechnologies.ChatlistUIModule.Model
{
    public class ChatDBContext : DbContext
    {
        #region Constructor
        public ChatDBContext()
        {
            var dbExists = DatabaseExists();
            if (!dbExists)
            {
                Database.EnsureCreated();

            }
        }

        #endregion Constructor

        #region Public Property

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CurrentUser> CurrentUser { get; set; }

        #endregion Public Property

        #region Public Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Database\\ChatApp.db";
            optionbuilder.UseSqlite("Data Source="+ projectDirectory);
        }

        private bool DatabaseExists()
        {
            return (this.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();
        }

        #endregion Public Methods

    }
}
