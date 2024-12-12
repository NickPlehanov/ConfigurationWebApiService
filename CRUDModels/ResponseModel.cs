namespace ConfigurationWebApiService.CRUDModels
{
    public class ResponseModel
    {
        public string Message { get; set; } = "ERROR";
        public int StatusCode { get; set; } = -1;
        public object? Value { get; set; } = null;
        public object? Error { get; set; } = null;
    }
}
