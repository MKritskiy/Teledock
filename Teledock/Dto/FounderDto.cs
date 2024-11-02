using System.ComponentModel.DataAnnotations;

namespace Teledock.Dto
{
    public class FounderDto
    {
        [Required]
        [StringLength(12)]
        public string INN { get; set; } = null!;
        [Required]
        [StringLength(255)]
        public string FullName { get; set; } = null!;

        public int ClientId { get; set; }
    }
}
