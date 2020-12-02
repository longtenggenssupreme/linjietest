using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonTools
{
    /// <summary>
    /// 常用工具类
    /// </summary>
    public partial class CommonTool
    {
        #region Fields and Properties
        public static JsonSerializerSettings SettingISO = null;
        #endregion

        #region Methods
        public CommonTool()
        {
            SettingISO = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            IsoDateTimeConverter iso = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            //iso.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
            //iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            SettingISO.Converters.Add(iso);
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值，包括边界</param>
        /// <param name="max">最大值，不包括边界</param>
        /// <returns>取随机数</returns>
        public int GetRandomNumber(int min, int max)
        {
            //每次全新的id，全球唯一
            Guid guid = new Guid();
            string guidstr = guid.ToString();
            int seed = DateTime.Now.Millisecond;
            //保证sed在同一时刻 是不相同的
            for (int i = 0; i < guidstr.Length; i++)
            {
                switch (guidstr[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed += 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed += 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed += 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed += 3;
                        break;
                    default:
                        seed += 4;
                        break;
                }
            }
            Random random = new Random(seed);
            int randomNum = random.Next(min, max);
            return randomNum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int GetRandomNumberDelay(int min, int max)
        {
            //随即休息一下，再次避免产生相同的随机数
            Thread.Sleep(GetRandomNumber(500, 1000));
            //Task.Delay(500);
            return GetRandomNumber(min, max);
        }

        public string GetHttpPost()
        {
            //Encoding myEncoding = Encoding.GetEncoding("gb2312");
            PaymentData payment = new PaymentData { CodeBase64 = "1111111", ServiceId = "2222", Timeout = 60, IsEnd = true };
            string data = "sn=123&lanMac=6666&wifiMac=8888&wifi=张三";
            data = JsonConvert.SerializeObject(payment, Formatting.Indented, SettingISO);
            byte[] bytesToPost = Encoding.Default.GetBytes(data);

            string responseResult = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:27100/Terminal?t=Payment&code=base64&serviceId=32101412123&timeout=60&end=0");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
            req.ContentLength = bytesToPost.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bytesToPost, 0, bytesToPost.Length);
            }
            HttpWebResponse cnblogsRespone = (HttpWebResponse)req.GetResponse();
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                }
                sr.Close();
            }
            cnblogsRespone.Close();
            return responseResult;
        }

        public string GetHttp()
        {
            Encoding myEncoding = Encoding.GetEncoding("gb2312");
            string data = "sn=123&lanMac=6666&wifiMac=8888&wifi=张三";
            byte[] bytesToPost = Encoding.Default.GetBytes(data);

            string responseResult = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:27100/Terminal?t=Payment&code=base64&serviceId=32101412123&timeout=60&end=0");
            req.Method = WebRequestMethods.Http.Get;
            //req.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
            //req.ContentLength = bytesToPost.Length;

            //using (Stream reqStream = req.GetRequestStream())
            //{
            //    reqStream.Write(bytesToPost, 0, bytesToPost.Length);
            //}
            HttpWebResponse cnblogsRespone = (HttpWebResponse)req.GetResponse();
            if (cnblogsRespone != null && cnblogsRespone.StatusCode == HttpStatusCode.OK)
            {
                StreamReader sr;
                using (sr = new StreamReader(cnblogsRespone.GetResponseStream()))
                {
                    responseResult = sr.ReadToEnd();
                }
                sr.Close();
            }
            cnblogsRespone.Close();
            return responseResult;
        }
        #endregion
    }

    #region Test
    /// <summary>
    /// 付款码传输对象
    /// </summary>
    public class PaymentData
    {
        /// <summary>
        /// 付款码Base64字符串
        /// </summary>
        public string CodeBase64 { get; set; }

        /// <summary>
        /// 服务单号
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 结束标记
        /// </summary>
        public bool IsEnd { get; set; }
    }

    public class CustomJsonSerializer
    {
        public static JsonSerializerSettings Setting = null;
        public static JsonSerializerSettings SettingISO = null;
        public CustomJsonSerializer()
        {
            Setting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            SettingISO = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            IsoDateTimeConverter iso = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
            };
            SettingISO.Converters.Add(iso);

            // IsoDateTimeConverter iso = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            // iso.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
            //// iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            // //JavaScriptDateTimeConverter java;
            JavaScriptDateTimeConverter java = new JavaScriptDateTimeConverter();

            Setting.Converters.Add(java);
        }
    }
    #endregion
}
