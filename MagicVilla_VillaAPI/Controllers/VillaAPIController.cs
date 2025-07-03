using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using AutoMapper;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository.IRepository;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        public IVillaReository _dbV;
        protected APIReponse _dbReponse;
        public IMapper _Mapper { get; set; }
        public VillaAPIController(ApplicationDbContext context, IMapper mapper, IVillaReository dbV)
        {
            _Mapper = mapper;
            _dbV = dbV;
            this._dbReponse = new();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIReponse>>> GetVillas()
        {
            IEnumerable<Villa> villaList = await _dbV.GetAllAsync();
            _dbReponse.Result = _Mapper.Map<List<VillaDto>>(villaList);
            _dbReponse.StatusCode=HttpStatusCode.OK;
            return Ok(_dbReponse);
        }
        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIReponse>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa  = await _dbV.GetAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _dbReponse.Result = _Mapper.Map<VillaDto>(villa);
            _dbReponse.StatusCode = HttpStatusCode.OK;
            return Ok(_dbReponse);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIReponse>> CreateVilla([FromBody] VillaDto  CreateDto)
        {
            if (await _dbV.GetAsync(u => u.Name.ToLower() == CreateDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomErorr", "Villa already Exist!");
                return BadRequest(ModelState);
            }

            if (CreateDto == null)
            {

                return BadRequest(CreateDto);
            }
            if (CreateDto.Id < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa model = _Mapper.Map<Villa>(CreateDto);

            await _dbV.CreateAsync(model);
            _dbReponse.Result = _Mapper.Map<VillaDto>(model);
            _dbReponse.StatusCode = HttpStatusCode.Created;
            return CreatedAtRoute("GetVilla", new { id = CreateDto.Id }, _dbReponse);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<ActionResult<APIReponse>> DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbV.GetAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _dbV.RemoveAsync(villa);
            _dbReponse.StatusCode = HttpStatusCode.NoContent;
            _dbReponse.IsSuccess=true;
            return Ok(_dbReponse);
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIReponse>> UpdateVilla(int id, [FromBody]VillaDto UpdateDto)
        {
            if (UpdateDto == null || id != UpdateDto.Id)
            {
                return BadRequest();
            }
            Villa model = _Mapper.Map<Villa>(UpdateDto);
           _dbV.UpdateAsync(model);
            _dbReponse.StatusCode = HttpStatusCode.NoContent;
            _dbReponse.IsSuccess = true;
            return Ok(_dbReponse);
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> PatchDto)
        {
            if (PatchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _dbV.GetAsync(u => u.Id == id);
            VillaUpdateDTO villaDto = _Mapper.Map<VillaUpdateDTO>(villa);
            if (villa == null)
            {
                return BadRequest();
            }
            PatchDto.ApplyTo(villaDto, ModelState);
            Villa model = _Mapper.Map<Villa>(villaDto);
            _dbV.UpdateAsync(model);
            if (ModelState == null)
            {
                return BadRequest();
            }
            return NoContent();


        }
    }
}
