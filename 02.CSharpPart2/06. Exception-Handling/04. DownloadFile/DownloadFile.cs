using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        try
        {
            WebClient downloader = new WebClient();
            downloader.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../Logo-BASD.jpg");
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Path is null");
        }
        catch (WebException)
        {
            Console.Error.WriteLine("The address is invalid.");
        }
        catch (NotSupportedException)
        {
            Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
        }
    }
}

