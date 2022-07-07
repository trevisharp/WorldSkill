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

    [HttpGet ("cep")]
    public async void getcep(string cep){
        var client = new HttpClient();
        var response = await client.GetAsync($"http://ws.apicep.com/cep/{cep}.json");

        // return Ok(response.Content.ReadAsStringAsync());
    }
}
