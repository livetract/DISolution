namespace ConsoleApp.Services
{
    public class SignInManager : ITestService
    {
        public bool Signin(string uid, string pwd)
        {
            return uid.Equals("jim") && pwd.Equals("123");
        }
    }
}
