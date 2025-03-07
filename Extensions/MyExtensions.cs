using QuDevChallenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuDevChallenge.Extensions
{
    public static class MyExtensions
    {
        public static bool Same(this WordsAndOcurrencies me, WordsAndOcurrencies other)
        {
            if (me.Word.Equals(other.Word))
                return true;

            return false;
        }
    }
}
