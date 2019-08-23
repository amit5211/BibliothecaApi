using Bibliotheca1.Entity_Data_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bibliotheca1.Repository
{
    
    public class GenreRepository
    {
        //bibliotheca.Model.Genre genre = new bibliotheca.Model.Genre();
        BibliothecaEntities context = new BibliothecaEntities();
        Genre entityGenre = new Genre();
        
        public bibliotheca.Model.Genre SaveGenre(bibliotheca.Model.Genre genre)
        {
            entityGenre.Genre1 = genre.genre;
            context.Genres.Add(entityGenre);

            context.SaveChanges();

            try
            {
                //var data = _context.Genres.SqlQuery("Select GenreId from Genre where GenreName=" + genre.genreName).FirstOrDefault<Entity_Model.Genre>();
                var data = context.Genres.Where(p => p.Genre1 == genre.genre)
                                       .Select(p => p.GenreID);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        genre.genreId = item;
                    }
                }
            }
            catch
            {
                genre.genreId = 0;

            }

            return genre;
        }

        public List<bibliotheca.Model.Genre> getGenre()
        {
            var data = (from Genre in context.Genres
                        select new bibliotheca.Model.Genre
                        {
                            genreId = Genre.GenreID,
                            genre = Genre.Genre1
                        }).ToList<bibliotheca.Model.Genre>();
            return data;
        }
    }
}