using System;


public delegate void DownloadCompleted(string fileName); //  Define a delegate

//**************  Define an event in a class ************
public class FileDownloader
{
    public event DownloadCompleted DownloadCompleted;

    public void DownloadFile(string fileName)
    {
        Console.WriteLine($"Downloading {fileName}..."); 
        Thread.Sleep(1000); 

       

        Console.WriteLine($"{fileName} download finished.");
        DownloadCompleted?.Invoke(fileName);
    }
}

//****************** Subscribe to the event in another class ****************
public class User
{
    public void OnDownloadCompleted(string fileName)
    {
        Console.WriteLine($"Notification for user : {fileName} has been downloaded.");
    }
}


class Program
{
    static void Main()
    {
        FileDownloader downloader = new FileDownloader();
        User user = new User();

        //*************** Subscribe to the event ***********
        downloader.DownloadCompleted += user.OnDownloadCompleted; //attach method to the event

        //********* Start download *********
        downloader.DownloadFile("abc.pdf");
    }

}