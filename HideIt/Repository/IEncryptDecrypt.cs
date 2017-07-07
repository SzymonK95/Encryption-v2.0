using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideIt.Repository
{
    public interface IEncryptDecrypt
    {
        String EncryptAlgorithm(String message);
        String DecryptAlgorithm(String message);
    }
}
