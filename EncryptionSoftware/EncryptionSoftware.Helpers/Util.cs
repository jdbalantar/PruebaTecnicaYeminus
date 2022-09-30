using System.Net;
using System.Text.RegularExpressions;

namespace EncryptionSoftware.Helpers
{
    public static class Util
    {
        public static string Encrypt(string phrase, int clave)
        {
            var alphabet = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z'
            };

            var encryptedPhrase = "";

            var index = 0;
            foreach (var letter in phrase)
            {
                index = letter switch
                {
                    >= 'A' and <= 'Z' => alphabet.IndexOf(char.ToLower(letter)),
                    >= 'a' and <= 'z' => alphabet.IndexOf((letter)),
                    _ => index
                };

                switch (letter)
                {
                    case >= 'A' and <= 'U':
                        encryptedPhrase += char.ToUpper(alphabet[index + clave]);
                        break;
                    case >= 'V' and <= 'Z':
                        encryptedPhrase += char.ToUpper(alphabet[Math.Abs(alphabet.Count - index - clave)]);
                        break;
                    case >= 'a' and <= 'u':
                        encryptedPhrase += alphabet[index + clave];
                        break;
                    case >= 'v' and <= 'z':
                        encryptedPhrase += alphabet[Math.Abs(alphabet.Count - index - clave)];
                        break;
                }
            }

            return encryptedPhrase;
        }

        public static string Decrypt(string phrase, int clave)
        {
            var alphabet = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z'
            };

            var decryptedPhrase = "";

            var index = 0;
            foreach (var letter in phrase)
            {
                index = letter switch
                {
                    >= 'A' and <= 'Z' => alphabet.IndexOf(char.ToLower(letter)),
                    >= 'a' and <= 'z' => alphabet.IndexOf((letter)),
                    _ => index
                };

                switch (letter)
                {
                    case >= 'a' and <= 'e':
                        decryptedPhrase += alphabet[Math.Abs(clave - alphabet.Count - index)];
                        break;
                    case >= 'f' and <= 'z':
                        decryptedPhrase += alphabet[Math.Abs(index - clave)];
                        break;
                    case >= 'A' and <= 'E':
                        decryptedPhrase += char.ToUpper(alphabet[Math.Abs(clave - alphabet.Count - index)]);
                        break;
                    case >= 'F' and <= 'Z':
                        decryptedPhrase += char.ToUpper(alphabet[Math.Abs(index - clave)]);
                        break;
                }
            }

            return decryptedPhrase;
        }

        private const string ValidationOne =
            @"^(ht|f|sf)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        private const string ValidationTwo =
            @"^(www.)[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

        private static bool ValidImgFormat(string img)
        {
            if (Regex.IsMatch(img, ValidationOne))
                return true;
            else if
                (Regex.IsMatch(img, ValidationTwo)) return true;
            else
                return false;
        }

        private static bool DoesImageExistRemotely(string uriToImage)
        {
            var request = (HttpWebRequest)WebRequest.Create(uriToImage);

            request.Method = "HEAD";

            try
            {
                using var response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (WebException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool ImgUrlIsValid(string img)
        {
            bool imgIsValid = ValidImgFormat(img);
            return imgIsValid && DoesImageExistRemotely(img);
        }
    }
}