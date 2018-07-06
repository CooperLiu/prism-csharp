using Newtonsoft.Json;

namespace Prism.Client
{

    public class PrismHttpBaseResponse<TReponseData>
    {
        public PrismHttpBaseResponse()
        {
            Res = "";
            Response = "succ";
        }

        [JsonProperty("res")]
        public string Res { get; set; }

        [JsonProperty("rsp")]
        public string Response { get; set; }

        [JsonProperty("data")]
        public TReponseData Data { get; set; }
    }

    public class PrismHttpResponse<TReponseData> : PrismHttpBaseResponse<TReponseData>
    {

        [JsonIgnore]
        public bool IsSuccess => Error == null && Response == "succ" && string.IsNullOrEmpty(ErrorMessage);

        [JsonProperty("error")]
        public ErrorInfo Error { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }


        [JsonProperty("err_msg")]
        public string ErrorMessage { get; set; }

        [JsonProperty("msg_id")]
        public string MessageId { get; set; }


    }

    public class ErrorInfo
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }


    public class PrismHttpResponse : PrismHttpResponse<object>
    {

    }


}
