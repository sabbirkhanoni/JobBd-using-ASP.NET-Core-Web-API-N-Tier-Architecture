using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private AuthService service;

    public AuthController(AuthService service)
    {
        this.service = service;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO dto)
    {
        var response = service.Login(dto.Email, dto.Password);
        if (response) return Ok("Login successful");
        return Unauthorized("Invalid email or password");
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok("Logout successful");
    }

    [HttpPost("send-otp")]
    public IActionResult SendOtp(SendOtpDTO dto)
    {
        var response = service.SendOtp(dto.Email);
        if (response) return Ok("OTP sent");
        return NotFound("Email not found");
    }

    [HttpPost("verify-otp")]
    public IActionResult VerifyOtp(VerifyOtpDTO dto)
    {
        var response = service.VerifyOtp(dto.Email, dto.Otp);
        if (response) return Ok("OTP verified");
        return BadRequest("Invalid or expired OTP");
    }

    [HttpPost("reset-password")]
    public IActionResult ResetPassword(ResetPasswordDTO dto)
    {
        var response = service.ResetPassword(dto.Email, dto.NewPassword);
        if (response) return Ok("Password reset successful");
        return BadRequest("OTP expired or invalid email");
    }
}
