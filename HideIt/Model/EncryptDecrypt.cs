using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HideIt.Repository;

namespace HideIt.Model
{
    public abstract class EncryptDecrypt : IEncryptDecrypt
    {
        public String Name;
        public String About;

        public abstract String EncryptAlgorithm(String message);
        public abstract String DecryptAlgorithm(String message);
    }
}
