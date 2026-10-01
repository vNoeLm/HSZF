using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    public class Director
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public Director()
        {

        }

        public Director(int id, string name)
        {
            this.DirectorId = id;
            this.Name = name;
        }
    }

    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }

        [Required]
        public double Revenue { get; set; }


        //FK
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }

        public DateTime ReleasedAt { get; set; }

        public double Rating { get; set; }

        public Movie()
        {

        }

        public Movie(int id, string title, double rev, int dirId, DateTime relTime, double rating)
        {
            this.MovieId = id;
            this.Title = title;
            this.Revenue = rev;
            this.DirectorId = dirId;
            this.ReleasedAt = relTime;
            this.Rating = rating;
        }
    }

    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        // FK
        public int MovieId { get; set; } 
        public virtual Movie Movie { get; set; } 

        // FK
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public int Rank { get; set; }
        public string CharacterName { get; set; }

        public Role() { }

        public Role(int id, int movieId, int actorId, int rank, string name)
        {
            this.RoleId = id;
            this.MovieId = movieId;
            this.ActorId = actorId;
            this.Rank = rank;
            this.CharacterName = name;
        }
    }

    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }

        public string ActorName { get; set; }

        public Actor()
        {
        }

        public Actor(int id, string name)
        {
            this.ActorId = id;
            this.ActorName = name;
        }
    }
}
