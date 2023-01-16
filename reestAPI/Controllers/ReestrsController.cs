using reestAPI.Models;
using reestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace reestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReestrsController : ControllerBase
    {
        private readonly ReestrService _reestrService;

        public ReestrsController(ReestrService reestrService)
        {
            _reestrService = reestrService;
        }

        [HttpGet]
        public ActionResult<List<reestr>> Get() =>
            _reestrService.Get();

        [HttpGet("{id:length(24)}", Name = "GetReestr")]
        public ActionResult<reestr> Get(string id)
        {
            var reestr = _reestrService.Get(id);

            if (reestr == null)
            {
                return NotFound();
            }

            return reestr;
        }

        [HttpPost]
        public ActionResult<reestr> Create(reestr reestr)
        {
            _reestrService.Create(reestr);

            return CreatedAtRoute("GetReestr", new { id = reestr.Id.ToString() }, reestr);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, reestr reestrIn)
        {
            var book = _reestrService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _reestrService.Update(id, reestrIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var reestr = _reestrService.Get(id);

            if (reestr == null)
            {
                return NotFound();
            }

            _reestrService.Remove(id);

            return NoContent();
        }
    }
}