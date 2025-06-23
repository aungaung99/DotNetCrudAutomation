namespace DotNetCrudAutomation.Model
{
    public class DefaultResponseModel
    {
        public required bool Success { get; set; }
        public required int Code { get; set; }
        public dynamic? Meta { get; set; }
        public dynamic? Data { get; set; }
        public dynamic? Error { get; set; }
    }

    public class DefaultResponseModel<T>
    {
        public required bool Success { get; set; }
        public required int Code { get; set; }
        public dynamic? Meta { get; set; }
        public T? Data { get; set; }
        public dynamic? Error { get; set; }
    }

    public class DefaultResponseMessageModel
    {
        public string EN { get; set; } = null!;
        public string MM { get; set; } = null!;
    }
}
