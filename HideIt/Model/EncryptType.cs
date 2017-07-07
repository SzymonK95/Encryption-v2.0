using HideIt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideIt.Model
{
    public abstract class EncryptType : IEncryptDectyptAlgorithm<String, String>
    {
        public String Name { get; set; }
        public String About { get; set; }

        abstract public String EncryptAlgorithm(String message);

        abstract public String DecryptAlgorithm(String message);
    }
    
}
