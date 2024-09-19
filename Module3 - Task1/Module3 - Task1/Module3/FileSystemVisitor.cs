using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3
{
    public class FileSystemVisitor
    {
        private readonly string _startingPath;
        private readonly Func<string, bool> _filter;

        public FileSystemVisitor(string startingPath) : this(startingPath, null)
        {
        }

        public FileSystemVisitor(string startingPath, Func<string, bool> filter)
        {
            _startingPath = startingPath;
            _filter = filter;
        }

        public IEnumerable<string> GetFiles()
        {
            if (!Directory.Exists(_startingPath))
            {
                Console.WriteLine("Directory doesn´t exist");
                yield break;
            }

            foreach (var item in Traverse(_startingPath))
            {
                yield return item;
            }
        }

        private IEnumerable<string> Traverse(string path)
        {
            foreach (var directory in Directory.GetDirectories(path))
            {
                if (_filter == null || _filter(directory))
                {
                    yield return directory; 
                }

                foreach (var file in Traverse(directory)) // 
                {
                    yield return file;
                }
            }

            foreach (var file in Directory.GetFiles(path))
            {
                if (_filter == null || _filter(file))
                {
                    yield return file; 
                }
            }
        }
    }
}
