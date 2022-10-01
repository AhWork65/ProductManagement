using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProductManagement.Domain.Dto.Category;

namespace ProductManagement.UnitTest.Category
{
    [TestClass]
    public class CategoryTest
    {
        private readonly HttpClient _httpClient;

        public CategoryTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }


        [TestMethod]
        public async Task GetAllCategory()
        {
            var response = await _httpClient.GetAsync($"/Category/GetAll");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public async Task Add()
        {
            var category = new CategoryDto
            {
                Code = "9999", Name = "Test Unit", IsActive = true, ParentId = null
            };
            var json = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/Category/Add", stringContent);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public async Task AddFaild_Test()
        {

            var category = new ProductManagement.Domain.Models.Category
            {
                Code = null,
                Name = "Test Unit",
                IsActive = true,
                ParentId = null
            };
            var json = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/Category/Add", stringContent);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        public async Task Update()
        {

            var category = new ProductManagement.Domain.Models.Category
            {
                Id = 1,
                Code = "123",
                Name = "Test Unit",
                IsActive = true,
                ParentId = null
            };
            var json = JsonConvert.SerializeObject(category);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/Category/UpdateCategory", stringContent);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [DataRow(5)]
        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"/Category/Delete/{id}");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


    }
}
