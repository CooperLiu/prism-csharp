namespace Prism.Domain
{
    /// <summary>
    /// store.trade.update 订单更新 支付单 支付变更都是通过订单更新接口完成    /// </summary>
    public class StoreTradeUpdateRequest : PrismRequestBase<StoreTradeUpdateRequestData, StoreTradeAddResponseData>
    {
        public override string ApiMethod { get; set; } = "store.trade.update";
    }

    /// <summary>
    /// store.trade.update 订单更新 支付单 支付变更都是通过订单更新接口完成
    /// </summary>
    public class StoreTradeUpdateRequestData : StoreTradeAddRequestData
    {
    }
}
