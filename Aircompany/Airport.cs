using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private List<Plane> _planes;
        public Airport(IEnumerable<Plane> planes) => _planes = planes.ToList();
        public List<Plane> Planes => _planes;

        public List<PassengerPlane> GetPassengerPlanes()=>
            _planes.OfType<PassengerPlane>().ToList();

        public List<MilitaryPlane> GetMilitaryPlanes() =>
            _planes.OfType<MilitaryPlane>().ToList();


        public List<MilitaryPlane> GetTransportMilitaryPlanes()=> 
            GetMilitaryPlanes().FindAll(x => x.Type == MilitaryType.TRANSPORT);
        
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity() =>
           GetPassengerPlanes().Aggregate((m, c) => m.PassengersCapacity > c.PassengersCapacity ? m : c);

        public Airport SortByMaxDistance() => new Airport(_planes.OrderBy(p => p.MaxFlightDistance));

        public Airport SortByMaxSpeed() => new Airport(_planes.OrderBy(p => p.MaxSpeed));

        public Airport SortByMaxLoadCapacity() => new Airport(_planes.OrderBy(p => p.MaxLoadCapacity));

        public override string ToString() => $"Airport: planes = {string.Join(", ", _planes.Select(x => x.Model))}\n";
    }
}
