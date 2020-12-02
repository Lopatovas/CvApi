using CvApi.Helper.ErrorHandler;
using CvApi.Models.DataTransferObject;
using CvApi.Services.ApplicationService;
using CvApi.Services.JobAdvertisementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CvApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobAdvertisementsController : ControllerBase
    {
        private readonly IJobAdvertisementService _service;
        private readonly IApplicationService _applicationService;
        private readonly IErrorHandler _handler;

        public JobAdvertisementsController(IJobAdvertisementService service, IApplicationService applicationService, IErrorHandler handler)
        {
            _service = service;
            _applicationService = applicationService;
            _handler = handler;
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
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }

        [HttpPost("{id}/Apply")]
        [Authorize(Policy = "Users")]
        public IActionResult Apply(Guid id, ApplicationDTO application)
        {
            try
            {
                var applicationInDb = _applicationService.Apply(id, application);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return _handler.HandleError(e);
            }
        }
    }
}
