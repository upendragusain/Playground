using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGeneral
{
    public class LocalFunctions
    {
        public static IEnumerable<int> OddSequence(int start, int end)
        {
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException("start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException("end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                    yield return i;
            }
        }

        public static IEnumerable<int> OddSequenceWithLocalFunction(int start, int end)
        {
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException("start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException("end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            return GetOddSequenceEnumerator();

            IEnumerable<int> GetOddSequenceEnumerator()
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 1)
                        yield return i;
                }
            }
        }

        public static async Task<string> DownloadPage(string url)
        {
            if (url.Length < 5)
                throw new ArgumentException("Invaid url");

            await Task.Delay(TimeSpan.FromSeconds(2));
            return "html content";
        }

        /*
         * Ordinarily, exceptions thrown in async method require that you examine the inner exceptions of an AggregateException. Local functions allow your code to fail fast and allow your exception to be both thrown and observed synchronously.
         */
        public static Task<string> DownloadPageWithLocalFunction(string url)
        {
            if (url.Length < 5)
                throw new ArgumentException("Invaid url");

            return GetPageAsync();

            async Task<string> GetPageAsync()
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                return "html content";
            }
        }
    }
}
