using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeDesc.KeyWordHighlighting
{
    enum typeOfKeyword
    {
        normal,
        nxtWordyellow,
        nxtWordgreen,
        allgreen,
        green
    }
    class KeyWord
    {
        private string name;
        private string color;
        private typeOfKeyword type;

        public KeyWord(string n, string c, string t)
        {

            name = n;
            color = c;
            switch (t)
            {
                case "1":
                    type = typeOfKeyword.normal;
                    break;
                case "2":
                    type = typeOfKeyword.nxtWordyellow;
                    break;
                case "3":
                    type = typeOfKeyword.nxtWordgreen;
                    break;
                case "4":
                    type = typeOfKeyword.allgreen;
                    break;
                case "5":
                    type = typeOfKeyword.green;
                    break;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
        }
        public typeOfKeyword Type
        {
            get
            {
                return type;
            }
        }
    }
}
