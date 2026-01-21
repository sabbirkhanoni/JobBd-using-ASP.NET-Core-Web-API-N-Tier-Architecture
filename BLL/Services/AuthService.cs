using DAL;
using DAL.Interfaces;

public class AuthService
{
    DataAccessFactory factory;
    private IEmailService emailService;
    public AuthService(DataAccessFactory factory, IEmailService emailService)
    {
        this.factory = factory;
        this.emailService = emailService;
    }

    public bool Login(string email, string password)
    {
        var user = factory.AuthFeature().GetByEmail(email);
        if (user != null)
        {
            if (user.Password == password) return true;
        }
        return false;
    }

    public bool SendOtp(string email)
    {
        var user = factory.AuthFeature().GetByEmail(email);
        if (user == null) return false;

        user.otp = new Random().Next(100000, 999999).ToString();
        user.expiryTime = DateTime.Now.AddMinutes(5);

        var updated = factory.AuthFeature().Update(user);
        if (!updated) return false;

        string subject = "Your OTP Code";
        string body = $"<h3>Your OTP is: {user.otp}</h3><p>Valid for 5 minutes.</p>";

        return emailService.SendEmail(email, subject, body);
    }


    public bool VerifyOtp(string email, string otp)
    {
        var user = factory.AuthFeature().GetByEmail(email);
        if (user == null || user.otp != otp || user.expiryTime < DateTime.Now) return false;
        return true;
    }

    public bool ResetPassword(string email, string newPassword)
    {
        var user = factory.AuthFeature().GetByEmail(email);
        if (user == null || user.expiryTime < DateTime.Now) return false;
        user.Password = newPassword;
        return factory.AuthFeature().Update(user);
    }
}
