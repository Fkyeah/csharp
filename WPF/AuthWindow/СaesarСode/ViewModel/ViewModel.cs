using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using СaesarСode.Model;

namespace СaesarСode.ViewModel
{
    class ViewModel
    {
        public CaesarModel caesarModel { get; set; } = new CaesarModel("none", 1);
        
        public ICommand ClickEncrypt
        {
            get
            {
                return new DelegateCommand(Encrypt, canEncrypt);
            }
        }
        public void Encrypt(object obj)
        {
            caesarModel.EcryptMessage = caesarModel.Encrypt(caesarModel.Message, caesarModel.Index);
        }

        public bool canEncrypt(object obj)
        {
            return true;
        }

        public ICommand ClickDecode
        {
            get
            {
                return new DelegateCommand(Decode, canDecode);
            }
        }
        public void Decode(object obj)
        {
            caesarModel.DecryptMessage = caesarModel.Decrypt(caesarModel.EcryptMessage, caesarModel.Index);
        }

        public bool canDecode(object obj)
        {
            return true;
        }
    }
}
