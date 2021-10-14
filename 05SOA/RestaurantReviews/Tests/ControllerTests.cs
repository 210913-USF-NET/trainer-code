//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using Moq;
//using WebUI.Controllers;
//using RRBL;
//using Models;
//using Microsoft.AspNetCore.Mvc;
//using WebUI.Models;

//namespace Tests
//{
//    public class ControllerTests
//    {
//        [Fact]
//        public void RestaurantControllerIndexShouldReturnListOfRestaurants()
//        {
//            //Arrange
//            var mockBL = new Mock<IBL>();
//            mockBL.Setup(x => x.GetAllRestaurants()).Returns(
//                    new List<Restaurant>()
//                    {
//                        new Restaurant() {
//                            Id = 1,
//                            Name = "Salt and Straw",
//                            City = "Portland",
//                            State = "OR"
//                        },
//                        new Restaurant()
//                        {
//                            Id = 2,
//                            Name = "Metro Diner",
//                            City = "Palm Coast",
//                            State = "FL"
//                        }
//                    }
//                );
//            var controller = new RestaurantController(mockBL.Object);

//            //Act
//            var result = controller.Index();

//            //Assert
//            //First, make sure we are getting the right type of the result obj
//            var viewResult = Assert.IsType<ViewResult>(result);

//            //Next, we wanna make sure, that in this viewresult, the model we have for it
//            //is list of RestaurantVM's
//            var model = Assert.IsAssignableFrom<IEnumerable<RestaurantVM>>(viewResult.ViewData.Model);

//            //lastly, let's make sure there're two of them
//            Assert.Equal(2, model.Count());
//        }
//    }
//}
