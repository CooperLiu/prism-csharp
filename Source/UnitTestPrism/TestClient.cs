using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism;
using Prism.Client;
using Prism.Domain;
using Prism.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UnitTestPrism
{
    [TestClass]
    public class TestClient
    {

        [TestMethod]
        public async Task TestApi()
        {
            string host = "http://ximslkp4.apihub.cn";
            string key = "quxabf4t";
            string secret = "2ipua2a6jwslp6cq6fna";

            var client = new PrismHttpClient(host, key, secret);

            PrismParams p = new PrismParams();
            p["node_id"] = $"1087196531_1129944230";
            p["aftersale_id"] = "201802591615001";
            p["tid"] = "测试0180528105039929617";

            var res = await client.Execute<object>("POST", "api/oms", "store.trade.aftersale.add", p, null);

            Assert.IsNotNull(res);

        }

        [TestMethod]
        public async Task TestTradeRequestAPi()
        {
            #region 赋值
            var t = new StoreTradeAddRequestData();
            t.node_id = $"1087196531_1129944230";
            t.tid = $"742{DateTime.Now.Ticks}";
            t.title = $"724测试订单{DateTime.Now.Ticks}";
            t.created = DateTime.Now;
            t.modified = DateTime.Now;
            t.status = "TRADE_ACTIVE";
            t.pay_status = "PAY_FINISH";
            t.ship_status = "SHIP_NO";
            t.is_devlivery = false;
            t.is_cod = false;
            t.has_invoice = false;
            t.invoice_title = "";
            t.invoice_fee = "0.00";
            t.invoice_desc = "";
            t.total_goods_fee = "0.02";
            t.total_trade_fee = "0.02";
            t.discount_fee = "0.00";
            t.goods_discount_fee = "0.00";
            t.orders_discount_fee = "0.00";
            t.promotion_details = null;
            t.payed_fee = "0.02";
            t.currency = "CNY";
            t.currency_rate = "0.00";
            t.total_currency_fee = "0.02";
            t.buyer_obtain_point_fee = "0";
            t.point_fee = "0";
            t.shipping_tid = "11111111111";
            t.shipping_type = "SF";
            t.shipping_fee = "0";
            t.is_protect = "";
            t.protect_fee = "";
            t.payment_tid = "wechat";
            t.payment_type = "微信支付";
            t.pay_time = DateTime.Now;
            t.end_time = DateTime.Now;
            t.consign_time = DateTime.Now;
            t.trade_valid_time = DateTime.Now;
            t.receiver_name = "刘先生";
            t.receiver_email = "";
            t.receiver_state = "上海";
            t.receiver_city = "上海市";
            t.receiver_distric = "长宁区";
            t.receiver_address = "金钟路968号SOHO2号楼";
            t.receiver_zip = "000000";
            t.receiver_mobile = "13688886666";
            t.dreceiver_phone = "13688886666";
            t.receiver_time = "无";
            t.buyer_alipay_no = "alipayNo";
            t.buyer_id = "1213131313";
            t.buyer_uname = "Unknown";
            t.buyer_name = "刘先生";
            t.buyer_mobile = "13688886666";
            t.buyer_phone = "";
            t.buyer_email = "";
            t.buyer_state = "";
            t.buyer_city = "";
            t.buyer_district = "";
            t.buyer_address = "";
            t.buyer_zip = "";
            t.buyer_rate = "true";
            t.seller_uname = "";
            t.seller_rate = "";
            t.seller_alipay_no = "";
            t.seller_mobile = "";
            t.seller_phone = "";
            t.seller_memo = "";
            t.seller_flag = "";
            t.seller_name = "";
            t.seller_state = "";
            t.seller_city = "";
            t.seller_district = "";
            t.seller_address = "";

            t.seller_email = "";
            t.seller_zip = "000000";
            t.commission_fee = "0";

            t.shipper_name = "";
            t.shipper_phone = "";
            t.shipper_mobile = "";
            t.shipper_state = "";
            t.shipper_city = "";
            t.shipper_district = "";
            t.shipper_address = "";
            t.shipper_zip = "";
            t.shipper_email = "";

            t.trade_memo = "";
            t.pay_cost = "0";
            t.buyer_memo = "";
            t.buyer_flag = "";
            t.buyer_message = "";
            t.tradetype = "";
            t.orders_number = "1";//当前交易下子订单数量
            t.total_weight = "0";

            var order = new Order()
            {
                oid = t.tid,
                type = "goods",
                type_alias = "商品",
                iid = "11111",
                title = "测试订单",
                items_num = "1",
                total_order_fee = "0.02",
                weight = "0",
                discount_fee = "0",
                status = "TRADE_ACTIVE",
                ship_status = "SHIP_NO",
                pay_status = "PAY_FINISH",
                consign_time = "",
            };

            order.order_items = new OrderItemWrap()
            {
                item = new List<OrderItem>()
                {
                    new OrderItem(){ bn="ECS000470001",name="测试商品02",sku_id="1",sku_properties="商品属性",iid="1",weight="0",score="0",cost="0",price="0.02",sale_price="0.01",total_item_fee="0.01",num="1",sendnum="0",item_type="product",item_status="normal",promotion_id="",discount_fee="0" },
                }
            };

            t.orders = new OrderWrap() { order = new List<Order>() { order } };

            var p = new PaymentInfo();
            p.payment_id = "";
            p.tid = t.tid;
            p.seller_account = "313131313";
            p.buyer_id = "1379554443333";
            p.buy_name = "刘先生";
            p.buyer_account = "1111";
            p.pay_fee = "0.02";
            p.paycost = "0";
            p.currency = "CNY";
            p.currency_fee = "0.02";
            p.pay_type = "online";
            p.payment_code = "wepay";
            p.payment_name = "微信支付";
            p.t_begin = null;
            p.t_end = null;
            p.pay_time = DateTime.Now;
            p.status = "SUCC";
            p.memo = "微信支付";
            p.outer_no = "4006665555555545445555";

            t.payment_lists = new PaymentInfoWrap() { payment_list = new List<PaymentInfo>() { p } };

            var nv = NameValueConvertor.Convert(t);

            #endregion

            string host = "http://ximslkp4.apihub.cn";
            string key = "quxabf4t";
            string secret = "2ipua2a6jwslp6cq6fna";

            var client = new PrismHttpClient(host, key, secret);

            var res = await client.Execute<PrismHttpResponse<B2cOrderShipStatusUpdateResponseData>>("POST", "api/oms", "store.trade.add", nv, null);

            Assert.IsNotNull(nv);
        }

        [TestMethod]
        public void Test_NameValueConvertor_Convert()
        {
            var q = new RequestData();
            q.Id = "1111";
            q.Name = "订单";

            var i = new RequestDataItem();
            i.GoodsId = "LC001";
            i.GoodsName = "LC001名称";

            i.Items = new List<ItemInfo>()
            {
                new ItemInfo(){  ItemId="AAAAA", ItemName="aaaaaaaaaaaa",Created= DateTime.Now},
                new ItemInfo(){  ItemId="BBBBB", ItemName="bbbbbbbbbbb",Created= DateTime.Now},
                new ItemInfo(){  ItemId="CCCCC", ItemName="cccccccccccc",Created= DateTime.Now},
                new ItemInfo(){  ItemId="DDDDD", ItemName="dddddddddddd",Created= DateTime.Now},
            };

            q.DataItems = new List<RequestDataItem>() { i };

            var nv = NameValueConvertor.Convert(q);

            var str = nv.ToQueryString();

            Assert.IsNotNull(nv);

            var obj = NameValueConvertor.MapTo<RequestData>(nv);

            Assert.IsNotNull(obj);
        }

        [TestMethod]
        public async Task TestStoreTradeAddRequest()
        {
            #region 赋值
            var t = new StoreTradeAddRequestData();
            t.node_id = $"1087196531_1129944230";
            t.tid = $"742{DateTime.Now.Ticks}";
            t.title = $"724测试订单{DateTime.Now.Ticks}";
            t.created = DateTime.Now;
            t.modified = DateTime.Now;
            t.status = "TRADE_ACTIVE";
            t.pay_status = "PAY_FINISH";
            t.ship_status = "SHIP_NO";
            t.is_devlivery = false;
            t.is_cod = false;
            t.has_invoice = false;
            t.invoice_title = "";
            t.invoice_fee = "0.00";
            t.invoice_desc = "";
            t.total_goods_fee = "0.02";
            t.total_trade_fee = "0.02";
            t.discount_fee = "0.00";
            t.goods_discount_fee = "0.00";
            t.orders_discount_fee = "0.00";
            t.promotion_details = null;
            t.payed_fee = "0.02";
            t.currency = "CNY";
            t.currency_rate = "0.00";
            t.total_currency_fee = "0.02";
            t.buyer_obtain_point_fee = "0";
            t.point_fee = "0";
            t.shipping_tid = "11111111111";
            t.shipping_type = "SF";
            t.shipping_fee = "0";
            t.is_protect = "";
            t.protect_fee = "";
            t.payment_tid = "wechat";
            t.payment_type = "微信支付";
            t.pay_time = DateTime.Now;
            t.end_time = DateTime.Now;
            t.consign_time = DateTime.Now;
            t.trade_valid_time = DateTime.Now;
            t.receiver_name = "刘先生";
            t.receiver_email = "";
            t.receiver_state = "上海";
            t.receiver_city = "上海市";
            t.receiver_distric = "长宁区";
            t.receiver_address = "金钟路968号SOHO2号楼";
            t.receiver_zip = "000000";
            t.receiver_mobile = "13688886666";
            t.dreceiver_phone = "13688886666";
            t.receiver_time = "无";
            t.buyer_alipay_no = "alipayNo";
            t.buyer_id = "1213131313";
            t.buyer_uname = "Unknown";
            t.buyer_name = "刘先生";
            t.buyer_mobile = "13688886666";
            t.buyer_phone = "";
            t.buyer_email = "";
            t.buyer_state = "";
            t.buyer_city = "";
            t.buyer_district = "";
            t.buyer_address = "";
            t.buyer_zip = "";
            t.buyer_rate = "true";
            t.seller_uname = "";
            t.seller_rate = "";
            t.seller_alipay_no = "";
            t.seller_mobile = "";
            t.seller_phone = "";
            t.seller_memo = "";
            t.seller_flag = "";
            t.seller_name = "";
            t.seller_state = "";
            t.seller_city = "";
            t.seller_district = "";
            t.seller_address = "";

            t.seller_email = "";
            t.seller_zip = "000000";
            t.commission_fee = "0";

            t.shipper_name = "";
            t.shipper_phone = "";
            t.shipper_mobile = "";
            t.shipper_state = "";
            t.shipper_city = "";
            t.shipper_district = "";
            t.shipper_address = "";
            t.shipper_zip = "";
            t.shipper_email = "";

            t.trade_memo = "";
            t.pay_cost = "0";
            t.buyer_memo = "";
            t.buyer_flag = "";
            t.buyer_message = "";
            t.tradetype = "";
            t.orders_number = "1";//当前交易下子订单数量
            t.total_weight = "0";

            var order = new Order()
            {
                oid = t.tid,
                type = "goods",
                type_alias = "商品",
                iid = "11111",
                title = "测试订单",
                items_num = "1",
                total_order_fee = "0.02",
                weight = "0",
                discount_fee = "0",
                status = "TRADE_ACTIVE",
                ship_status = "SHIP_NO",
                pay_status = "PAY_FINISH",
                consign_time = "",
            };

            order.order_items = new OrderItemWrap()
            {
                item = new List<OrderItem>()
                {
                    new OrderItem(){ bn="ECS000470001",name="测试商品02",sku_id="1",sku_properties="商品属性",iid="1",weight="0",score="0",cost="0",price="0.02",sale_price="0.01",total_item_fee="0.01",num="1",sendnum="0",item_type="product",item_status="normal",promotion_id="",discount_fee="0" },
                }
            };

            t.orders = new OrderWrap() { order = new List<Order>() { order } };

            var p = new PaymentInfo();
            p.payment_id = "";
            p.tid = t.tid;
            p.seller_account = "313131313";
            p.buyer_id = "1379554443333";
            p.buy_name = "刘先生";
            p.buyer_account = "1111";
            p.pay_fee = "0.02";
            p.paycost = "0";
            p.currency = "CNY";
            p.currency_fee = "0.02";
            p.pay_type = "online";
            p.payment_code = "wepay";
            p.payment_name = "微信支付";
            p.t_begin = null;
            p.t_end = null;
            p.pay_time = DateTime.Now;
            p.status = "SUCC";
            p.memo = "微信支付";
            p.outer_no = "4006665555555545445555";

            t.payment_lists = new PaymentInfoWrap() { payment_list = new List<PaymentInfo>() { p } };

            var nv = NameValueConvertor.Convert(t);

            #endregion

            var request = new StoreTradeAddRequest();
            request.Data = t;

            string host = "http://ximslkp4.apihub.cn";
            string key = "quxabf4t";
            string secret = "2ipua2a6jwslp6cq6fna";

            var client = new PrismHttpClient(host, key, secret);


            var res = await client.Execute(request);

            Assert.IsNotNull(res);

        }

        [TestMethod]
        public void Test_DeserializeObject()
        {
            var jsonStr = "{\"res\": \"\", \"msg_id\": \"5B1786A40AAD2203731D7671C877BA3F\", \"err_msg\": \"\", \"data\": \"{\\\"msg\\\": \\\"\\\\u8fd4\\\\u56de\\\\u503c\\\\uff1a\\\\u8ba2\\\\u5355\\\\u521b\\\\u5efa\\\\u6210\\\\u529f\\\\uff01\\\\u8ba2\\\\u5355ID\\\\uff1a6483\\\", \\\"rsp\\\": \\\"succ\\\", \\\"data\\\": {\\\"tid\\\": \\\"742636638940478205580\\\"}}\", \"rsp\": \"succ\"}";

            var j1 = jsonStr.Replace("\"{", "{");
            var j2 = j1.Replace(@"\\\",@"\");
            var j3 = j2.Replace(@"\\\\","\\");

            var j4 = j3.Replace("}\"", "}");

            var jsonStr2 = "{\"res\": \"\", \"msg_id\": \"5B1786A40AAD2203731D7671C877BA3F\", \"err_msg\": \"\", \"data\": {\"msg\": \"\\u8fd4\\u56de\\u503c\\uff1a\\u8ba2\\u5355\\u521b\\u5efa\\u6210\\u529f\\uff01\\u8ba2\\u5355ID\\uff1a6483\", \"rsp\": \"succ\", \"data\": {\"tid\": \"742636638940478205580\"}}, \"rsp\": \"succ\"}";

            /*
             * 1. \"{ ===> {
             * 2. \\\" ==> \"
             * 3. \\\\ ==> \\
             * 4. }\" ===> }
             */
            var str1 = "{\"res\":\"\",  \"msg_id\":\"5B1786A40AAD2203731D7671C877BA3F\",  \"err_msg\":\"\",  \"data\":{\"msg\":\"\\u8fd4\\u56de\\u503c\\uff1a\\u8ba2\\u5355\\u521b\\u5efa\\u6210\\u529f\\uff01\\u8ba2\\u5355ID\\uff1a6483\",\"rsp\":\"succ\",\"data\":{\"tid\":\"742636638940478205580\"}}, \"rsp\":\"succ\",}";

            //var str = jsonStr.Replace(@"\\",@"\").Replace(@"\\\",@"\");

            // var obj = JsonConvert.DeserializeObject<PrismHttpResponse<StoreTradeAddResponseData>>(json.UnicodeDecode());

            var json = JToken.Parse(jsonStr);

            var jsonDataValue = json["data"];
            if (jsonDataValue.ToString() == "\"\"")
            {
                json["data"] = null;
            }


            //var d = new PrismHttpResponse<StoreTradeAddResponseData>();
            //d.Data = new StoreTradeAddResponseData()
            //{
            //    data = new ResponseData() { tid= "742636638940478205580" },
            //    rsp= "succ",
            //    msg= "返回值：订单创建成功！订单ID：6483"
            //};

            //d.Res = "";
            //d.MessageId = "5B1786A40AAD2203731D7671C877BA3F";
            //d.ErrorMessage = "";
            //d.Response = "succ";

            //var str = JsonConvert.SerializeObject(d);

            //System.Diagnostics.Debug.WriteLine(str);

           // var j = jsonDataValue.ToObject<>();





            var obj = json.ToObject<PrismHttpResponse<object>>();

            Assert.IsNotNull(obj);
        }

    }

    public class RequestData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonFormat(typeof(RequestDataItem))]
        public List<RequestDataItem> DataItems { get; set; }
    }

    public class RequestDataItem
    {
        public string GoodsId { get; set; }

        public string GoodsName { get; set; }

        public List<ItemInfo> Items { get; set; }
    }

    public class ItemInfo
    {
        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public DateTime Created { get; set; }
    }
}
