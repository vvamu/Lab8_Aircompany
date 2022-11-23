using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using Aircompany.Data;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {

        [Test]
        public void GetTransportMilitaryPlanes_Test() 
        {
            var airport = new Airport(ApplicationData.Planes);
            var transportMilitaryPlanes = airport.GetTransportMilitaryPlanes();
            var hasOtherPlaneType = transportMilitaryPlanes.Exists(x => x.Type != MilitaryType.TRANSPORT);
            Assert.IsFalse(hasOtherPlaneType);
        }

        [Test]
        public void GetPassengerPlaneWithMaxPassengersCapacity_Test()
        {
            var airport = new Airport(ApplicationData.Planes);
            var expectedPassengerPlaneWithMaxPassengersCapacity = ApplicationData.PlaneWithMaxPassengerCapacity;
            var actualPassengerPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();           
            Assert.AreEqual(actualPassengerPlaneWithMaxPassengersCapacity, expectedPassengerPlaneWithMaxPassengersCapacity);
        }

        [Test]
        public void SortByMaxLoadCapacity_Test()
        {
            var airport = new Airport(ApplicationData.Planes);
            airport = airport.SortByMaxLoadCapacity();
            var expectedPlanesSortedByMaxLoadCapacityDescending = airport.Planes.OrderBy(x => x.MaxLoadCapacity);
            var actualPanesSortedByMaxLoadCapacity = airport.Planes;
            Assert.AreEqual(expectedPlanesSortedByMaxLoadCapacityDescending, actualPanesSortedByMaxLoadCapacity);
        }
    }
}
