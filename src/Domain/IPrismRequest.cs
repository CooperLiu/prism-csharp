namespace Prism.Domain
{
    public interface IPrismRequestRoute
    {
        string HttpMethod { get; set; }

        string ApiAbsolutePath { get; set; }

        string ApiMethod { get; set; }
    }

    public interface IPrismRequest<TRequestData, TResponseData> : IPrismRequestRoute where TRequestData : class, new()
    {
        TRequestData Data { get; set; }
    }

    /// <summary>
    /// 请求商派系统接口基类
    /// </summary>
    /// <typeparam name="TRequestData"></typeparam>
    /// <typeparam name="TResponseData"></typeparam>
    public abstract class PrismRequestBase<TRequestData, TResponseData> : IPrismRequest<TRequestData, TResponseData> where TRequestData : class, new()
    {
        public virtual string HttpMethod { get; set; } = "POST";
        public virtual string ApiAbsolutePath { get; set; } = "api/oms";
        public virtual string ApiMethod { get; set; }
        public virtual TRequestData Data { get; set; }
    }

    /// <summary>
    /// 商派回调请求基类
    /// </summary>
    /// <typeparam name="TRequestData"></typeparam>
    /// <typeparam name="TResponseData"></typeparam>
    public abstract class PrismWebhookRequestBase<TRequestData, TResponseData> : IPrismRequest<TRequestData, TResponseData> where TRequestData : class, new()
    {
        public virtual string HttpMethod { get; set; } = "POST";
        public virtual string ApiAbsolutePath { get; set; } = "api/Eshop";
        public virtual string ApiMethod { get; set; }
        public TRequestData Data { get; set; }

        public TResponseData Response { get; set; }
    }
}
