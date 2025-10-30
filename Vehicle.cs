/*
===========================================
Program: Vehicle Inventory Manager (COSC2100)
File: Vehicle.cs
Author: Ayomide Emmanuel
Date: October 2025
Description:
    Defines the Vehicle class used by the Vehicle Inventory application.
    Each Vehicle object stores Make, Model, Year, Price, and IsNew information,
    along with an automatically assigned unique IdentificationNumber.
    Includes both default and parameterized constructors, a static Count property,
    and an overridden ToString() method for formatted output.
===========================================
*/


using System;


namespace Assignment_2_Classes_And_Exceptions
{
    public abstract class Vehicle
    {
        private static int vehicleCount = 0;
        public int VehicleIdentificationNumber { get; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
        public static int VehicleCount => vehicleCount;

        public Vehicle()
        {
            vehicleCount++;
            VehicleIdentificationNumber = vehicleCount;
        }

        public Vehicle(string make, string model, int year, decimal price, bool isNew)
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            IsNew = isNew;
        }

        /// <summary>
        /// Get vehicle specific info
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfo();

        public override string ToString()
        {
            string status = IsNew ? "New" : "Used";
            return $"Vehicle ID #{VehicleIdentificationNumber}: {Year} {Make} {Model} - {IsNew} (${Price:0.00})\n{GetInfo()}";
        }
    }
}
