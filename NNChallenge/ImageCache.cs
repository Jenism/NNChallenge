using NNChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NNChallenge
{
    public class ImageCache : IImageCache
    {
        private static readonly Dictionary<string, byte[]> cache = new Dictionary<string, byte[]>();

        public byte[] Get(string url)
        {
            if (!cache.ContainsKey(url))
            {
                try
                {
                    using WebClient webClient = new WebClient();
                    byte[] image = webClient.DownloadData(url);

                    cache.Add(url, image);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            return cache[url];
        }
    }
}
