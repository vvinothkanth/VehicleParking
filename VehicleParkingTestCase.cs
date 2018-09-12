//===================================
// Problem Title : Vehicle Parking
// Starting Date : 11/ 9 / 2018
//
//
//
//===================================


namespace VehicleParkingTestCase
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using VehiclePark;

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class VehicleParkingTestCase
    {
        /// <summary>
        ///  To check the avalible spece in level
        /// </summary>
        [TestMethod]
        public void CheckIsParkingSpaceIsAvailable()
        {

            Level level = new Level();
            Vehicle car = new Vehicle();
            car.Number = 1;
            car.Type = "car";
            level.AddVechilePermission("car", 2);

            level.ParkTheVehicle(car);

            Assert.IsTrue(level.IsParkingSpaceAvailable("car"));

            // park two cars in level
            level.ParkTheVehicle(car);
            level.ParkTheVehicle(car);

            // Here already 2 vehicles parked in level so the following statement become false
            Assert.IsFalse(level.IsParkingSpaceAvailable("car"));

        }

        /// <summary>
        /// To check the given vehicle is valis or not 
        /// </summary>
        [TestMethod]
        public void CheckIsValidVehicle()
        {
            Level level = new Level();
            level.AddVechilePermission("car", 2);
            level.AddVechilePermission("bike", 5);
            level.AddVechilePermission("auto", 2);

            // Valid vehicles 
            Assert.IsTrue(level.IsValidVehicle("Car"));
            Assert.IsTrue(level.IsValidVehicle("BiKe"));

            // Invalid vehicles
            Assert.IsFalse(level.IsValidVehicle("van"));
            Assert.IsFalse(level.IsValidVehicle("Cycle"));

        }

        /// <summary>
        /// To check the parking vahicle 
        /// </summary>
        [TestMethod]
        public void CheckParkTheVehicle()
        {
            Level level = new Level();
            Vehicle car = new Vehicle();
            car.Number = 1;
            car.Type = "car";

            Assert.AreEqual(1, level.ParkTheVehicle(car));

            Vehicle bus = new Vehicle();
            bus.Number = 1;
            bus.Type = "Bus";
            Assert.AreEqual(2, level.ParkTheVehicle(bus));
        }

        /// <summary>
        /// To check the unparking the vehicle
        /// </summary>
        [TestMethod]
        public void CheckUnParkTheVehicle()
        {
            Level level = new Level();
            Vehicle car = new Vehicle();
            car.Number = 1;
            car.Type = "car";
            int parkingId = level.ParkTheVehicle(car);
            Assert.AreEqual(1, parkingId);

            int unParkingId =  level.UnParkTheVehicle(parkingId);

            Assert.AreEqual(1, unParkingId);
        }

        /// <summary>
        /// To check the level permissions will be added or not
        /// </summary>
        [TestMethod]
        public void CheckAddLevelPermission()
        {
            Level level = new Level();

            Assert.AreEqual("car", level.AddVechilePermission("car", 5));
            Assert.AreEqual("bike", level.AddVechilePermission("bike", 5));

            Assert.AreNotEqual("car", level.AddVechilePermission("van", 5));
        }

        /// <summary>
        /// To check the new level has been created
        /// </summary>
        [TestMethod]
        public void CheckCreateLevel()
        {
            VehicleParking level = new VehicleParking();
            Assert.AreEqual(1, level.CreateLevel());
            Assert.AreEqual(2, level.CreateLevel());
            Assert.AreNotEqual(4, level.CreateLevel());
            
        }

        /// <summary>
        /// To check the token eill be created or not
        /// </summary>
        [TestMethod]
        public void CheckCreateToken()
        {
            VehicleParking level = new VehicleParking();
            Assert.AreEqual(1, level.CreateToken(1,1));
            Assert.AreEqual(2, level.CreateToken(2, 2));
            Assert.AreNotEqual(1, level.CreateToken(3, 3));
        }
    }
}
