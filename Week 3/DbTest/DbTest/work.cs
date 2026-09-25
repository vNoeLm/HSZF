using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbTest
{
    public class Workshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopId { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Topic { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Capacity { get; set; }

        public DateTime StartsAt { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
            = new HashSet<Registration>();
    }

    public class Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentName { get; set; } = string.Empty;

        [Range(0, 100)]
        public int Score { get; set; }

        public DateTime RegisteredAt { get; set; }

        // Idegen kulcs: ez kapcsolja a jelentkezest egy workshophoz.
        public int WorkshopId { get; set; }

        public virtual Workshop Workshop { get; set; } = null!;
    }
}
