using Bibliotheca1.Entity_Data_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace bibliotheca.Repository
{
    public class BookRepository
    {
        BibliothecaEntities context = new BibliothecaEntities();
        Book entityBook = new Book();
        BookAuthor entityBookAuthor = new BookAuthor();
        BookGenre entityBookGenre = new BookGenre();
        BookPublisher entityBookPublisher = new BookPublisher();
        public bibliotheca.Model.Book SaveBook(bibliotheca.Model.Book book)
        {
            using (DbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    entityBook.Title = book.title;
                    entityBook.Language = book.language;
                    entityBook.Price = book.price;
                    entityBook.ISBN = book.ISBN;
                    entityBook.FirstPublish = book.firstPublish;
                    entityBook.Pages = book.pages;
                    entityBook.Path = book.path;

                    context.Books.Add(entityBook);
                    context.SaveChanges();

                    //var data = _context.Genres.SqlQuery("Select GenreId from Genre where GenreName=" + genre.genreName).FirstOrDefault<Entity_Model.Genre>();
                    var data = context.Books.Where(p => p.Title == book.title)
                                           .Select(p => p.BookId);
                    if (data != null)
                    {
                        foreach (var item in data)
                        {
                            book.bookId = item;
                        }

                        //BookAuthor Table
                        if (book.writtenBy != null)
                        {
                            foreach (var item in book.writtenBy)
                            {
                                entityBookAuthor.BookId = book.bookId;
                                entityBookAuthor.BookAuthorId = item.id;
                                context.BookAuthors.Add(entityBookAuthor);
                                context.SaveChanges();
                            }
                        }

                        //BookGenre Table
                        if (book.genre != null)
                        {
                            foreach (var item in book.genre)
                            {
                                entityBookGenre.BookId = book.bookId;
                                entityBookGenre.BookGenreId = item.id;
                                context.BookGenres.Add(entityBookGenre);
                                context.SaveChanges();
                            }
                        }
                       
                        //BookPublisher Table
                        if(book.publisher != null)
                        {
                            foreach (var item in book.publisher)
                            {
                                entityBookPublisher.BookId = book.bookId;
                                entityBookPublisher.BookPublisherId = item.id;
                                context.BookPublishers.Add(entityBookPublisher);
                                context.SaveChanges();
                            }
                        }
                        
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                        book.bookId = 0;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    book.bookId = 0;
                }
            }
            return book;
        }
    }
}
