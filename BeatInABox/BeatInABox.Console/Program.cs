using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatInABox.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Clip> allClips = new List<Clip>();
            var files = GetFiles(searchPattern);

            System.Console.WriteLine("Loaded " + files.Length + " files from disk.");

            foreach (var f in files)
            {
                List<Clip> clips = ClipSlicer.Slice(file, rules);
                allClips.AddRange(clips);
            }

            System.Console.WriteLine("Created " + allClips.Length + " clips.");

            Sequence sequence = Sequence.Create(sequenceOptions);

            var wave = sequence.Render(allClips, renderOptions);
            SaveToDisk(wave, filename);

            System.Console.WriteLine("Sequence saved to disk.");
            System.Console.WriteLine("Press any key to continue...");
            System.Console.Read();
        }
    }
}
