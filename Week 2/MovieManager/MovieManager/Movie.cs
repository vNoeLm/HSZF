using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManager
{
    internal class Movie
    {
        public string Title { get; set; }
        public int Length { get; set; }
        public int ReleaseDate { get; set; }

        public Movie(string title, int length, int releaseDate)
        {
            Title = title;
            Length = length;
            ReleaseDate = releaseDate;
        }
    }
}
