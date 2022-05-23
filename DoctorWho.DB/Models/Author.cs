using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.DB.Models
    {
    public class Author
        {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<Episode> Episodes { get; set; }
        }
    }
