using System.Collections.Generic;
using Grammar.Models;
namespace Grammar.Services
{
  class GrammarService
  {
    private List<Word> Words { get; set; }
    internal List<Sentence> Sentences { get; set; }
    internal List<Guess> Guesses { get; set; }

    internal int _correct { get; set; } = 0;

    internal int _incorrect { get; set; } = 0;

    internal string All()
    {
      string list = "";
      for (int i = 0; i < Words.Count; i++)
      {
        var word = Words[i];
        {
          list += $"{word.Spelling}\n";
        }
      }
      return list;
    }

    internal string Check(Guess guess)
    {
      var sent = Sentences.FindIndex(s => s.Text == guess.Text);
      var there = Guesses.FindIndex(g => g.Text == guess.Text);
      if (sent != -1 && there == -1)
      {
        _correct++;
        Guesses.Add(guess);
        return $"That is a possible sentence. You now have {Sentences.Count - Guesses.Count} sentences left to figure out.\n";
      }
      else if (sent != -1 && there != -1)
      {
        return $"That sentence is already in your sentence-bank. You still have {Sentences.Count - Guesses.Count} sentences left to figure out.";
      }
      else
      {
        _incorrect++;
        return $"That is not a possible sentence in this language. You still have {Sentences.Count - Guesses.Count} sentences left to figure out.";
      }
    }

    internal List<Word> GetInfo(string word)
    {
      return Words.FindAll(w => w.Spelling == word);
    }

    internal int FindIndexByWord(string word)
    {
      return Words.FindIndex(w => w.Spelling.ToLower() == word);
    }

    internal string Final()
    {
      if (_correct > _incorrect)
      {
        return $"You have found all possible sentences in this language. The number of correct guesses was {_correct}; the number of incorrect guesses was {_incorrect}. You win!";
      }
      else
      {
        return $"You have found all possible sentences in this language. The number of correct guesses was {_correct}; the number of incorrect guesses was {_incorrect}. You lose!";
      }
    }

    public GrammarService()
    {
      Words = new List<Word>(){
      new Word("grob", "noun", "cat"),
      new Word("bork", "verb", "see"),
      new Word("zobby", "adjective", "old"),
      new Word("nang", "noun", "man"),
      new Word("flob", "verb", "eat")
      };

      Sentences = new List<Sentence>(){
      new Sentence("bork grob nang"),
      new Sentence("bork nang grob"),
      new Sentence("flob grob nang"),
      new Sentence("flob nang grob"),
      new Sentence("bork grob zobby nang"),
      new Sentence("bork grob nang zobby"),
      new Sentence("bork grob zobby nang zobby"),
      new Sentence("flob grob zobby nang"),
      new Sentence("flob grob nang zobby"),
      new Sentence("flob grob zobby nang zobby")
      };

      Guesses = new List<Guess>()
      {

      };
    }
  }
}

