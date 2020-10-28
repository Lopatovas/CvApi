using Microsoft.AspNetCore.Mvc;
using System;

namespace CvApi.Helper.ErrorHandler
{
    public interface IErrorHandler
    {
        public IActionResult HandleError(Exception e);
    }
}
