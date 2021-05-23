namespace Grammar.Models
{
  public class Word
  {
    public string Spelling { get; set; }
    public string PartOfSpeech { get; set; }
    public string Meaning { get; set; }
    public Word(string spelling, string pos, string meaning)
    {
      Spelling = spelling;
      PartOfSpeech = pos;
      Meaning = meaning;
    }
  }
}