
using EncryptionSoftware.Application.UtilImplementation;
using EncryptionSoftware.Helpers;

namespace ProbandoEncriptado
{
    public class Program
    {
        private static Util _util;

        public Program(Util util)
        {
            _util = util;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"{_util.Encrypt("afy", 5)}");
            Console.WriteLine($"{_util.Decrypt("fkd", 5)}");
            Console.ReadKey();
        }
    }
}