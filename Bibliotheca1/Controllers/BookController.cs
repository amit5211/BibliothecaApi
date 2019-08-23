using bibliotheca.Model;
using bibliotheca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bibliotheca1.Controllers
{
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {
        BookRepository bookRepository = new BookRepository();
        ResponseObj responseObj = new ResponseObj();

        [HttpPost]
        [Route("SaveBook")]
        public ResponseObj SaveBook(Book book)
        {
            var result = bookRepository.SaveBook(book);

            if (result.bookId != 0)
            {
                responseObj.data = result;
                responseObj.response = "successful";
                return responseObj;
            }
            else
            {
                responseObj.response = "warning";
                responseObj.message = "operation Failed";
                return responseObj;
            }
        }
    }
}
