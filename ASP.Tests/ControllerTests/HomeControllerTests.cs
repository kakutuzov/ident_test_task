using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ASP.Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly HttpClient httpClient;

        public HomeControllerTests()
        {
            var webFactroy = new WebApplicationFactory<EntryPoint>();            
            httpClient = webFactroy.CreateDefaultClient();
        }

        [TestMethod]
        public async Task YearMonthTest_10_2002()
        {
            int year = 2002;
            int month = 10;
            const string expected = "10.2002";
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth={month}.{year}");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(String.Empty, result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task YearMonthTest_EmptyMonth()
        {
            int year = 2002;            
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth=.{year}");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task YearMonthTest_EmptyYear()
        {
            int month = 2;
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth={month}.");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task YearMonthTest_EmptyYearMonth()
        {
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth=.");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task YearMonthTest_15_2002()
        {
            int year = 2002;
            int month = 15;
            const string expected = "1.1970";
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth={month}.{year}");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(String.Empty, result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task YearMonthTest_12_1940()
        {
            int year = 1940;
            int month = 12;
            const string expected = "1.1970";
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth={month}.{year}");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(String.Empty, result);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task YearMonthTest_16_1940()
        {
            int year = 1940;
            int month = 16;
            const string expected = "1.1970";
            var response = await httpClient.GetAsync($"/Home/Test?YearMonth={month}.{year}");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(String.Empty, result);
            Assert.AreEqual(expected, result);
        }
    }
}