using System.Text;

namespace PathConverter.Domain
{
  public class Remote
  {
    private const int AllLettersAndTenDigits = 36;

    private readonly int _numberOfRows;
    private readonly int _numberOfColumns;
    private readonly Grid _searchGrid;
    private readonly StringBuilder _searchTerm;
    private readonly SearchPointer _pointer;
    private readonly InputEncoding _inputEncoding;

    public Remote()
    {
      _numberOfRows = _numberOfColumns = AllLettersAndTenDigits / 6;
      _searchGrid = new Grid(_numberOfRows, _numberOfColumns);
      _searchTerm = new StringBuilder();
      _pointer = new SearchPointer();
      _inputEncoding = new InputEncoding();
    }

    public void MovePointerUp()
    {
      _pointer.RowIndex--;
      if (_pointer.RowIndex == -1) 
        _pointer.RowIndex = _numberOfRows - 1;
    } 
    public void MovePointerDown()
    {
      _pointer.RowIndex++;
      if (_pointer.RowIndex == _numberOfRows) 
        _pointer.RowIndex = 0;
    }
    public void MovePointerLeft()
    {
      _pointer.ColIndex--;
      if (_pointer.ColIndex == -1) 
        _pointer.ColIndex = _numberOfColumns - 1;
    }
    public void MovePointerRight()
    {
      _pointer.ColIndex++;
      if (_pointer.ColIndex == _numberOfColumns)
        _pointer.ColIndex = 0;
    }

    public char GetCurrentCharacter() => 
      _searchGrid
        .GetRowAtIndex(_pointer.RowIndex)
        .GetCharacterAtIndex(_pointer.ColIndex);

    public string GetCurrentSearchTerm() =>
      _searchTerm.ToString();

    public void AddCharacterToSearch() =>
      _searchTerm.Append(GetCurrentCharacter());

    public void AddSpaceToSearch() =>
      _searchTerm.Append(' ');

    public string InterpretInput(string keyPath)
    {
      foreach (var c in keyPath)
      {
        if (c == _inputEncoding.SelectItem)
          AddCharacterToSearch();
        else if (c == _inputEncoding.AddSpace)
          AddSpaceToSearch();
        else if (c == _inputEncoding.MoveUp)
          MovePointerUp();
        else if (c == _inputEncoding.MoveDown)
          MovePointerDown();
        else if (c == _inputEncoding.MoveLeft)
          MovePointerLeft();
        else if (c == _inputEncoding.MoveRight) 
          MovePointerRight();
      }

      return GetCurrentSearchTerm();
    }

    public class SearchPointer
    {
      public SearchPointer()
      {
        RowIndex = 0;
        ColIndex = 0;
      }

      public int RowIndex { get; set; }
      public int ColIndex { get; set; }
    }

    public class InputEncoding
    {
      public InputEncoding()
      {
        MoveUp = 'U';
        MoveDown = 'D';
        MoveLeft = 'L';
        MoveRight = 'R';
        AddSpace = 'S';
        SelectItem = '*';
      }

      public char MoveUp { get; set; }
      public char MoveDown { get; set; }
      public char MoveLeft { get; set; }
      public char MoveRight { get; set; }
      public char AddSpace { get; set; }
      public char SelectItem { get; set; }
    }
  }
}
