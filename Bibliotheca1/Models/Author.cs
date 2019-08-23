using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bibliotheca.Model
{
    public class Author
    {
        public int authorId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string place { get; set; }
        public DateTime dob { get; set; }
        public string description { get; set; }
    }
}
