using Microsoft.AspNetCore.Mvc;
using BarcodeBackend.Managers;

namespace BarcodeBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarcodesController : ControllerBase
    {


        private readonly ILogger<BarcodesController> _logger;
        private BarcodesManager _manager = new BarcodesManager();

        public BarcodesController(ILogger<BarcodesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBarcodes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<Barcode>> Get()
        {
            if (_manager.barcodes.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(_manager.getAll());
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Barcode> GetById(int id)
        {
            Barcode result = _manager.getById(id);
            if (result == null)
            {
                return NotFound("Barcode does not exist");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Add(Barcode barcode)
        {
            try
            {
                _manager.add(barcode);
                return Ok("Barcode added");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            Barcode result = _manager.getById(id);
            if (result == null)
            {

                return NotFound("Barcode does not exist");
            }
            else
            {
                _manager.delete(id);
                return Ok("Barcode deleted");

            }
        }
    }
}