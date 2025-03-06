using QuDevChallenge;

//TestWords();
TestMoreThan10();



void TestWords()
{
    List<string> matrix = new List<string>();
    List<string> words = new List<string>();

    matrix.Add("abcdc");
    matrix.Add("fgwio");
    matrix.Add("chill");
    matrix.Add("pqnsd");
    matrix.Add("uvdxy");

    words.Add("cold");
    words.Add("wind");
    words.Add("snow");
    words.Add("chill");

    WordFinder finder = new WordFinder(matrix);

    IEnumerable<string> found = finder.Find(words);

    foreach (string word in found)
    {
        Console.WriteLine(word);
    }

}

void TestMoreThan10()
{
    List<string> matrix = new List<string>();
    List<string> words = new List<string>();

    matrix.Add("abcdcwindc");
    matrix.Add("fgwioi234h");
    matrix.Add("chilln234i");
    matrix.Add("pqnsdd234l");
    matrix.Add("uvdxy1234l");

    matrix.Add("abcdchindc");
    matrix.Add("fgwioa23wh");
    matrix.Add("chilln23ii");
    matrix.Add("Armsdd23nl");
    matrix.Add("windy123dl");

    words.Add("cold");
    words.Add("wind");
    words.Add("snow");
    words.Add("chill");

    words.Add("chair");
    words.Add("arm");
    words.Add("hand");
    words.Add("chill");
    words.Add("chill");
    words.Add("chill");
    words.Add("chill");
    words.Add("chill");
    words.Add("chill");

    WordFinder finder = new WordFinder(matrix);

    IEnumerable<string> found = finder.Find(words);

    foreach (string word in found)
    {
        Console.WriteLine(word);
    }
}