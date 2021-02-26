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

    public void MovePointerUp()
    {
      _pointer.RowIndex--;
      if (_pointer.RowIndex == -1) 
        _pointer.RowIndex = NumberOfRows - 1;
    } 
    public void MovePointerDown()
    {
      _pointer.RowIndex++;
      if (_pointer.RowIndex == NumberOfRows) 
        _pointer.RowIndex = 0;
    }
    public void MovePointerLeft()
    {
      _pointer.ColIndex--;
      if (_pointer.ColIndex == -1) 
        _pointer.ColIndex = NumberOfColumns - 1;
    }
    public void MovePointerRight()
    {
      _pointer.ColIndex++;
      if (_pointer.ColIndex == NumberOfColumns)
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

    //at a minimum, NumberOfRows can be variable, and assuming the 36 characters remain the same,
    //NumberOfColumns can be derived
    //can also make order of AsciiValues variable (e.g. startingValue, doesZeroComeBeforeOne maybe all that's needed)

    //prolly move this to the Grid class
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
