namespace Module18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите url видео с ютуба");

            string url = Console.ReadLine();

            var sender = new Sender(url);
            var reciever = new Reciever();

            var CommandOne = new GetVideoInfo(reciever);
            var CommandTwo = new DownloadVideo(reciever);
            
            sender.SetCommand(CommandOne, CommandTwo);

            sender.Run();
        }
    }
}
