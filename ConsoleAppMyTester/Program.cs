namespace ConsoleAppMyTester;

using System.Text;
using SharpCompress;
using SharpCompress.Compressors.LZMA;
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
        var tarfactory=new TarFactory();
        /*using(Stream s = File.OpenWrite("content.tar.xz"))
        {
            using (var arc = tarfactory.Open(s, new SharpCompress.Writers.Tar.TarWriterOptions(SharpCompress.Common.CompressionType.Xz, true)))
            {
                arc.Write("content.txt", new MemoryStream(UnicodeEncoding.UTF8.GetBytes(content)), DateTime.Now);
                arc.Dispose();
            }
        }*/
        using(LzmaStream xz=new LzmaStream(new LzmaEncoderProperties(), false, File.OpenWrite("t.txt.lzma")))
        {
            xz.Write(UnicodeEncoding.UTF8.GetBytes(content));
            xz.Flush();
            xz.Close();
        }
        Console.ReadLine();
        const string filename = @"Q:/GITHub/LibreOffice.zip";
        /*using (Stream s = File.OpenRead(filename))
        {
            var arc = factory.OpenReader(s, new SharpCompress.Readers.ReaderOptions());
           
            while (arc.MoveToNextEntry())
            {
                Console.WriteLine(arc.Entry.Key);
            }
           
        }*/
    }
}
