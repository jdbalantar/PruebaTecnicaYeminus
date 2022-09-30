// See https://aka.ms/new-console-template for more information

using EncryptionSoftware.Helpers;

Console.WriteLine($"{Util.Encrypt("aFy", 5)}");
Console.WriteLine($"{Util.Decrypt("fkd", 5)}");
Console.ReadKey();