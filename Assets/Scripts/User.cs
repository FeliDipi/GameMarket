using Newtonsoft.Json;

namespace OneFrame.Market.Core
{
    public class User
    {
        [JsonProperty("_id")] public string ID {get; private set;}
        [JsonProperty("name")] public string Name {get; private set;}
        [JsonProperty("email")] public string Email {get; private set;}
        [JsonProperty("balance")] public float Balance {get; private set;}

        public User(string id, string name, string email, float balance)
        {
            ID = id;
            Name = name;
            Email = email;
            Balance = balance;
        }
    }
}

