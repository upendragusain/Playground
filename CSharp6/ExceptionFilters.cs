using System;

namespace CSharp6
{
	public class ExceptionFilters
    {
        public static void Run()
        {
			try
			{
				var a = 0;
				var x = 10 / a;
			}
			catch (Exception ex) when (ex.Message.Contains("zero"))
			{
				Console.WriteLine("zer00000");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
    }
}
