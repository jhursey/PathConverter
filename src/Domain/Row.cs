
namespace PathConverter.Domain
{
  public class Row
  {
    private char[] _characters;
    private int _currentIndex;

    public Row(int capacity)
    {
      _characters = new char[capacity];
      _currentIndex = 0;
    }

    public Row(int capacity, int currentIndex) : this(capacity)
    {
      _currentIndex = currentIndex;
    }

    public int GetCurrentIndex() => _currentIndex;
    public char GetCharacterAtCurrentIndex() => _characters[_currentIndex];
    public char GetCharacterAtIndex(int index) => _characters[index];
    public void SetCurrentIndex(int index) => _currentIndex = index;
    public void SetCharacters(char[] characters) => _characters = characters;
    public void SetCharacterAtIndex(char @char, int index) => _characters[index] = @char;

  }
}
