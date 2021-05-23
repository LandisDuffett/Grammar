namespace Grammar.Models
{
  public class Sentence
  {
    public string Text { get; set; }
    public Sentence(string text)
    {
      Text = text;
    }
  }
}