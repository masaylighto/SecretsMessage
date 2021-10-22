using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace SecretMessging
{
    public class Program
    {
        static void CreateFile(string Name, string path)
        {
            //assembly will get the data of Embedded Resource in This Project
            Assembly assembly = Assembly.GetExecutingAssembly();
            //stream will read data which givin by assembly.GetManifestResourceStream(FileName) Which represent the file That need to be extract the file writed by Write the name of Project then dot Then the names of directories that contained the file one by one evey one with dot at it end then the file name with out dotat the end
            Stream stream = assembly.GetManifestResourceStream(Name);
            //will read the Binary  from stream 
            BinaryReader binaryreader = new BinaryReader(stream);
            //define the path to store the file
            FileStream fs = new FileStream(path, FileMode.Create);
            //Write the Binary to the path specified by FileStream
            BinaryWriter bw = new BinaryWriter(fs);
            //writing the data that giving by binaryreader.ReadBytes to the Path specified by FileSystem 
            //(int)stream.Length represent the lenght of data that will be writin and it mean write  all the steam has from data
            bw.Write(binaryreader.ReadBytes((int)stream.Length));
            bw.Close();
            binaryreader.Close();
            fs.Close();
            stream.Close();

        }
        public static void Main(string[] args)
        {

            if (!File.Exists("Msg.db"))
            {
                try
                {
                    Program.CreateFile("SecretMessging.Msg.db", "/Msg.db");
                }
                catch
                {


                }
            }


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
