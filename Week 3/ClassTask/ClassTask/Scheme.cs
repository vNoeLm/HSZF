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
        }

        public class Role
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int RoleId { get; set; }

            //FK
            public int MoveiId { get; set; }
            public virtual Movie moveie { get; set; }

            //FK
            public int ActorId { get; set; }
            public virtual Actor Actor { get; set; }

            public int Rank { get; set; }

            public string CharacterName { get; set; }
        }

        public class Actor
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ActorId { get; set; }

            public string ActorName { get; set; }
        }
}
