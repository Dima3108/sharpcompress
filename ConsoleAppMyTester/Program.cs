namespace ConsoleAppMyTester;

using System.Text;
using SharpCompress;
using SharpCompress.Factories;
using SharpCompress.Writers.Zip;
internal class Program
{
#pragma warning disable CS0219
    static void Main(string[] args)
    {
        string content = "Hellow world!\n" +
            "11111111111111111111111111111111111111111111111111111111111111111111111" +
            "rbgfuiohjdauieogfyao111111111111111111111111111111111111111111119999999" +
            "667&&&&acvghlkfrutugf6631aDioy11111111111111111111111111111111111111111";
        var factory = new ZipFactory();
        using(Stream s = File.OpenWrite("content.zip"))
        {
            var arc = factory.Open(s, new SharpCompress.Writers.Zip.ZipWriterOptions(SharpCompress.Common.CompressionType.PPMd));
            arc.Write("content.txt", new MemoryStream(UnicodeEncoding.UTF8.GetBytes(content)),DateTime.Now);
            arc.Dispose();
        }
        
    }
}
