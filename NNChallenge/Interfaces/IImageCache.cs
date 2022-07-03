using System.Threading.Tasks;

namespace NNChallenge.Interfaces
{
    public interface IImageCache
    {
        byte[] Get(string url);
    }
}