using bibliotheca.Model;
using Bibliotheca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bibliotheca.Controllers
{
    [RoutePrefix("api/Author")]
    public class AuthorController : ApiController
    {
        ResponseObj responseObj = new ResponseObj();
        AuthorRepository authorRepository = new AuthorRepository();

        [HttpPost]
        [Route("SaveAuthor")]
        public ResponseObj SaveAuthor(Author author)
        {
            var result = authorRepository.SaveAuthor(author);
            if (result.authorId != 0)
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

        [HttpGet]
        [Route("GetAuthor")]
        public List<Author> GetAuthor()
        {
            var result = authorRepository.getAuthor();
            return result;
        }
    }
}
