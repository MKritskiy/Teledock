using System.ComponentModel.DataAnnotations;
using Teledock.Models.Enums;

namespace Teledock.Dto
{
    public class ClientDto
    {
        [Required]
        [StringLength(12)]
        public string INN { get; set; } = null!;
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;
        [Required]
        public ClientType ClientType { get; set; }
    }
}
