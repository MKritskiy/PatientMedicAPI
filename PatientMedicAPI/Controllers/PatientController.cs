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
            try
            {
                var id = await _patientBl.Add(patient);
                return CreatedAtAction(nameof(Get), new { id }, patient);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient patient)
        {
            try
            {
                if (patient.PatientId >0 && id != patient.PatientId)
                {
                    return BadRequest("ID mismatch");
                }
                patient.PatientId = id;
                await _patientBl.Update(patient);
                return Ok(new { message = "Successfuly updated" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { mesage = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                await _patientBl.Delete(id);
                return Ok(new { message = "Successfuly deleted" });
            }
            catch (Exception ex)
            {

                return BadRequest( new { message = ex.Message });
            }
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
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult<IEnumerable<PatientListDto>> GetList(
            [FromQuery] string sortField = "PatientId", 
            [FromQuery] bool ascending = true, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var patients = _patientBl.GetList(sortField, ascending, page, pageSize);
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
