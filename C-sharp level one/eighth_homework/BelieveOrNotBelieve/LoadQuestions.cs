using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;


namespace BelieveOrNotBelieve
{
    [Serializable]
    public class Question
    {
        private string text;
        private bool trueFalse;
        public string Text { get { return text; } set { text = value; } }
        public bool TrueFalse { get { return trueFalse; } set { trueFalse = value; } }
        public Question()
        {
        }
        public Question(string _text, bool _trueFalse)
        {
            this.text = _text;
            this.trueFalse = _trueFalse;
        }
    }
    public class LoadQuestions
    {
        string fileName;
        public List<Question> list;
        public string FileName
        {
            set { fileName = value; }
        }
        public LoadQuestions(string _fileName)
        {
            this.fileName = _fileName;
            list = new List<Question>();
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        public Question this[int _index]
        {
            get { return list[_index]; }
        }
        public int Count
        {
            get { return list.Count; }
        }
    }
}
