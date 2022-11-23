using Aircompany.Data;
using Aircompany.Planes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Aircompany
{
    public class Program
    {
        public static void Main()
        {
            var airport = new Airport(ApplicationData.Planes);
            var militaryAirport = new Airport(airport.GetMilitaryPlanes());
            var passengerAirport = new Airport(airport.GetPassengerPlanes());

            Console.WriteLine(militaryAirport
                .SortByMaxDistance());
            Console.WriteLine(passengerAirport
                .SortByMaxSpeed());
            Console.WriteLine(airport);
        }
    }
}
