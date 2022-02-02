using IParking.Application.Interfaces;
using IParking.Application.ViewModel.Car;
using Microsoft.AspNetCore.Mvc;

namespace IParking.WebApi.Controllers
{
    /// <summary>
    /// Endpoint to Insert and Get the Cars Information
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private ICarApplication _carApplication;

        public CarController(
            ICarApplication carApplication
        )
        {
            _carApplication = carApplication;
        }

        /// <summary>
        /// Add a New Car
        /// </summary>
        /// <param name="carViewModel">Car data and the owner Id</param>
        /// <returns>Data of the new car including the new Id</returns>
        [HttpPost]
        public CarDetailsViewModel AddCar([FromBody] NewCarViewModel carViewModel)
        {
            return _carApplication.AddCar(carViewModel);
        }

        /// <summary>
        /// Get Car Information
        /// </summary>
        /// <param name="carId">Id of the car</param>
        /// <returns>Car Information</returns>
        [HttpGet]
        public FullCarViewModel FindById(int carId)
        {
            return _carApplication.FindById(carId);
        }
    }
}
