using System;
using Grammar.Models;
using Grammar.Services;
namespace Grammar.Controllers
{
  class GrammarController
  {
    private GrammarService _service { get; set; } = new GrammarService();
    private bool _running { get; set; } = true;
    public void Run()
    {
      Console.Clear();
      Console.WriteLine(
@"Welcome to GrammarGuess. Your objective is to guess all possible sentences for a
fictional language. You may view all the words in the language as well as the part of
speech and the meaning of any word at any time. However, be aware that not all
languages use the same word order as English. You may find similarities in word order 
between this language and English and you may not. It is up to you as a linguistic 
sleuth to figure out the word order patterns and after doing so enter all possible 
sentences in the language into your sentence-bank. The computer can only tell you if a 
sentence you create is possible or not in this language. If you enter a legal sentence, 
it will be stored in your sentence-bank and the computer will show you the meaning of 
the sentence. The computer will keep track of the ratio of incorrect to correct guesses. 
If you have more correct guesses than incorrect guesses at the end, you win. Otherwise, 
you lose.

"
      );
      while (_running)
      {
        if (_service.Sentences.Count - _service.Guesses.Count == 0)
        {
          _running = false;
          End();
        }
        else
        {
          GetUserInput();
        }
      }
    }

    private void GetUserInput()
    {
      Console.WriteLine(
      @"Menu:
        1) see a list of all words in the language
        2) enter a sentence into your sentence-bank"
      );
      string choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          ShowWords();
          break;
        case "2":
          Guess();
          break;
        default:
          Console.WriteLine("Choice not found. Please choose again.");
          break;
      }
    }

    private void ShowWords()
    {
      Console.Clear();
      Console.WriteLine(_service.All());
      Console.WriteLine("Enter any word to get part of speech and meaning of that word or enter 'm' to return to the main menu: ");
      string choice = Console.ReadLine().ToLower();
      if (choice == "m")
      {
        Console.Clear();
        GetUserInput();
      }
      else
      {
        int index = _service.FindIndexByWord(choice);
        if (index == -1)
        {
          Console.WriteLine("You must enter a valid word.\n");
          ShowWords2();
        }
        else
        {
          Console.WriteLine($"word: {_service.GetInfo(choice)[0].Spelling}, part of speech: {_service.GetInfo(choice)[0].PartOfSpeech}, meaning: {_service.GetInfo(choice)[0].Meaning}\n");
          ShowWords2();
        }
      }
    }

    private void ShowWords2()
    {
      Console.WriteLine(_service.All());
      Console.WriteLine("Enter any word to get part of speech and meaning of that word or enter 'm' to return to the main menu: ");
      string choice = Console.ReadLine().ToLower();
      if (choice == "m")
      {
        Console.Clear();
        GetUserInput();
      }
      else
      {
        int index = _service.FindIndexByWord(choice);
        if (index == -1)
        {
          Console.WriteLine("You must enter a valid word.\n");
          ShowWords2();
        }
        else
        {
          Console.WriteLine($"word: {_service.GetInfo(choice)[0].Spelling}, part of speech: {_service.GetInfo(choice)[0].PartOfSpeech}, meaning: {_service.GetInfo(choice)[0].Meaning}\n");
          ShowWords2();
        }
      }
    }

    private void Guess()
    {
      Console.Write("Enter a sentence that you think is a possible sentence in this language: ");
      string guess = Console.ReadLine().ToLower();
      Guess newGuess = new Guess(guess);
      Console.WriteLine(_service.Check(newGuess));
    }

    private void End()
    {
      Console.WriteLine(_service.Final());
    }
  }
}