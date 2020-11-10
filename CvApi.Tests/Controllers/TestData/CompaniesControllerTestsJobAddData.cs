using CvApi.Models.DataTransferObject;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CvApi.Tests.Controllers.TestData
{
    class CompaniesControllerTestsJobAddData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new JobAdvertisementDTO[] {
                new JobAdvertisementDTO {
                    CompanyID = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                    Title = "Test Title 1",
                    Description = "Test Description 1",
                    JobAdvertisementID = new Guid("CA761232-ED42-11CE-BACD-00AA0057B223"),
                }
            };

            yield return new JobAdvertisementDTO[] {
                new JobAdvertisementDTO {
                    CompanyID = new Guid("CA761232-ED42-11CE-BACD-00AA0057B223"),
                    Title = "Test Title 2",
                    Description = "Test Description 2",
                    JobAdvertisementID = new Guid("CA761232-ED42-11CE-BACD-00AA0057B222"),
                }
            };

            yield return new JobAdvertisementDTO[] {
                new JobAdvertisementDTO {
                    CompanyID = new Guid("CA761232-ED42-11CE-BACD-00AA0057B222"),
                    Title = "Test Title 3",
                    Description = "Test Description 3",
                    JobAdvertisementID = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
