namespace DataLayer.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public City()
        {

        }
        public City(int id, string name, Department department)
        {
            Id = id;
            Name = name;
            Department = department;
        }
    }
}
