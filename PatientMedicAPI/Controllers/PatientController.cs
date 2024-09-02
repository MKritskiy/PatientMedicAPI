using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientMedicAPI.BL;
using PatientMedicAPI.BL.Helpers;
using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientBL _patientBl;

        public PatientController(IPatientBL patientBl)
        {
            _patientBl = patientBl;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Patient patient)
        {
            var id = await _patientBl.Add(patient);
            return CreatedAtAction(nameof(Get), new { id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest("ID mismatch");
            }

            await _patientBl.Update(patient);
            return Ok(new {message = "Successfuly updated"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _patientBl.Delete(id);
            return Ok(new { message = "Successfuly deleted" }); ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientEditDto>> Get(int id)
        {
            try
            {
                var patientDto = await _patientBl.Get(id);
                if (patientDto == null)
                {
                    return NotFound();
                }
                return Ok(patientDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<PatientListDto>> GetList(
            [FromQuery] string sortField = "PatientId", 
            [FromQuery] bool ascending = true, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            var patients = _patientBl.GetList(sortField, ascending, page, pageSize);
            return Ok(patients);
        }


    }
}
