using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNumberDtoUpdate
    {
        [Required]
    
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
