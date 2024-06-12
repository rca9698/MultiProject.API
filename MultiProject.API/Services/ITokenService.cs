namespace MultiProject.API.Services
{
    public interface ITokenService
    {
        object GenerateToken(long userId, string otp);
    }
}
