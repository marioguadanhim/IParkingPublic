using System.Collections.Generic;
using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Parking;
using Microsoft.AspNetCore.Mvc;

namespace IParking.WebApi.Controllers
{
    /// <summary>
    /// Endpoint to Insert and Get the Parking Information
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : Controller
    {
        private IParkingApplication _parkingApplication;

        public ParkingController(
            IParkingApplication parkingApplication
            )
        {
            _parkingApplication = parkingApplication;
        }

        /// <summary>
        /// Add a new parking for the car
        /// </summary>
        /// <param name="newParkingBillViewModel">Parking information</param>
        /// <returns>Data of the new parking including the new Id</returns>
        [HttpPost("AddParking")]
        public SimpleParkingViewModel AddParking([FromBody] NewParkingBillViewModel newParkingBillViewModel)
        {
            return _parkingApplication.AddParkingTime(newParkingBillViewModel);
        }

        /// <summary>
        /// Get the parking informartion
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("ParkingDetails")]
        public ParkingBillDetailsViewModel GetParkingDetails(int Id)
        {
            return _parkingApplication.GetFullParkingTime(Id);
        }

        /// <summary>
        /// All parkings of all cars of the customer
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet("GetAllParkingDetailsByCustomer")]
        public List<ParkingBillDetailsViewModel> GetAllParkingTimeByCustomer(int CustomerId)
        {
            return _parkingApplication.GetAllParkingTimeByCustomer(CustomerId);
        }

        /// <summary>
        /// All parkings of the car of the customer
        /// </summary>
        /// <param name="CarId"></param>
        /// <returns></returns>
        [HttpGet("GetAllParkingDetailsByCar")]
        public List<ParkingBillDetailsViewModel> GetAllParkingDetailsByCar(int CarId)
        {
            return _parkingApplication.GetAllParkingTimeByCar(CarId);
        }
    }
}
