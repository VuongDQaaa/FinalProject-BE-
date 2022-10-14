using backend.Helpers;
using backend.Interfaces;
using backend.Authorization;
using Microsoft.Extensions.Options;

namespace backend.AuthorizationStudent;
public class JwtMiddlewareStudent
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddlewareStudent(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IStudentService studentService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            context.Items["Student"] = studentService.GetById(userId.Value);

        }

        await _next(context);
    }
}