using Microsoft.AspNetCore.Mvc;
namespace back.Controllers;

[ApiController]
[Route("teste")]
public class testeController : ControllerBase
{
    [HttpGet ("getTeste")]
    public List<string> getTeste(){
        return new List<string>()
        {
            "teste1",
            "teste2",
            "teste3"
        };
    }
}
