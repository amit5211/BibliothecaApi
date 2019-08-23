using Bibliotheca1.Entity_Data_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheca.Repository
{
    public class AuthorRepository
    {
        //bibliotheca.Model.Author author = new bibliotheca.Model.Author();
        BibliothecaEntities context = new BibliothecaEntities();
        Author entityAuthor = new Author();
        public bibliotheca.Model.Author SaveAuthor(bibliotheca.Model.Author author)
        {
            entityAuthor.FirstName = author.firstName;
            entityAuthor.LastName = author.lastName;
            entityAuthor.DOB = author.dob;
            entityAuthor.AuthorDescription = author.description;

            context.Authors.Add(entityAuthor);
            context.SaveChanges();

            try
            {
                // var data = _context.Authors.SqlQuery("Select AuthorId from Author where FirstName=" + author.firstName).FirstOrDefault<Entity_Model.Author>();
                //  var data = _context.Authors.Select(row => row);
                var data = context.Authors.Where(p => p.FirstName == author.firstName && p.LastName == author.lastName)
                                       .Select(p => p.AuthorId);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        author.authorId = item;
                    }
                }
            }
            catch
            {
                author.authorId = 0;
            }

            return author;
        }

        public List<bibliotheca.Model.Author> getAuthor()
        {
            var data = (from Author in context.Authors
                        select new bibliotheca.Model.Author
                        {
                            authorId = Author.AuthorId,
                            firstName = Author.FirstName,
                            lastName = Author.LastName
                        }).ToList<bibliotheca.Model.Author>();
            return data;
        }
    }
}