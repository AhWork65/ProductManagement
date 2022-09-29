using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProductManagement.Domain.Dto.Product;

namespace ProductManagement.UnitTest.Products
{
    [TestClass]
    public class ProductsTest
    {
        private readonly HttpClient _httpClient;

        public ProductsTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }


        [TestMethod]
        public async Task GetAllProducts()
        {
            var response = await _httpClient.GetAsync($"/Product/GetAll");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


        [TestMethod]
        public async Task GetAllActiveProducts()
        {
            var response = await _httpClient.GetAsync($"/Product/GetAllActive");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public async Task GetAllInactiveProducts()
        {
            var response = await _httpClient.GetAsync($"/Product/GetAllInactive");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        [DataRow(15646)]
        public async Task GetProductByCategory_FailTest(int categoryId)
        {
            var response = await _httpClient.GetAsync($"/Product/GetByCategory/{categoryId}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [DataRow(15646)]
        public async Task GetActiveProductByCategory_FailTest(int categoryId)
        {
            var response = await _httpClient.GetAsync($"/Product/GetActiveByCategory/{categoryId}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [DataRow(15646)]
        public async Task GetInactiveProductByCategory_FailTest(int categoryId)
        {
            var response = await _httpClient.GetAsync($"/Product/GetInactiveByCategory/{categoryId}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [DataRow(15646)]
        public async Task GetProductByClassification_FailTest(int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetByClassification/{classification}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [DataRow(15646)]
        public async Task GetActiveProductByClassification_FailTest(int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetActiveByClassification/{classification}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [DataRow(15646)]
        public async Task GetInactiveProductByClassification_FailTest(int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetInactiveByClassification/{classification}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [DataRow(15646, 0)]
        public async Task GetProductByFilter_Category_FailTest(int categoryId, int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetByFilter/{categoryId}/{classification}/");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [DataRow(13, 156)]
        public async Task GetProductByFilter_Classification_FailTest(int categoryId, int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetByFilter/{categoryId}/{classification}/");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [DataRow(15646, 0)]
        public async Task GetActiveProductByFilter_Category_FailTest(int categoryId, int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetActiveByFilter/{categoryId}/{classification}/");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [DataRow(13, 156)]
        public async Task GetActiveProductByFilter_Classification_FailTest(int categoryId, int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetActiveByFilter/{categoryId}/{classification}/");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        [DataRow(15646, 0)]
        public async Task GetInactiveProductByFilter_Category_FailTest(int categoryId, int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetInactiveByFilter/{categoryId}/{classification}/");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        [DataRow(13, 156)]
        public async Task GetInactiveProductByFilter_Classification_FailTest(int categoryId, int classification)
        {
            var response = await _httpClient.GetAsync($"/Product/GetInactiveByFilter/{categoryId}/{classification}/");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }



        [TestMethod]
        [DataRow(15646)]
        public async Task GetProductById_FailTest(int id)
        {
            var response = await _httpClient.GetAsync($"/Product/GetById/{id}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }



        [TestMethod]
        [DataRow("1425256")]
        public async Task GetProductByCode_FailTest(string code)
        {
            var response = await _httpClient.GetAsync($"/Product/GetByCode/{code}");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }






    }
}
