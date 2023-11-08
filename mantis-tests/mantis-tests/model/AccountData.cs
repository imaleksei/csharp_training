namespace mantis_tests
{
    public class AccountData
    {
        public AccountData(string username, string password)
        {
            this.Name = username;
            this.Password = password;
        }
        public AccountData()
        {

        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}