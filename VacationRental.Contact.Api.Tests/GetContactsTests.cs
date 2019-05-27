using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VacationRental.Contact.Api.Controllers;
using Xunit;

namespace VacationRental.Contact.Api.Tests
{

    public class GetContactsTests
    {

        [Fact]
        public void GivenContactDoesNotExist_WhenGetContact_ThenNotFoundIsReturned()
        {
            FakeContactService service = new FakeContactService();
            ContactController controller = new ContactController(service);
            var vacationRentalId = 4;
            var response = controller.Get(vacationRentalId);
            Assert.IsType<NotFoundResult>(response);

        }
    }
}
