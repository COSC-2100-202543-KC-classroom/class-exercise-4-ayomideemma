/*
===========================================
Program: motorcycle Inventory Manager (COSC2100)
File: Motorcycle.cs
Author: Ayomide Emmanuel
Date: October 2025
Description:
    Defines the motorcycle class used by the motorcycle Inventory application.
    Each motorcycle object stores Make, Model, Year, Price, and IsNew information,
    along with an automatically assigned unique IdentificationNumber.
    Includes both default and parameterized constructors, a static Count property,
    and an overridden ToString() method for formatted output.
===========================================
*/


using System;

namespace Assignment_2_Classes_And_Exceptions
{
    public class Motorcycle : Vehicle
    {
        public int MotorcycleIdentificationNumber { get; }
        private static int motorcycleCount;

        public Motorcycle() : base()
        {
            motorcycleCount++;
            MotorcycleIdentificationNumber = motorcycleCount;
        }

        public Motorcycle(string make, string model, int year, decimal price, bool isNew)
            : base(make, model, year, price, isNew)
        {
            motorcycleCount++;
            MotorcycleIdentificationNumber = motorcycleCount;
        }

        public override string GetInfo()
        {
            return $"Motorcycle ID: {MotorcycleIdentificationNumber}";
        }
    }
}
