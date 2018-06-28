using BertoniTest.Library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static BertoniTest.Library.Models.Enums;

namespace BertoniTest.Library.Helpers
{
    public class Api
    {
        public static async Task<Response> WebRequestAsync(string _url, HttpMethod _method, object _data = null)
        {
            Response response = new Response();

            try
            {
                WebRequest request = WebRequest.Create(_url);

                request.Method = _method.ToString();
                request.ContentType = "application/json";

                if (_method == HttpMethod.POST && _data != null)
                {
                    Stream dataStream = await request.GetRequestStreamAsync();

                    using (StreamWriter requestWriter = new StreamWriter(dataStream))
                    {
                        string json = JsonConvert.SerializeObject(_data);

                        requestWriter.Write(json);
                    }
                }

                using (WebResponse wr = await request.GetResponseAsync())
                {
                    using (Stream receiveStream = wr.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8))
                        {
                            response.Message = reader.ReadToEnd();

                            response.Status = true;
                            response.Type = ResponseType.Success;

                            return response;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                response.Message = e.Message;
                response.Trace = e.StackTrace;
            }

            return response;
        }


    }
}
