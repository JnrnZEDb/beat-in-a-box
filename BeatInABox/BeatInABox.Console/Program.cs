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

            foreach (var f in files)
            {
                List<Clip> clips = ClipSlicer.Slice(file, rules);
                allClips.AddRange(clips);
            }

            Sequence sequence = Sequence.Create(sequenceOptions);

            var wave = sequence.Render(allClips, renderOptions);
            SaveToDisk(wave, filename);

            System.Console.WriteLine("Sequence saved to disk.");
            System.Console.WriteLine("Press any key to continue...");
            System.Console.Read();
        }
    }
}
