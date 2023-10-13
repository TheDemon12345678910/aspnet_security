using api.Filters;
using api.TransferModels;
using Microsoft.AspNetCore.Mvc;
using service;

namespace api.Controllers;

[RequireAuthentication]
public class UserController : ControllerBase
{
    
    
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet("/api/users")]
    public ResponseDto Get()
    {
        return new ResponseDto
        {
            MessageToClient = "Successfully fetched",
            ResponseData = _service.GetAll()
        };
    }
    
    [HttpGet]
    [Route("/api/account/whoami")]
    public ResponseDto WhoAmI()
    {
        var data = HttpContext.GetSessionData();
        var user = _service.Get(data);
        return new ResponseDto
        {
            ResponseData = user
        };
    }
    
}