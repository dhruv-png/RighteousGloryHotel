using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RighteousGloryHotel.Controllers;
using RighteousGloryHotel.Data;
using RighteousGloryHotel.Models;
using System;
using System.Web.Mvc;

namespace RighteousGloryHotelTests
{
    [TestClass]
    public class RoomsControllerTest
    {
     readonly 
        private ApplicationDbContext _context; 
        private RoomsController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            var Rooms = new Room
            {
                roomId = 101,
                floor = 2
            };

            object p = Rooms.Add(new Room
            {
                roomId = 523,
                floor = 2,
                roomNo = 201,
                balconyView = true,
                bed = true,
                roomDescription = "Corner Room"
            }); ;


            object p = Rooms.Add(new Room
            {
                roomId = 523,
                floor = 2,
                roomNo = 201,
                balconyView = true,
                bed = true,
                roomDescription = "Corner Room"
            });  ; 
            
            object p = Rooms.Add(new Room
            {
                roomId = 523,
                floor = 2,
                roomNo = 201,
                balconyView = true,
                bed = true,
                roomDescription = "Corner Room"
            }); ;

            foreach (var room in Rooms)
            {
                _context.Rooms.Add(room);
            }
            _context.SaveChanges();

            // arrange: create controller for all tests
            controller = new RoomsController(_context);
        }


        [TestMethod]
        public void IndexLoadsCorrectView()
        { 
            var result = (ViewResult)controller.Index().Result;

            Assert.AreEqual("Index", result.ViewName);
        }



        [TestMethod]
        public void IndexLoadsBooks()
        {
            // act
            var result = (ViewResult)controller.Index().Result;
            List<Room> model = (List<Room>)result.Model;

            // assert
            CollectionAssert.AreEqual(rooms.OrderBy(b => b.floor), model);
        }


        #region Details

        [TestMethod]
        public void DetailsNoIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Details(null).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Details(-1).Result;

            // assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsBook()
        {
            // act
            var result = (ViewResult)controller.Details(642).Result;
            Room room = (Room)result.Model;
            // assert
            Assert.AreEqual(rooms[0], room);
        }

        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            var result = (ViewResult)controller.Details(523).Result;

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }
    
    #endregion
}
}
