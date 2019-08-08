using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_And_Event
{
    // The two methods which one count the quantity of letters in the text, and second one
    // count just symbol 'A' of the text
    public class StringHelper
    {
        // Method 1. Count quentity letters of the text
        public int GetCount(string text)
        {
            return text.Length;
        }

        // Method 2. Only count quentity 'A' of the text
        public int CountSymbolOfText(string text)
        {
            return text.Count(a => a == 'A');
        }
    }
}
