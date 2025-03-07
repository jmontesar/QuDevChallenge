using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDevChallenge.Model
{
    public class WordsAndOcurrencies : IComparable<WordsAndOcurrencies>
    {
        public string Word { get; set; }
        public int Occurrences { get; set; }

        public WordsAndOcurrencies(string word, int ocurrencies)
        {
            Word = word; Occurrences = ocurrencies;
        }

        public int CompareTo(WordsAndOcurrencies? other)
        {
            if (Occurrences < other.Occurrences)
                return -1;
            if (Occurrences > other.Occurrences)
                return 1;

            return 0;
        }
    }
}
