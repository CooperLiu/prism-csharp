using System;

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
        public TRequestData Data { get; set; }

        public PrismRequestBase(TRequestData data)
        {
            Data = data;
        }
    }

    /// <summary>
    /// 商派回调请求基类
    /// </summary>
    /// <typeparam name="TRequestData"></typeparam>
    /// <typeparam name="TResponseData"></typeparam>
    public abstract class PrismWebhookRequestBase<TRequestData, TResponseData> : IPrismRequest<TRequestData, TResponseData> where TRequestData : class, new()
    {
        /// <summary>
        /// 请求方式
        /// </summary>
        public virtual string HttpMethod { get; set; } = "POST";

        /// <summary>
        /// 回调接口绝对地址
        /// </summary>
        public virtual string ApiAbsolutePath { get; set; } = "api/Eshop";

        /// <summary>
        /// 接口方法名
        /// </summary>
        public virtual string ApiMethod { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 请求数据
        /// </summary>
        public TRequestData Data { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public TResponseData Response { get; set; }
    }
}
