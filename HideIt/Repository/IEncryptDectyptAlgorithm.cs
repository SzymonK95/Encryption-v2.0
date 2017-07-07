using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HideIt.Repository
{
    public interface IEncryptDectyptAlgorithm<EncryptAlgorithmReturnType, DecryptAlgorithmReturnType>
    {
        String Name { get; set; }
        String About { get; set; }

        EncryptAlgorithmReturnType EncryptAlgorithm(String message);
        DecryptAlgorithmReturnType DecryptAlgorithm(String message);
    }
}
