using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathConverter.Domain
{
  public class Remote
  {
    private Grid _searchGrid;
    private StringBuilder _searchTerm;
    private SearchPointer _pointer;

    public Remote(int numberOfRows)
    {
      _searchGrid = new Grid(numberOfRows);
      _searchTerm = new StringBuilder();
      _pointer = new SearchPointer();
    }

    public Remote(Row[] rows, int numberOfRows) : this(numberOfRows)
    {
      _searchGrid.SetRows(rows);
    }

    public void MovePointerUp() => _pointer.ColIndex--;
    public void MovePointerDown() => _pointer.ColIndex++;
    public void MovePointerLeft() => _pointer.RowIndex--;
    public void MovePointerRight() => _pointer.RowIndex++;

    public char GetCurrentCharacter() => 
      _searchGrid.GetRowAtIndex(_pointer.RowIndex).GetCharacterAtIndex(_pointer.ColIndex);

    public void AddCharacterToSearch()
    {
      var currentChar = _searchGrid
        .GetRowAtIndex(_pointer.RowIndex)
        .GetCharacterAtIndex(_pointer.ColIndex);

      _searchTerm.Append(currentChar);
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
  }

}
