using AutoMapper;
using Backend.Assessment.Api.MapProfile;
using Backend.Assessment.Api.Validations;
using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Application.Repositories;
using Backend.Assessment.Application.Requests;
using Backend.Assessment.Controllers;
using Backend.Assessment.Domain.Entities;
using Backend.Assessment.UnitTesting.Mocks;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.UnitTesting.Api
{
    public class DriverControllerTest
    {
        DriverController _driverController;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<DriverController>> _logger;
        public DriverControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            
            _logger = new Mock<ILogger<DriverController>>();
            var context = DBContext.GetDatabaseContext();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.Context).Returns(context.Result);
            
            _driverController = new DriverController(mockUnitOfWork.Object,_mapper,_logger.Object);
        }

        [Fact]
        public async void GetAll_Drivers_Success()
        {
            //Arrange 

            //Act
            var allDrivers = _driverController.GetDrivers();
            var result = allDrivers.Result.Value as List<Driver>;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Count);
        }
        [Fact]
        public void GetById_Driver_Success()
        {
            //Arrange 
            int driverId = 1;
            //Act
            var driverDetails = _driverController.GetDriverById(driverId);
            var result = driverDetails.Result.Value as Driver;

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void GetById_Driver_Failed()
        {
            //Arrange 
            int driverId = 11;
            //Act
            var driverDetails = _driverController.GetDriverById(driverId);
            var result = driverDetails.Result.Value as Driver;

            //Assert
            Assert.True(result == null);
        }
        [Fact]
        public void Create_Driver_Success()
        {
            //Arrange 
            var createDriver = new CreateDriverViewModel()
            {
                Email = "test@email.com",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "011112020220"
            };
            //Act
            var driverDetails = _driverController.CreateDriver(createDriver);
            var result = driverDetails.Result.Value as Driver;

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Create_Driver_Failed()
        {
            //Arrange 
            CreateDriverValidation validations = new CreateDriverValidation();
            var createDriver = new CreateDriverViewModel()
            {
                Email = "test",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "011112020220"
            };
            //Act
            var result = validations.TestValidate(createDriver);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Errors.Count > 0);
        }
        [Fact]
        public void Update_Driver_Success()
        {
            //Arrange 
            var updateDriver = new UpdateDriverViewModel()
            {
                Id = 1,
                Email = "test@email.com",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "011112020220"
            };
            //Act
            var driverDetails = _driverController.UpdateDriver(updateDriver);
            var result = driverDetails.Result.Value as Driver;

            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Update_Driver_Failed()
        {
            //Arrange 
            UpdateDriverValidation validations = new UpdateDriverValidation();
            var updateDriver = new UpdateDriverViewModel()
            {
                Id = 1,
                Email = "test",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "011112020220"
            };
            //Act
            var result = validations.TestValidate(updateDriver);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Errors.Count > 0);
        }
        [Fact]
        public void Delete_Driver_Success()
        {
            //Arrange 
            int driverId = 1;
            //Act
            var driverDelete = _driverController.DeleteDriver(driverId);
            var result = driverDelete.Result.Value;

            //Assert
            Assert.True(result);
        }
        [Fact]
        public void Delete_Driver_Failed()
        {
            //Arrange 
            int driverId = 11;
            //Act
            var driverDelete = _driverController.DeleteDriver(driverId);

            //Assert
            Assert.False(driverDelete.Result.Value);
        }
    }
}
