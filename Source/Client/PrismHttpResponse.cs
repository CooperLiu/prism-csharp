using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Prism.Client
{

    public class PrismHttpBaseResponse<TData>
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
        public TData Data { get; set; }
    }

    public class PrismHttpResponse<TData> : PrismHttpBaseResponse<TData>
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
