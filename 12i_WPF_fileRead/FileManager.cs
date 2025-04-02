using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace _12i_WPF_fileRead
{
    public class FileManager
    {
        private string fileName;

        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }

        public List<string> ReadFile() {
            List<string> all = new List<string>();

            try
            {
                all = File.ReadAllLines(fileName, Encoding.UTF8).Skip(1).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return all;
        }

    }
}
