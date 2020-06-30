using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp8
{
    public class AsyncStreams
    {
        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        public async static Task Run()
        {
            await foreach (var item in GenerateSequence())
            {
                Console.WriteLine(item);
            }
        }
    }
}
