using System;
using System.Threading.Tasks;

namespace CSharp8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AsyncStreams.Run();

            Console.ReadLine();
        }
    }
}
