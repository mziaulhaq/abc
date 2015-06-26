#region Using

using System;
using System.IO;
using System.Web;

#endregion

namespace Ecommerce.App_Start
{
    /// <summary>
    /// Removes whitespace from the webpage.
    /// </summary>
    public class ViewstateModule : IHttpModule
    {

        #region IHttpModule Members

        void IHttpModule.Dispose()
        {
            // Nothing to dispose; 
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        #endregion

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            if (app.Request.Url.OriginalString.Contains(".aspx"))
            {
                app.Response.Filter = new ViewstateFilter(app.Response.Filter);
            }
        }

        #region Stream filter

        private class ViewstateFilter : Stream
        {

            public ViewstateFilter(Stream sink)
            {
                _sink = sink;
            }

            private Stream _sink;

            #region Properites

            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanSeek
            {
                get { return true; }
            }

            public override bool CanWrite
            {
                get { return true; }
            }

            public override void Flush()
            {
                _sink.Flush();
            }

            public override long Length
            {
                get { return 0; }
            }

            private long _position;
            public override long Position
            {
                get { return _position; }
                set { _position = value; }
            }

            #endregion

            #region Methods

            public override int Read(byte[] buffer, int offset, int count)
            {
                return _sink.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _sink.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _sink.SetLength(value);
            }

            public override void Close()
            {
                _sink.Close();
            }

            private int startPoint;
            private int endPoint;
            public override void Write(byte[] buffer, int offset, int count)
            {
                byte[] data = new byte[count];
                Buffer.BlockCopy(buffer, offset, data, 0, count);
                string html = System.Text.Encoding.Default.GetString(buffer);
                if(startPoint==0)
                {
                    startPoint = html.IndexOf("<input type=\"hidden\" name=\"__VIEWSTATE\"");
                }
                
                if (startPoint > 0)
                {
                    if(endPoint == 0)
                    endPoint = html.IndexOf("/>", startPoint) + 2;
                    string viewstateInput = html.Substring(startPoint, endPoint - startPoint);
                    html = html.Remove(startPoint, endPoint - startPoint);
                    int formEndStart = html.IndexOf("</form>") - 1;
                    if (formEndStart >= 0)
                    {
                        html = html.Insert(formEndStart, viewstateInput);
                    }
                }

                byte[] outdata = System.Text.Encoding.Default.GetBytes(html);
                _sink.Write(outdata, 0, outdata.GetLength(0));
            }

            #endregion

        }

        #endregion

    }
}
