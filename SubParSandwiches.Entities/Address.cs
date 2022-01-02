namespace SubParSandwiches.Entities
{
    public class Address
    {
        public Address()
        {

        }
        public Address(string street, string county, string city, string postcode)
        {
            Street = street;
            City = city;
            County = county;
            Postcode = postcode;
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
    }
}
