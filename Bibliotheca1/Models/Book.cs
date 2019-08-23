using bibliotheca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bibliotheca.Model
{
    public class Book
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public string ISBN { get; set; }
        public List<MultiSelectModel> writtenBy { get; set; }
        public List<MultiSelectModel> publisher { get; set; }
        public decimal price { get; set; }
        public int pages { get; set; }
        public DateTime firstPublish { get; set; }
        public string language { get; set; }
        public string path { get; set; }
        public List<MultiSelectModel> genre { get; set; }

    }
}
