namespace CLITaskRunner.Core.ApiClient.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserAddressResource UserAddress { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public UserCompanyResource UserCompany { get; set; }
    }
}