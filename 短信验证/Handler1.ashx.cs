using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;
namespace WebApplication1
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        // 短信应用 SDK AppID
        int appid = ;

        // 短信应用 SDK AppKey
        string appkey = "";

        // 需要发送短信的手机号码
        string[] phoneNumbers = { "17671873252" };

        // 短信模板 ID，需要在短信控制台中申请
        int templateId = 7839; // NOTE: 这里的模板 ID`7839`只是示例，真实的模板 ID 需要在短信控制台中申请

        // 签名
        string smsSign = "腾讯云"; // NOTE: 签名参数使用的是`签名内容`，而不是`签名ID`。这里的签名"腾讯云"只是示例，真实的签名需要在短信控制台申请
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string code = new Random().Next(1000, 10000).ToString();
                SmsSingleSender ssender = new SmsSingleSender(appid, appkey);
                var result = ssender.send(0, "86", phoneNumbers[0],
          "【软谋教育】你的验证码为："+ code + "，请于2分钟内填写。如非本人操作，请忽略本短信。", "", "");
                if (result.errMsg == "OK")
                {
                    context.Response.Write(code);
                }
                else {
                    context.Response.Write("error");
                }
            }
            catch (JSONException e)
            {
                context.Response.Write("error");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}