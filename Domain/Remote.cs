using System.Text;

namespace PathConverter.Domain
{
  public class Remote
  {
    private const int DefaultGridLayout = 6;

    private readonly int _numberOfRows;
    private readonly int _numberOfColumns;
    private readonly Grid _searchGrid;
    private readonly StringBuilder _searchTerm;
    private readonly SearchPointer _pointer;
    private readonly InputEncoding _inputEncoding;

    public Remote()
    {
      _numberOfRows = _numberOfColumns = DefaultGridLayout;

      _searchGrid = new Grid(_numberOfRows, _numberOfColumns);
      _searchTerm = new StringBuilder();
      _pointer = new SearchPointer();
      _inputEncoding = new InputEncoding();
    }

    private void MovePointerUp()
    {
      _pointer.RowIndex--;
      if (_pointer.RowIndex == -1) 
        _pointer.RowIndex = _numberOfRows - 1;
    } 
    private void MovePointerDown()
    {
      _pointer.RowIndex++;
      if (_pointer.RowIndex == _numberOfRows) 
        _pointer.RowIndex = 0;
    }
    private void MovePointerLeft()
    {
      _pointer.ColIndex--;
      if (_pointer.ColIndex == -1) 
        _pointer.ColIndex = _numberOfColumns - 1;
    }
    private void MovePointerRight()
    {
      _pointer.ColIndex++;
      if (_pointer.ColIndex == _numberOfColumns)
        _pointer.ColIndex = 0;
    }

    private char GetCurrentCharacter() => 
      _searchGrid
        .GetRowAtIndex(_pointer.RowIndex)
        .GetCharacterAtIndex(_pointer.ColIndex);

    private string GetCurrentSearchTerm() =>
      _searchTerm.ToString();

    private void AddCharacterToSearch() =>
      _searchTerm.Append(GetCurrentCharacter());

    private void AddSpaceToSearch() =>
      _searchTerm.Append(' ');

    private void ClearSearchTerm() =>
      _searchTerm.Clear();

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

      var decodedKeyPath = GetCurrentSearchTerm();
      ClearSearchTerm();
      _pointer.ResetPointer();

      return decodedKeyPath;
    }

    internal class SearchPointer
    {
      internal SearchPointer()
      {
        ResetPointer();
      }

      internal int RowIndex { get; set; }
      internal int ColIndex { get; set; }

      internal void ResetPointer()
      {
        RowIndex = 0;
        ColIndex = 0;
      }
    }

    internal class InputEncoding
    {
      internal InputEncoding()
      {
        DefaultEncoding();
      }

      private void DefaultEncoding()
      {
        MoveUp = 'U';
        MoveDown = 'D';
        MoveLeft = 'L';
        MoveRight = 'R';
        AddSpace = 'S';
        SelectItem = '*';
      }

      internal char MoveUp { get; set; }
      internal char MoveDown { get; set; }
      internal char MoveLeft { get; set; }
      internal char MoveRight { get; set; }
      internal char AddSpace { get; set; }
      internal char SelectItem { get; set; }
    }
  }
}
