using System.ComponentModel.DataAnnotations;
using Teledock.Models.Enums;

namespace Teledock.Models
{
    public class Client : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string? INN { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        public ClientType ClientType { get; set; }

        public ICollection<Founder>? Founders { get; set; }
    }
}
