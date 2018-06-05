using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializableFile
{
    [Serializable]
    public class SerializableFile
    {
        private String filename;
        private byte[] file;

        public SerializableFile(String filename, byte[] file)
        {
            this.filename = filename;
            this.File = file;
        }

        public byte[] File { get => file; set => file = value; }
        public string Filename { get => filename; set => filename = value; }
    }
}
