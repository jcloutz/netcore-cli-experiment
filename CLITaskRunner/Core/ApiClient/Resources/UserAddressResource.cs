namespace CLITaskRunner.Core.ApiClient.Resources
{
    public class UserAddressResource
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public UserAddressGeoResource UserAddressGeo { get; set; }
    }
}