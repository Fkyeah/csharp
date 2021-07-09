using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СaesarСode.Model
{
    public class CaesarModel : INotifyPropertyChanged
    {
        private string _message;
        private int _index;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Message
        {
            get => _message;
            set
            {
                if (value != _message)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Сообщение должно содержать хотя бы один символ");
                    }
                    _message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Message"));
                }
            }
        }
        private string _ecryptMessage;
        public string EcryptMessage
        {
            get => _ecryptMessage;
            set 
            {
                if (value != _ecryptMessage)
                {
                    _ecryptMessage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EcryptMessage"));
                }
            }
        }
        private string _decryptMessage;
        public string DecryptMessage
        {
            get => _decryptMessage;
            set
            {
                if (value != _decryptMessage)
                {
                    _decryptMessage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DecryptMessage"));
                }
            }
        }
        public int Index
        {
            get => _index;
            set
            {
                if (value != _index)
                {
                    _index = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Index"));
                }
            }
        }

        public CaesarModel()
        {

        }
        

        public CaesarModel(string message, int index)
        {
            Message = message;
            Index = index;
        }
        string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }
}
