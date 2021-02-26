
namespace PathConverter.Domain
{
  public class Row
  {
    private char[] _characters;

    public Row(int capacity)
    {
      _characters = new char[capacity];
    }

    public char GetCharacterAtIndex(int index) => _characters[index];
    public void SetCharacterAtIndex(char @char, int index) => _characters[index] = @char;
    public void SetCharacters(char[] characters) => _characters = characters;

  }
}
