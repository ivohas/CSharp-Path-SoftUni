using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class ImportUserDto
{
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    [JsonProperty("age")]
    public string? Age { get; set; }
}
