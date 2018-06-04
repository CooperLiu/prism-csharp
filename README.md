# Prism C# sdk

Refact this Sdk, added some features in it.

- Upgraded dotnet framework version from 2.0 to 4.6.1
- Using HttpClient instead of HttpWebRequest
- Defined domain object of request parameters
- Defined request and response base class



Don't Repeat Yourself, leaving mess apis ,saving your time, enjoy your time.





Deps framework 2.0

依赖第三方模块
PM> Install-Package WebSocket4Net -Version 0.11.0

## Usage:

```
using Prism;

string host = "http://avvtupnm.local:8080/api";
string key = "umjj5xj6";
string secret = "xa4k7gzyemzjkscapdjb";

PrismDotNet prism = new PrismDotNet(host, key, secret);

PrismParams p = new PrismParams();
p["e"] = "va";
p["c"] = "va";
p["b"] = "vb";
p["0"] = "v0";

PrismResponse rsp = prism.Client().Get("platform/notify/status", p);
Console.WriteLine(rsp.RequestId);
Console.WriteLine(rsp);


```

## OAuth:

```
string redirectUri = "http://example.com/path/to/action/";
string oauthUri = prism.OAuth().OAuthUri(redirectUri);
/*
 * 访问 oauthUri 验证后返回 code
 */

string token = prism.OAuth().RequireOAuth(code);

```

## Notify:

```
public void OnGetDelivery(object sender, PrismNotify.GetDeliveryEventArgs e)
{
    /*do something with this.Deli
         * ......
         */
}

prism.Notify().GetDelivery += OnGetDelivery;

/// 推送一条消息
/// routingKey 队列标示
/// message 需要发送的信息
prism.Notify().Publish(routingKey, message)

/// 请求一条消息
prism.Notify().Consume();

/// 删除一条消息
/// tag 消息tag
prism.Notify().Ack(tag);
```

