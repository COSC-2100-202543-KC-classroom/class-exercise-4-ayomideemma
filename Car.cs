/*
===========================================
Program: Car Inventory Manager (COSC2100)
File: Car.cs
Author: Ayomide Emmanuel
Date: October 2025
Description:
    Defines the Car class used by the Car Inventory application.
    Each Car object stores Make, Model, Year, Price, and IsNew information,
    along with an automatically assigned unique IdentificationNumber.
    Includes both default and parameterized constructors, a static Count property,
    and an overridden ToString() method for formatted output.
===========================================
*/


using System;

namespace Assignment_2_Classes_And_Exceptions
{
    public class Car: Vehicle
    {
        private static int carCount = 0;
        public int CarIdentificationNumber { get; }
        public static int Count => carCount;

        public Car(): base()
        {
            carCount++;
            CarIdentificationNumber = carCount;
        }

        public Car(string make, string model, int year, decimal price, bool isNew)
            : base(make, model, year, price, isNew)
        {
            carCount++;
            CarIdentificationNumber = carCount;
        }

        public override string GetInfo ()
        {
            return $"Car ID: {CarIdentificationNumber}";
        }

    }
}
