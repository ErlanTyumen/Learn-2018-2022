using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа_4_семестр
{
    class question
    {

        public string text;

        public int complexity;

        public int w = 1;

        public int count;

        public question(string _text, int _compl, int _w)
        {
            text = _text;
            complexity = _compl;
            w = _w;
        }
        public question(string _text, int _compl, int _w, int _count)
        {
            text = _text;
            complexity = _compl;
            w = _w;
            count = _count;
        }
    }
}
