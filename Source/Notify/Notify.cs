using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WebSocket4Net;
using System.IO;



namespace Prism.Notify
{
    //websockets 消息系统
    public class PrismNotify
    {
        

        
        private WebSocket _webSocket;

        private string _token;

        private string _notifyServer;

        private string _userAgent;

        /// <summary>
        /// 获取消息对象后处理的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GetDeliveryEventHandler(Object sender, GetDeliveryEventArgs e);
        public event GetDeliveryEventHandler GetDelivery;

        public class GetDeliveryEventArgs : EventArgs
        {
            public readonly PrismDelivery Deli;
            public GetDeliveryEventArgs(PrismDelivery delivery)
            {
                this.Deli = delivery;
            }
        }

        /// <summary>
        /// 消息服务器路径
        /// </summary>
        public string PathToNotify = "platform/notify";

        /// <summary>
        /// 消息对象
        /// </summary>
        public PrismDelivery Deli;

        public const byte COMMAND_PUBLISH = 0x01;
        public const byte COMMAND_CONSUME = 0x02;
        public const byte COMMAND_ACK = 0x03;

        public PrismNotify(string notifyServer)
            :this(null, null, notifyServer)
        {
            
        }

        public PrismNotify(string token, string userAgent, string notifyServer)
        {
            this._token = token;
            this._userAgent = userAgent;
            this._notifyServer = notifyServer;

            this.CreateWSConn();
           
        }

        /// <summary>
        /// 创建websocket链接
        /// </summary>
        private void CreateWSConn()
        {
            List<KeyValuePair<string, string>> header = new List<KeyValuePair<string, string>>();

            if (this._userAgent != null)
            {
                KeyValuePair<string, string> agentHeader = new KeyValuePair<string, string>("User-Agent", this._userAgent);
                header.Add(agentHeader);

            }
            
            if (this._token != null)
            {
                KeyValuePair<string, string> tokenHeader = new KeyValuePair<string, string>("Authorization", "Bearer "+ this._token);
                header.Add(tokenHeader);
            }

            this._webSocket = new WebSocket(this.GetWSAddr(), String.Empty, null, header, this._userAgent, WebSocketVersion.None);

            this._webSocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(OnMessage);
        }

        /// <summary>
        /// 打开websocket链接
        /// </summary>
        public void Open()
        {
            this._webSocket.Open();
        }

        /// <summary>
        /// 关闭websocket链接
        /// </summary>
        public void Close()
        {
            this._webSocket.Close();
        }

        /// <summary>
        /// 获取websocket 服务器地址
        /// e.g. ws://example.com/path/to/
        /// </summary>
        /// <returns></returns>
        public String GetWSAddr()
        {
            if (this._notifyServer[this._notifyServer.Length - 1] != '/')
            {
                this._notifyServer += "/";
            }

            this._notifyServer.Replace("http://", "ws://");
            this._notifyServer.Replace("https://", "ws://");

            if (this._notifyServer.IndexOf("ws://") < 0)
            {
                this._notifyServer = "ws://" + this._notifyServer;
            }

            return this._notifyServer + this.PathToNotify;
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="routingKey">服务路由名称</param>
        /// <param name="msg">需要发送的字符串</param>
        public void Publish(string routingKey, string msg)
        {
            byte[] data = this.AssemblePublishData(routingKey, msg);
            this.SendAll(data);

        }

        /// <summary>
        /// 应答消息并删除，注意此方法会导致该条消息不可恢复
        /// </summary>
        public void Ack(string tag)
        {
            byte[] data = this.AssembleAckData(tag);
            this.SendAll(data);
        }
   
        /// <summary>
        /// 请求消息
        /// </summary>
        public void Consume()
        {
            byte[] data = this.AssembleCosumeData();
            this.SendAll(data);
        }

        private void SendAll(byte[] data)
        {
            this._webSocket.Send(data, 0, data.Length);
        }

        /// <summary>
        /// 用来处理接收的到的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void OnMessage(object sender, MessageReceivedEventArgs e)
        {
            Debug.WriteLine(e.Message);
            try
            {
                PrismDelivery delivery = Newtonsoft.Json.JsonConvert.DeserializeObject<PrismDelivery>(e.Message);

                GetDeliveryEventArgs args = new GetDeliveryEventArgs(delivery);

                this.GetDelivery = OnGetDelivery;
                this.GetDelivery(this, args);

            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        /// <summary>
        /// 用户实现的方法 或者 this.GetDelivery += some EventHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">e.Deli 为消息对象</param>
        public virtual void OnGetDelivery(object sender, GetDeliveryEventArgs e)
        {
            /*do something with this.Deli
                 * ......
                 */
        }

        /// <summary>
        /// 封装publish
        /// </summary>
        /// <param name="routingKey">路由路径</param>
        /// <param name="message">推送的消息</param>
        /// <returns></returns>
        private byte[] AssemblePublishData(string routingKey, string message)
        {
            byte[] action = new byte[] {COMMAND_PUBLISH};
            byte[] keyLen = BitConverter.GetBytes((short)routingKey.Length);
            byte[] key = Encoding.Default.GetBytes(routingKey);
            byte[] msgLen = BitConverter.GetBytes((short)message.Length);
            byte[] msg = Encoding.Default.GetBytes(message);
            byte[] contentType = Encoding.Default.GetBytes("text/plain");

            byte[] all = new byte[action.Length + keyLen.Length + key.Length +  msgLen.Length + msg.Length + contentType.Length];

            Stream s = new MemoryStream(); 
            s.Write(action, 0, action.Length);
            s.Write(keyLen, 0, keyLen.Length);
            s.Write(key, 0, key.Length);
            s.Write(msgLen, 0, msgLen.Length);
            s.Write(msg, 0, msg.Length);
            s.Write(contentType, 0, contentType.Length);

            s.Position = 0;
            int r = s.Read(all, 0, all.Length);

            if (r > 0)
            {
                return all;
            }
            return null;
        }

        /// <summary>
        /// 封装cosume
        /// </summary>
        /// <returns></returns>
        private byte[] AssembleCosumeData()
        {
            return new byte[] {COMMAND_CONSUME};
        }

        /// <summary>
        /// 封装ack
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private byte[] AssembleAckData(string tag)
        {
            byte[] action = new[] {COMMAND_ACK};
            byte[] t = Encoding.Default.GetBytes(tag);

            byte[] all = new byte[action.Length + t.Length];

            Buffer.BlockCopy(action, 0, all, 0, action.Length);
            Buffer.BlockCopy(t, 0, all, action.Length, t.Length);

            return all;
        }
    }
}
