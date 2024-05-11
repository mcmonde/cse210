using System;
using System.Text.RegularExpressions;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetBook() { return CleanString(_book); }
    public int GetChapter() { return _chapter; }
    public int GetStartVerse() { return _verse; }
    public int GetEndVerse() { return _endVerse != 0 ? _endVerse : 0; }
    
    public string GetDisplayText()
    {
        if (_endVerse != 0 )
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        else
            return $"{_book} {_chapter}:{_verse}";
    }
    
    static string CleanString(string input)
    {
        string cleaned = Regex.Replace(input, "[^a-zA-Z0-9]", "");

        // Convert to lowercase
        string lowercase = cleaned.ToLower();

        return lowercase;
    }
}