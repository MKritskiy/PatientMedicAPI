using Microsoft.AspNetCore.Mvc;
using PatientMedicAPI.BL;
using PatientMedicAPI.Dto.Medic;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        IMedicBL _medicBl;

        public MedicController(IMedicBL medicBl)
        {
            _medicBl = medicBl;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Medic medic)
        {
            try
            {
                var id = await _medicBl.Add(medic);
                return CreatedAtAction(nameof(Get), new { id }, medic);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medic medic)
        {
            try
            {
                if (medic.MedicId > 0  && id != medic.MedicId)
                {
                    return BadRequest( new { message = "ID mismatch" });
                }
                medic.MedicId = id;
                await _medicBl.Update(medic);
                return Ok(new { message = "Successfuly updated" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _medicBl.Delete(id);
                return Ok(new { message = "Successfuly deleted" }); ;
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicEditDto>> Get(int id)
        {
            try
            {
                var medicDto = await _medicBl.Get(id);
                if (medicDto == null)
                {
                    return NotFound();
                }
                return Ok(medicDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<MedicListDto>> GetList(
            [FromQuery] string sortField = "MedicId",
            [FromQuery] bool ascending = true,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var medics = _medicBl.GetList(sortField, ascending, page, pageSize);
                return Ok(medics);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
