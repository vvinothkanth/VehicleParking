//===================================
// Problem Title : Vehicle Parking
// Starting Date : 11/ 9 / 2018
//
//
//
//===================================

namespace VehiclePark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The level Class
    /// </summary>
    public class Level
    {

        /// <summary>
        /// The list of vehicle permissions 
        /// </summary>
        public Dictionary<string, int> vehiclePermissions = new Dictionary<string, int>();

        /// <summary>
        /// The list od vehicle parked in this level
        /// </summary>
        public Dictionary<int, Vehicle> ParkedVehicles = new Dictionary<int, Vehicle>();

        /// <summary>
        /// Check the given vehicle type is valid or not
        /// </summary>
        /// <param name="vechicleType">vehicle type</param>
        /// <returns>boolian</returns>
        public bool IsValidVehicle(string vechicleType)
        {
            bool isValid = vehiclePermissions.ContainsKey(vechicleType.ToLower()) ? true : false;
            return isValid;
        }

        /// <summary>
        /// To check the availability of given vehicle for parking
        /// </summary>
        /// <param name="vehicleType">vehicle type</param>
        /// <returns>boolian</returns>
        public bool IsParkingSpaceAvailable(string vehicleType)
        {
            bool isAvailable = false;

            try
            {
                if (vehiclePermissions.ContainsKey(vehicleType))
                {
                    var vehicleCount = (from park in ParkedVehicles where park.Value.Type == vehicleType.ToLower() select park.Value.Number).ToList<int>().Count;

                    isAvailable = vehicleCount < vehiclePermissions[vehicleType] ? true : false;
                }
            }
            catch (Exception ex)
            {    
                throw new Exception(ex.ToString());
            }

            return isAvailable;
                 
        }

        /// <summary>
        /// To store the parked vehicle details
        /// </summary>
        /// <param name="vehicle">vehicle object</param>
        /// <returns>parked id</returns>
        public int ParkTheVehicle(Vehicle vehicle)
        {
            int parkedId = 0;
            if (ParkedVehicles.Count != 0)
            {
                parkedId = ParkedVehicles.Keys.Max() + 1;
            }
            else
            {
                parkedId =  ParkedVehicles.Count + 1;
            }

            ParkedVehicles.Add(parkedId, vehicle);

            return parkedId;
        }

        /// <summary>
        /// To return the vehicle
        /// </summary>
        /// <param name="parkedId">parking id</param>
        /// <returns> vehicle id </returns>
        public int UnParkTheVehicle(int parkedId)
        {
            if (ParkedVehicles.ContainsKey(parkedId))
            {
                ParkedVehicles.Remove(parkedId);
            }
            else
            {
                throw new ArgumentException();
            }

            return parkedId;
        }

        /// <summary>
        /// To add vehicle permissions in the level
        /// </summary>
        /// <param name="vechicleType">vehicle type</param>
        /// <param name="allowedCount">capacity</param>
        public string AddVechilePermission(string vechicleType, int allowedCount)
        {
            if(!vehiclePermissions.Keys.Contains(vechicleType))
            {
                vehiclePermissions.Add(vechicleType, allowedCount);
            }
            else
            {
                throw new ArgumentException();
            }

            return vechicleType;
        }
    }
}
