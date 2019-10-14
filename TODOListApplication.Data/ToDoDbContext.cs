using System.Collections.Generic;
using TODOListApplication.Data.DbModel;

namespace TODOListApplication.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ToDoDbContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TODOListApplication.Data.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public ToDoDbContext()
            : base("data source=sql5045.site4now.net;initial catalog=DB_A4EB2E_todolist;persist security info=True;user id=DB_A4EB2E_todolist_admin;password=todolist!12345;MultipleActiveResultSets=True;App=EntityFramework")
        {
           // Database.SetInitializer(new SchoolDBInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<ToDo> Todo { get; set; }

        public virtual DbSet<ToDoTask> TodoTask { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}