using System;
using System.Collections.Generic;

namespace TestIndikatore.Model
{
    public class Folder
    {
        public string name { get; set; }
        public int size { get; set; }
        public List<Folder> folders { get; set; }

        public Folder()
        {
            this.folders = new List<Folder>();
        }

        public Folder(string name)
        {
            this.name = name;
            this.folders = new List<Folder>();
        }

        public Folder(string name, List<Folder> folders)
        {
            this.name = name;
            this.folders = folders;
        }
    }
}
    

