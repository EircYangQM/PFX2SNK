using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PFX2SNK {
  class Program {
    static void Main(string[] args) {
      if (args.Length != 3) {
        Console.WriteLine("Please input PFX2SNK.exe <pfx_file> <pfx_password> <output_snk_file_path>");
        return;
      }
      X509Certificate2 cert = new X509Certificate2(args[0], args[1], X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
      RSACryptoServiceProvider provider = (RSACryptoServiceProvider)cert.PrivateKey;
      byte[] array = provider.ExportCspBlob(!provider.PublicOnly);
      using (FileStream fs = new FileStream(args[2], FileMode.Create, FileAccess.Write)) {
        fs.Write(array, 0, array.Length);
      }
    }
  }
}
