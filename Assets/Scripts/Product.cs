using Newtonsoft.Json;

namespace OneFrame.Market.Core
{
    public class Product
    {
        [JsonProperty("_id")] public string ID {get; private set;}
        [JsonProperty("name")] public string Name {get; private set;}
        [JsonProperty("description")] public string Description {get; private set;}
        [JsonProperty("price")] public float Price {get; private set;}
        [JsonProperty("reference")] public string Reference {get; private set;}

        public Product(string id, string name, string description, float price, string reference)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Reference = reference;
        }   
    }
}