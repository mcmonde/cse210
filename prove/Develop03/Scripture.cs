using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> remainingIndices = new List<int>();

        // Add indices of words that are not hidden
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                remainingIndices.Add(i);
            }
        }

        // Shuffle the remaining indices
        Shuffle(remainingIndices);

        // Hide the specified number of words using shuffled indices
        for (int i = 0; i < Math.Min(numberToHide, remainingIndices.Count); i++)
        {
            _words[remainingIndices[i]].Hide();
        }
    }


// Helper method to shuffle a list of integers
    private void Shuffle(List<int> list)
    {
        Random random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}