using System;
using System.Collections.Generic;
using System.Text;

namespace TranslatorConsole
{
    public class TranslUnit
    {
        public string Source { get; private set; }
        public string Target { get; private set; }

        public TranslUnit(string source, string target)
        {
            Source = source;
            Target = target;
        }
    }
}
