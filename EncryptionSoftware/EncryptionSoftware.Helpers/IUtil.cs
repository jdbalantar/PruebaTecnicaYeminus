using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSoftware.Helpers
{
    public interface IUtil
    {
        string Decrypt(string phrase, int clave);
        string Encrypt(string phrase, int clave);
        bool ValidImgFormat(string img);
        bool DoesImageExistRemotely(string uriToImage);
        bool ImgUrlIsValid(string img);
    }
}