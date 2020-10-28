using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CvApi.Helper.ErrorHandler
{
    public class ErrorHandler : ControllerBase, IErrorHandler
    {
        public IActionResult HandleError(Exception e)
        {
            switch (e)
            {
                case ArgumentException argumentException:
                    return BadRequest();
                case KeyNotFoundException notFound:
                    return NotFound();
                case InvalidOperationException invalidOperation:
                    return NotFound();
                default:
                    throw e;

            }
        }
    }
}
