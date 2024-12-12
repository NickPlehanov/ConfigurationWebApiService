namespace ConfigurationWebApiService.CRUDModels
{
    public class ResponseModel<T>
    {
        public string Message { get; set; } = "ERROR";
        public int StatusCode { get; set; } = -1;
        public T? Value { get; set; }
        public object? Error { get; set; } = null;
    }
}
