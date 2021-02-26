using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathConverter.Domain
{
  public class Remote
  {
    private const int NumberOfRows = 6;
    private const int NumberOfColumns = 6;

    private Grid _searchGrid;
    private StringBuilder _searchTerm;
    private SearchPointer _pointer;

    public Remote()
    {
      _searchGrid = PopulateGrid();
      _searchTerm = new StringBuilder();
      _pointer = new SearchPointer();
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

    private static Grid PopulateGrid()
    {
      var grid = new Grid(NumberOfRows);
      var charValue = AsciiValues.A;
      for (var i = 0; i < NumberOfRows; i++)
      {
        var row = new Row(NumberOfColumns);
        for (var j = 0; j < NumberOfColumns; j++)
        {
          if (charValue == AsciiValues.OpenBracket) charValue = AsciiValues.One;
          if (charValue == AsciiValues.Colon) charValue = AsciiValues.Zero;

          row.SetCharacterAtIndex((char)charValue, j);
          charValue++;
        }
        grid.SetRowAtIndex(row, i);
      }

      return grid;
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

  public enum AsciiValues
  {
    Zero = 48,
    One = 49,
    Colon = 58,
    A = 65,
    OpenBracket = 91
  }

}
