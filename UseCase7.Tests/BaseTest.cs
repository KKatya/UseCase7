namespace UseCase7.Tests
{
    public class BaseTest
    {
        protected void ThenErrorIsThrown<TException>(Action when) where TException : Exception
        {
            Assert.Throws<TException>(when);
        }
    }
}
