using System;
using System.Collections.Generic;
using System.Text;
using WebSocket4Net;

//websockets 消息系统
namespace Prism
{
    class Notify
    {
        /*
        WebSocket websocket = new WebSocket("ws://localhost:2012/");
        websocket.Opened += new EventHandler(websocket_Opened);
        websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
        websocket.Closed += new EventHandler(websocket_Closed);
        websocket.MessageReceived += new EventHandler(websocket_MessageReceived);
        websocket.Open();

        private void websocket_Opened(object sender, EventArgs e)
        {
             websocket.Send("Hello World!");
        }   
         */
        private WebSocket websocket;

        public const byte COMMAND_PUBLISH = 1;
        public const byte COMMAND_CONSUME = 2;
        public const byte COMMAND_ACK = 3;

        public Notify(string server)
        {
            
        }

        //发布消息
        public void Publish(string routingKey, string message)
        {
        
        }

        //确认消息
        public void Ack()
        {
            
        }

        //获取消息
        public void Consume()
        {
            
        }
    }
}
