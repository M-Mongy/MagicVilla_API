using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.VillList);
        }
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            if (VillaStore.VillList.FirstOrDefault(u => u.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomErorr", "Villa already Exist!");
                return BadRequest(ModelState);
            }

            if (villaDto == null)
            {

                return BadRequest(villaDto);
            }
            if (villaDto.Id < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.Id = VillaStore.VillList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.VillList.Add(villaDto);
            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.VillList.Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, VillaDto villaDto)
        {
            if (villaDto != null || id != villaDto.Id)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillList.FirstOrDefault(u => u.Id == id);
            villa.Name = villaDto.Name;
            villa.Occupancy = villaDto.Occupancy;
            villa.Sqft = villaDto.Sqft;
            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> PatchDto)
        {
            if (PatchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return BadRequest();
            }
            PatchDto.ApplyTo(villa, ModelState);
            if (ModelState == null)
            {
                return BadRequest();
            }
            return NoContent();


        }
    }
}
