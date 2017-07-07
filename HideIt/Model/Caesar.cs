using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HideIt.Repository;
using System.Windows.Controls;

namespace HideIt.Model
{
    public class Caesar : EncryptType
    {
        private Int32 Key;

        public Caesar(Int32 Key)
        {
            this.Key = Key;
        }

        public override String EncryptAlgorithm(String message)
        {
            String enctyptMessage = null;

            foreach (char c in message)
            {
                //licznik sie przekraci
                var elem = (int)c + Key;

                enctyptMessage += (char)elem;
            }     

            return enctyptMessage; 
        }

        public override String DecryptAlgorithm(String message)
        {
            String decryptMessage = null;

            return decryptMessage;
        }
    }
}
