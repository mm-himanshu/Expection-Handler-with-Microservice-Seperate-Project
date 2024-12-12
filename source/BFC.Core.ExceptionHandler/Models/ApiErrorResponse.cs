namespace ExceptionHandler.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        
        public override string ToString()
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            var serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(this,serializerSettings);
        }
    }
}
