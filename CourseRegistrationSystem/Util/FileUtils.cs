using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CourseRegistrationSystem
{
    public class FileUtils
    {
        /// <summary>
        /// Points to the file location '/your_project_root/bin/debug/conf'.
        /// </summary>
        public static string confDirPath = Directory.GetParent(Environment.CurrentDirectory).FullName + "\\conf\\";

        /// <summary>
        /// Reads a file in the directory specified in <see cref="confDirPath"/>.
        /// </summary>
        public static IEnumerable<string> FileReader(string filePath)
        {
            string line;
            using (var reader = File.OpenText(confDirPath + filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
