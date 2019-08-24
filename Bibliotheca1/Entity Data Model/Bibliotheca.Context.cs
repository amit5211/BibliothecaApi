﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bibliotheca1.Entity_Data_Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BibliothecaEntities : DbContext
    {
        public BibliothecaEntities()
            : base("name=BibliothecaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<BookPublisher> BookPublishers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
    
        public virtual ObjectResult<AuhtorSearch_Result> AuhtorSearch(string searchFileter)
        {
            var searchFileterParameter = searchFileter != null ?
                new ObjectParameter("searchFileter", searchFileter) :
                new ObjectParameter("searchFileter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AuhtorSearch_Result>("AuhtorSearch", searchFileterParameter);
        }
    
        public virtual ObjectResult<GenreSearch_Result> GenreSearch(string searchFileter)
        {
            var searchFileterParameter = searchFileter != null ?
                new ObjectParameter("searchFileter", searchFileter) :
                new ObjectParameter("searchFileter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GenreSearch_Result>("GenreSearch", searchFileterParameter);
        }
    
        public virtual ObjectResult<ProcSelectAllBook_Result> ProcSelectAllBook()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProcSelectAllBook_Result>("ProcSelectAllBook");
        }
    }
}
