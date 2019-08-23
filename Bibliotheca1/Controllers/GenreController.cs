using bibliotheca.Model;
using Bibliotheca1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bibliotheca1.Controllers
{
    [RoutePrefix("api/Genre")]
    public class GenreController : ApiController
    {
        GenreRepository genreRepository = new GenreRepository();
        ResponseObj responseObj = new ResponseObj();
        
        [HttpPost]
        [Route("SaveGenre")]
        public ResponseObj SaveGenre(Genre genre)
        {
            var result = genreRepository.SaveGenre(genre);

            if (result.genreId != 0)
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
        [Route("GetGenre")]
        public List<Genre> GetGenre()
        {
            var result = genreRepository.getGenre();
            return result;
        }
    }
}
