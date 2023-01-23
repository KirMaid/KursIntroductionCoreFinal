using System;
using Xunit;
using KursIntroductionCore.Controllers;
using Moq;
using KursIntroductionCore.Services;
using KursIntroduction.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace KursIntroductionCore.Tests
{
    public class HomeControllerTests
    {

        private readonly Mock<IFlightInterface> service;
        public HomeControllerTests()
        {
            service = new Mock<IFlightInterface>();
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewUserResultNotNull()
        {
            UserPageController controller = new UserPageController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllFlightIsNotNull()
        {
            FlightService flightService = new FlightService();
            var result = flightService.GetAllFlight();
            Assert.IsType<List<Flight>>(result);
        }


        [Fact]
        public void GetTransactionsByUser()
        {
            var user = new User() { Name = "JohnDoe", Id = 35, Login = "tst", Password = "1234" };
            FlightService flightService = new FlightService();
            var result = flightService.GetAllFlightByUserId(user);
            Assert.Equal(result.Count, 0);
        }


    }
}
