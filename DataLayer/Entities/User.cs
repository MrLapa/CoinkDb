namespace DataLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public User()
        {

        }
        public User(int id, string name, string phone, string address, City city)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            City = city;
        }
    }
}
