namespace Grammar.Models
{
  public class Guess
  {
    public string Text { get; set; }
    public Guess(string text)
    {
      Text = text;
    }
  }
}