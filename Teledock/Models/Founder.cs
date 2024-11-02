using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Teledock.Models
{
    public class Founder : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string? INN { get; set; }
        [Required]
        [StringLength(255)]
        public string? FullName { get; set; }

        public int ClientId { get; set; }
        [JsonIgnore]
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
    }
}
