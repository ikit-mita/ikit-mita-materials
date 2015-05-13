namespace Server.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    [SecurityTokenBehavior]
    public class TestService : ITestService
    {
        public string Test(string request)
        {
            return "responce";
        }
    }
}
