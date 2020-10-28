using CvApi.Services.JobAdvertisementService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementsController : ControllerBase
    {
        private readonly IJobAdvertisementService _service;

        public JobAdvertisementsController(IJobAdvertisementService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAdvertisements()
        {
            var advertisements = _service.GetAdvertisements();
            return Ok(advertisements);
        }

        [HttpGet("{id}")]
        public IActionResult GetJobAdvertisement(Guid id)
        {
            try
            {
                var advertisement = _service.GetAdvertisementById(id);
                return Ok(advertisement);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
