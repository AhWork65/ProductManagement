
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProductManagement.Domain.Dto.Attribute;



namespace ProductManagement.UnitTest.Attribute
{
    [TestClass]
    public class AttributeTests
    {

        private readonly HttpClient _httpClient;

        public AttributeTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();

        }




        [TestMethod]
        public async Task GetAllAttribute()
        {
            var response = await _httpClient.GetAsync($"/Attribute/GetAllAsync");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }



        [TestMethod]
        [DataRow(1)]
        public async Task GetByIdAsyncTest(int id)
        {
            var response = await _httpClient.GetAsync($"/Attribute/GetByIdAsync/{id}");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }




        [TestMethod]
        public async  Task UpdateAttributeTest()
        {
            var attribute=new ProductManagementWebApi.Models.Attribute
            {
               Id = 1,
                Name = "yellow",
                Value="yellow1-1",
                ParentId = null
            };
            var json = JsonConvert.SerializeObject(attribute);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/Attribute/UpdateAttribute",stringContent);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }



        [TestMethod]
       
        public async  Task AddAttributeTestAsync()
        {

            var attribute = new AttributeDto
            {
                Name = "sorti",
                Value = "",
                ParentId = null
            };
            var json = JsonConvert.SerializeObject(attribute);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/Attribute/CreateAttribute", stringContent);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        [DataRow(63)]
        public async Task DeleteReturnsOk(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Attribute/DeleteAttribute/{id}");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }




        [TestMethod]
        [DataRow(61)]
        public async Task DeleteParentReturnsOk(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Attribute/DeleteParentAttribute/{id}");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
    }
}


