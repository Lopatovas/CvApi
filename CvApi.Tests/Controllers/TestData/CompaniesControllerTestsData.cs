using CvApi.Models.DataTransferObject;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CvApi.Tests.Controllers.TestData
{
    class CompaniesControllerTestsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new CompanyDTO[] {
                new CompanyDTO {
                    CompanyID = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D"),
                    Title = "Test Title 1",
                    Address = "Test Address 1",
                    Description = "Test Description 1",
                    Email = "Test@1.com",
                    Phone = "Test phone"
                }
            };

            yield return new CompanyDTO[] {
                new CompanyDTO {
                    CompanyID = new Guid("CA761232-ED42-11CE-BACD-00AA0057B223"),
                    Title = "Test Title 2",
                    Address = "Test Address 2",
                    Description = "Test Description 2",
                    Email = "Test@2.com",
                    Phone = "Test phone 2"
                }
            };

            yield return new CompanyDTO[] {
                new CompanyDTO {
                    CompanyID = new Guid("CA761232-ED42-11CE-BACD-00AA0057B222"),
                    Title = "Test Title 3",
                    Address = "Test Address 3",
                    Description = "Test Description 3",
                    Email = "Test@3.com",
                    Phone = "Test phone 3"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
