using System;

namespace DBTest.Models
{
    
    public class KeySet
    {
        public class KeyFile
        {
            public String FilePath { get; set; }
            public String MimeType { get; set; }
            public int Size { get; set; }
            public DateTime CreatedOn { get; set; }
        }

        public int KeySetId { get; set; }
        public KeyFile PublicKeyFile { get; set; }
        public KeyFile PrivateKeyFile { get; set; }
    }
}