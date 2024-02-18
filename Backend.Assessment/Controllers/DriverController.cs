using AutoMapper;
using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Application.Repositories;
using Backend.Assessment.Application.Requests;
using Backend.Assessment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        /// <summary>
        /// Using Unit of work and driver repo. to using driver entity for CRUD operations
        /// Using mapper to map ViewModel to driver entity 
        /// Logger from Log Statement about called api
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Driver> driverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DriverController> _logger;
        public DriverController(IUnitOfWork unitOfwork,IMapper mapper, ILogger<DriverController> logger)
        {
            _unitOfWork = unitOfwork;
            driverRepository = new DriverRepository(_unitOfWork);
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Api For Read All Drivers in Database
        /// </summary>
        /// <returns>List Of Drivers Found</returns>
        [HttpGet]
        [Route("GetAllDrivers")]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            _logger.LogInformation("Access Get All Drivers");
            var allDrivers = await driverRepository.FindAll();
            return allDrivers;
        }
        /// <summary>
        /// Api Get Driver Information 
        /// </summary>
        /// <param name="id">Driver Id</param>
        /// <returns>Object Of Driver</returns>
        [HttpGet]
        [Route("GetDriverById")]
        public async Task<ActionResult<Driver>> GetDriverById([FromQuery]int id)
        {
            _logger.LogInformation($"Access Get Driver Details by Id :{id} from Drivers");
            var driverDetails = await driverRepository.FindById(id);
            return driverDetails;
        }
        /// <summary>
        /// Create New Driver 
        /// </summary>
        /// <param name="createDriver">Create New Driver View Model</param>
        /// <returns>Created Driver</returns>
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Driver>> CreateDriver([FromBody]CreateDriverViewModel createDriver)
        {
            _logger.LogInformation("Access Create New Driver");
            var driver = _mapper.Map<Driver>(createDriver);
            var newDriver = await driverRepository.Create(driver);
            return newDriver;
        }
        /// <summary>
        /// Delete Driver from Database
        /// </summary>
        /// <param name="id">Driver Id</param>
        /// <returns>return true if driver deleted</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDriver(int id)
        {
            _logger.LogInformation($"Access Delete Driver by Id :{id} from Drivers");
            return await driverRepository.Delete(id);
        }
        /// <summary>
        /// Update Driver Information in database
        /// </summary>
        /// <param name="updateDriver"></param>
        /// <returns>Updatetd Driver</returns>
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Driver>> UpdateDriver([FromBody]UpdateDriverViewModel updateDriver)
        {
            _logger.LogInformation("Access Update Existed Driver");
            var driver = _mapper.Map<Driver>(updateDriver);
            var updatedDriver = await driverRepository.Update(driver.Id,driver);
            return updatedDriver;
        }
    }
}
