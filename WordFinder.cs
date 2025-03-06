using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDevChallenge
{
    public class WordFinder
    {
        //  Each string represents a row in the matrix
        private IEnumerable<string> _matrix;
        // Represents the original matrix rotated as each row in this matrix is a column in the original matrix
        private IEnumerable<string> _matrixRotated;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
            List<string> rotated = new List<string>();

            //Build Rotated Matrix
            StringBuilder column;
            for (int i = 0; i < _matrix.FirstOrDefault().Length; i++)
            {
                column = new StringBuilder();
                foreach (string row in _matrix)
                {
                    column.Append(row[i]);
                }

                //If column is not empty, add it to the rotatedMatrix
                if (!string.IsNullOrEmpty(column.ToString()))
                    rotated.Add(column.ToString());
            }
            _matrixRotated = rotated;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            List<string> result = new List<string>();

            //Finds all words on the Matrix
            List<WordsAndOcurrencies> found = FindAll(wordstream);

            if (found.Count < 11)
            {
                foreach (var word in found)
                {
                    result.Add(word.Word);
                }
            }
            else // Return 10 words with more occurrencies
            {
                found.Sort();
                found.Reverse();

                var toReturn = found.GetRange(0, 10);

                foreach (var word in toReturn)
                {
                    result.Add(word.Word);
                }
            }

            return result;
        }

        private List<WordsAndOcurrencies> FindAll(IEnumerable<string> wordstream)
        {
            List<WordsAndOcurrencies> found = new List<WordsAndOcurrencies>();
            int ocurrencies = 0;
            WordsAndOcurrencies wordAndOcurrencies;
            
            foreach (string word in wordstream)
            {
                ocurrencies = 0;
                ocurrencies = FindHorizontally(word) + FindVertically(word);

                if (ocurrencies > 0)
                {
                    wordAndOcurrencies = new WordsAndOcurrencies(word, ocurrencies);

                    found.Add(wordAndOcurrencies);
                }
            }

            return found;
        }

        private int FindHorizontally(string word)
        {
            int occurrences = 0;

            foreach (string row in _matrix)
            {
                if (row.ToLower().Contains(word.ToLower()))
                    occurrences++;
            }

            return occurrences;
        }

        private int FindVertically(string word)
        {
            int occurrences = 0;

            foreach (string row in _matrixRotated)
            {
                if (row.ToLower().Contains(word.ToLower()))
                    occurrences++;
            }

            return occurrences;
        }
    }

    class WordsAndOcurrencies : IComparable<WordsAndOcurrencies> 
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
