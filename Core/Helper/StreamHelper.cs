using System.IO;
using System.Net.Sockets;

namespace Core.Helper
{
    public static class StreamHelper
    {
        /// <summary>
        /// Convertation to memory stream
        /// </summary>
        /// <param name="stm">Input stream</param>
        /// <returns></returns>
        public static byte[] ConvertNetworkstreamToArray(NetworkStream stm)
        {
            byte[] resp = new byte[2048];
            var memStream = new MemoryStream();
            var bytes = 0;
            //client.Client.ReceiveTimeout = 20;
            do
            {
                try
                {
                    bytes = stm.Read(resp, 0, resp.Length);
                    memStream.Write(resp, 0, bytes);
                }
                catch (IOException ex)
                {
                    // if the ReceiveTimeout is reached an IOException will be raised...
                    // with an InnerException of type SocketException and ErrorCode 10060
                    var socketExept = ex.InnerException as SocketException;
                    if (socketExept == null || socketExept.ErrorCode != 10060)
                        // if it's not the "expected" exception, let's not hide the error
                        throw ex;
                    // if it is the receive timeout, then reading ended
                    bytes = 0;
                }
            } while (bytes > 0);
            return memStream.ToArray();
        }
    }
}
