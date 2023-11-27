using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        ScriptureReference scriptureRef = new ScriptureReference("1 Nephi", 3, 7, 8);
        Scripture scripture = new Scripture(scriptureRef, "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them; And it came to pass that when my father had heard these words he was exceedingly glad, for he knew that I had been blessed of the Lord.");

        Console.WriteLine($"Scripture: {scripture.Reference.Book} {scripture.Reference.VerseReference.Chapter}:{scripture.Reference.VerseReference.StartVerse}-{scripture.Reference.VerseReference.EndVerse}");
        Console.WriteLine(scripture.GetText());

        Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
        var words = scripture.GetText().Split(' ').ToList();
        var random = new Random();

        var indicesToHide = Enumerable.Range(0, words.Count).Where(i => !string.IsNullOrWhiteSpace(words[i])).ToList();
        indicesToHide = indicesToHide.OrderBy(x => random.Next()).ToList();

        while (indicesToHide.Count > 0)
        {
            var userInput = Console.ReadLine()?.ToLower();
            if (userInput == "quit")
                break;

            int countToHide = Math.Min(3, indicesToHide.Count);
            var chosenIndices = indicesToHide.Take(countToHide);

            foreach (var index in chosenIndices)
            {
                words[index] = new string('_', words[index].Length);
            }

            indicesToHide.RemoveAll(chosenIndices.Contains);

            Console.Clear();
            Console.WriteLine($"Scripture: {scripture.Reference.Book} {scripture.Reference.VerseReference.Chapter}:{scripture.Reference.VerseReference.StartVerse}-{scripture.Reference.VerseReference.EndVerse}");
            Console.WriteLine(string.Join(" ", words));
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
        }

        Console.WriteLine("All words are hidden.");
    }
}
class Verse
{
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Verse(int chapter, int startVerse, int endVerse)
    {
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
}

class ScriptureReference
{
    public string Book { get; }
    public Verse VerseReference { get; }

    public ScriptureReference(string book, Verse verseReference)
    {
        Book = book;
        VerseReference = verseReference;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        : this(book, new Verse(chapter, startVerse, endVerse)) { }
}

class Scripture
{
    private readonly string _text;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        _text = text;
    }

    public ScriptureReference Reference { get; }

    public string GetText() => _text;
}


