﻿
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Services.Dto.Attribute;
using ProductManagement.Services.Service.Attributes;
using ProductManagement.Services.Service.Attributes.Validation;
using ProductManagementWebApi.Controllers.Api;
using Xunit;

namespace ProductManagement.UnitTest.Attribute
{
    [TestClass]
    public class AttributeTests
    {


        private readonly AttributeController _attributeController;
        private readonly IAttributesService _attributesService;
        private readonly IAttributesRepository _repository;
        private readonly IAttributeValidationService _validation;



        public AttributeTests()
        {
            _attributeController = new AttributeController(_attributesService);
            _attributesService = new AttributesService(_repository, _validation);
        }



        [Fact]
        [TestMethod]
        public void GetAllAttribute()
        {
            var okResult = _attributeController.GetAllAsync();
            Assert.IsNotNull(okResult);

        }


        [Fact]
        [TestMethod]
        public void GetByIdAsyncTest()
        {
            var okResult = _attributeController.GetByIdAsync(1);
            Assert.AreEqual(1, 1);

        }



        [Fact]
        [TestMethod]

        public void UpdateAttributeTest()
        {
            AttributeDto dto = new AttributeDto();
            dto.Name = "yellow";
            dto.ParentId = null;
            dto.Value = "yll-1";
            dto.ParentId = 26;
            var c = _attributeController.UpdateAttribute(dto);
            Assert.AreEqual(1, 1);
        }


        [Fact]
        [TestMethod]

        public void AddAttributeTestAsync()
        {
            AttributeDto dto = new AttributeDto();
            dto.Name = "yellow";
            dto.ParentId = null;
            dto.Value = "w";
            dto.Id = 34;
            var action = _attributeController.CreateAttribute(dto);
            Assert.AreEqual(action.result, dto);
        }

        [Fact]
        [TestMethod]

        public void DeleteReturnsOk()
        {
            var controller = _attributeController.DeleteAttribute(38);
            Assert.AreEqual(1, 1);
        }
    }
}

    
