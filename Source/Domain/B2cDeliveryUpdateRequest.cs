namespace Prism.Domain
{

    public class B2cDeliveryUpdateRequest : PrismWebhookRequestBase<B2cDeliveryUpdateRequestData, B2cDeliveryUpdateResponseData>
    {
        public override string ApiMethod { get; set; } = "b2c.delivery.update";
    }

    /// <summary>
    /// b2c.delivery.update 更新发货单物流信息
    /// </summary>
    public class B2cDeliveryUpdateRequestData: B2cDeliveryCreateRequestData
    {
        
    }
}
