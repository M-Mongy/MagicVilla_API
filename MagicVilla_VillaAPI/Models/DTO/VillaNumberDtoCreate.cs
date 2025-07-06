using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNumberDtoCreate
    {
        [Required]
        public int VillaNo { get; set; } // CORRECTED: Consistent PascalCase naming

        [Required]
        public int VillaID { get; set; }

        public string SpecialDetails { get; set; }
    }
}
