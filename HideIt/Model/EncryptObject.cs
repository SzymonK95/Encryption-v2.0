using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HideIt.Model
{
    public class EncryptObject
    {
        static Int32 ID_EO = 0;
        Int32 ID;
        String message;
        Image image;
        EncryptType encryptType;
        public String Result;

        public EncryptObject(String message, Image image)
        {
            ID = ID_EO;
            ID_EO++;

            this.message = message;
            this.image = image;

            encryptType = new Caesar(5);
            Result = encryptType.EncryptAlgorithm(this.message);
        }
    }
}
