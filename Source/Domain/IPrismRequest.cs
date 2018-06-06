namespace Prism.Domain
{
    public interface IPrismRequest<TRequestData, TResponseData> where TRequestData : class, new()
    {
        string HttpMethod { get; set; }

        string ApiAbsolutePath { get; set; }

        string ApiMethod { get; set; }

        TRequestData Data { get; set; }
    }

    public class PrismRequestBase<TRequestData, TResponseData> : IPrismRequest<TRequestData, TResponseData> where TRequestData : class, new()
    {
        public virtual string HttpMethod { get; set; } = "POST";
        public virtual string ApiAbsolutePath { get; set; } = "api/oms";
        public virtual string ApiMethod { get; set; }
        public virtual TRequestData Data { get; set; }
    }
}
