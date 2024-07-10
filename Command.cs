using MediaToolkit.Model;
using MediaToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace Module18
{
    public abstract class Command
    {
        public abstract void Run(string URL);

        public abstract void Cancel();
    }

    class GetVideoInfo:Command
    {
        Reciever reciever;

        public GetVideoInfo(Reciever reciever)
        {
            this.reciever = reciever;
        }

        public override async void Run(string URL)
        {
            Console.WriteLine("Выполняется комманда 1");

            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(URL);
            Console.WriteLine(vid.Title);

            /*
            File.WriteAllBytes(source + vid.FullName, vid.GetBytes());

            var inputFile = new MediaFile { Filename = source + vid.FullName };
            var outputFile = new MediaFile { Filename = $"{source + vid.FullName}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }

            */


            reciever.Operation();
        }

        public override void Cancel() { }

    }

    class DownloadVideo : Command
    {
        Reciever reciever;

        public DownloadVideo(Reciever reciever)
        {
            this.reciever = reciever;
        }

        public override void Run(string URL)
        {
            Console.WriteLine("Выполняется комманда 2");

            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(URL);
            File.WriteAllBytes("D://" + vid.FullName, vid.GetBytes());

            reciever.Operation();
        }

        public override void Cancel() { }

    }


    public class Sender
    {
        Command _commandOne;
        Command _commandTwo;
        public string url;
        
        public void SetCommand(Command commandOne, Command commandTwo)
        {
    
            this._commandOne = commandOne;
            this._commandTwo = commandTwo;
        }

        public Sender(string url)
        {
            this.url = url;
        }

        public void Run()
        {
            _commandOne.Run(url);
            _commandTwo.Run(url);
        }

        public void Cancel()
        {
            _commandOne.Cancel();    
            _commandTwo.Cancel();
        }
    
    
    }



    public class Reciever
    {
        public void Operation()
        {
            {

            }
        }

    }
}
