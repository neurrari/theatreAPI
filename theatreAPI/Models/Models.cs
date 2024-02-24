using System.Data.SqlTypes;

namespace theatreAPI.Models
{
    public class TypeOfStoring
    {
        public int Id{ get; set; }
        public string NameTypeOfStoring { get; set; }
    }

    public class ReceptionWays
    {
        public int Id { get; set; }
        public string NameReceptionWay { get; set; }
    }

    public class WorkTechnique
    {
        public int Id { get; set; }
        public string NameTechnique { get; set; }
        public string Material {  get; set; }
    }

    public class StoragePlaces
    {
        public int Id { get; set; }
        public int AmountOfPlaces { get; set; }
    }

    public class Position
    {
        public int Id { get; set; }
        public string NamePosition { get; set; }
        public decimal Salary { get; set; }
    }
}
