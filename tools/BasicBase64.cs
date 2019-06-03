using System;
using System.Text;

public class Program {
   public static void Main(string[] args) {
      // Demonstrar criacao de string base64
      //
      var name = "Vladimir";
      byte[] myName = Encoding.UTF8.GetBytes(name);
      var encoded = Convert.ToBase64String(myName);
      Console.WriteLine("Texto original: {0}\nTexto encodado: {1}", name, encoded);
   }
}
