namespace CLITaskRunner.Core.Models
{
    public class UserAddress
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public UserAddressGeo UserAddressGeo { get; set; }
    }
}