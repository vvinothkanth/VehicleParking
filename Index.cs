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

    /// <summary>
    /// Process Menu
    /// </summary>
    enum Option
    {
        CreateLevel = 1,
        AddVehiclePermission,
        ParkVehicle,
        UnParkVehicle,
        LevelViceVehicle,
        Exit
    }

    /// <summary>
    /// 
    /// </summary>
    public class Index
    {
        static void Main(string[] args)
        {
            VehicleParking vehicleStand = new VehicleParking();

            bool isProcessContinue = true;
            while (isProcessContinue)
            {
                Console.WriteLine("1.) Create New Level");
                Console.WriteLine("2.) Add Level Permission");
                Console.WriteLine("3.) Park Vehicle");
                Console.WriteLine("4.) Un Park Vehicle");
                Console.WriteLine("5.) Level Vice Vehicle");
                Console.WriteLine("6.) Exit");
                int userOption = Convert.ToInt16(Console.ReadLine());
                
                switch (userOption)
                {
                    case (int)Option.CreateLevel:

                        int levelId = vehicleStand.CreateLevel();
                        Console.WriteLine("Parking level has been successfully created that is is : {0}", levelId);
                        break;

                    case (int)Option.AddVehiclePermission:

                        foreach (var level in vehicleStand.parkingLevels)
                        {
                            Console.WriteLine("Level Id => {0} - TotalPermissions{1}", level.Key, level.Value.vehiclePermissions.Count);
                        }
                        int levelKey = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Vehicle Type :");
                        string vehicleType = Convert.ToString(Console.ReadLine());
                        Console.Write("No of Allowed Spaces:");
                        int totalAllowededSpace = Convert.ToInt16(Console.ReadLine());

                        string vehiclePermission = vehicleStand.parkingLevels[levelKey].AddVechilePermission(vehicleType, totalAllowededSpace);

                        Console.WriteLine("{0} permisions has been added successfully", vehiclePermission);
                        break;

                    case (int)Option.ParkVehicle:

                        Console.WriteLine("Welcome");
                        Vehicle vehicle = new Vehicle();
                        Console.Write("Enter Vehicle No :");
                        vehicle.Number = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Enter Vehicle Type :");
                        vehicle.Type = Convert.ToString(Console.ReadLine());

                        bool isNotParked = true;
                        bool isNotValidVehicle = true;

                        foreach (var level in vehicleStand.GetAllLevel())
                        {
                            if (level.Value.IsValidVehicle(vehicle.Type))
                            {
                                isNotValidVehicle = false;
                                if (level.Value.IsParkingSpaceAvailable(vehicle.Type))
                                {
                                    int parkingId = level.Value.ParkTheVehicle(vehicle);
                                    int tokenNo = vehicleStand.CreateToken(level.Key, parkingId);
                                    Console.WriteLine("Token No :{0}", tokenNo);
                                    isNotParked = false;
                                    break;
                                }
                            }
                        }

                        if (!isNotValidVehicle)
                        {
                            if (isNotParked)
                            {
                                Console.WriteLine("Slot is full...!!!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("It is not valid vehicle to park");
                        }
                        break;

                    case (int)Option.UnParkVehicle:
                        
                        Console.Write("Enter Token No :");
                        int tockenNo = Convert.ToInt16(Console.ReadLine());
                        int unparkedKey = vehicleStand.parkingLevels[vehicleStand.tokens[tockenNo].levelId].UnParkTheVehicle(tockenNo);

                        Console.WriteLine("Thank You, Come Again ");
                        Console.WriteLine("Unparked Token No => {0}", unparkedKey);
                        break;

                    case (int)Option.LevelViceVehicle:
                        foreach (var lev in vehicleStand.parkingLevels)
                        {
                            Console.WriteLine("Level Id => {0}",lev.Key);
                            foreach (var veh in lev.Value.ParkedVehicles)
                            {
                                Console.WriteLine("Vehicle No {0} - Type => {1}", veh.Value.Number, veh.Value.Type);
                            }
                        }
                        break;

                    case (int)Option.Exit:
                        isProcessContinue = false;
                        break;

                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }
    }
}
