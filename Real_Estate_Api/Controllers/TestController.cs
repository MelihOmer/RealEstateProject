using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Real_Estate_Api.Controllers
{
    [Route("api/[controller]")]
  

    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://data.ibb.gov.tr/api/3/action/datastore_search?resource_id=8e132527-2eb7-4d68-a549-d224d233ab16&limit=5");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<Rootobject>(jsonData);
            var data = value.result.records[0];
            return Ok(data);
        }
    }
}
public class Rootobject
{
    public string help { get; set; }
    public bool success { get; set; }
    public Result result { get; set; }
}

public class Result
{
    public bool include_total { get; set; }
    public string resource_id { get; set; }
    public Field[] fields { get; set; }
    public string records_format { get; set; }
    public Record[] records { get; set; }
    public int limit { get; set; }
    public _Links _links { get; set; }
    public int total { get; set; }
}

public class _Links
{
    public string start { get; set; }
    public string next { get; set; }
}

public class Field
{
    public string type { get; set; }
    public string id { get; set; }
    public Info info { get; set; }
}

public class Info
{
    public string notes { get; set; }
    public string type_override { get; set; }
    public string label { get; set; }
}

public class Record
{
    public int _id { get; set; }
    public int Yil { get; set; }
    public string BiletAdi { get; set; }
    public float FiyatiL { get; set; }
}

