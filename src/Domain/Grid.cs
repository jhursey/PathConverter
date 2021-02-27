
namespace PathConverter.Domain
{
  public class Grid
  {
    private Row[] _rows;

    public Grid(int numberOfRows, int numberOfColumns)
    {
      _rows = new Row[numberOfRows];
      PopulateGrid(numberOfRows, numberOfColumns, new GridCharacterOrder());
    }

    public Grid(int numberOfRows, int numberOfColumns, int configCode)
    {
      _rows = new Row[numberOfRows];
      PopulateGrid(numberOfRows, numberOfColumns, new GridCharacterOrder(configCode));
    }

    public Row GetRowAtIndex(int index) => _rows[index];
    public void SetRowAtIndex(Row row, int index) => _rows[index] = row;
    public void SetRows(Row[] rows) => _rows = rows;

    private void PopulateGrid(int numberOfRows, int numberOfColumns, GridCharacterOrder order)
    {
      var charValue = 
        order.StartWithNumbers
          ? AsciiValues.Zero
          : AsciiValues.A;

      for (var i = 0; i < numberOfRows; i++)
      {
        var row = new Row(numberOfColumns);
        for (var j = 0; j < numberOfColumns; j++)
        {
          switch (charValue)
          {
            case AsciiValues.OpenBracket when order.IsOneBeforeZero:
              charValue = AsciiValues.One;
              break;
            case AsciiValues.OpenBracket when !order.IsOneBeforeZero:
              charValue = AsciiValues.Zero;
              break;

            case AsciiValues.Colon when order.StartWithNumbers:
              charValue = AsciiValues.A;
              break;
            case AsciiValues.Colon when order.IsOneBeforeZero:
              charValue = AsciiValues.Zero;
              break;
          }

          row.SetCharacterAtIndex((char)charValue, j);
          charValue++;
        }
        SetRowAtIndex(row, i);
      }
    }

    public class GridCharacterOrder
    {
      public GridCharacterOrder() : this(0) { }

      public GridCharacterOrder(int configCode)
      {
        SetConfiguration(configCode);
      }

      public bool StartWithNumbers { get; set; }
      public bool IsOneBeforeZero { get; set; }

      public void SetConfiguration(int configCode)
      {
        switch (configCode)
        {
          case (int) OrderConfig.StartWithLettersThenOne:
            StartWithNumbers = false;
            IsOneBeforeZero = true;
            break;
          case (int) OrderConfig.StartWithLettersThenZero:
            StartWithNumbers = false;
            IsOneBeforeZero = false;
            break;
          case (int) OrderConfig.StartWithOne:
            StartWithNumbers = true;
            IsOneBeforeZero = false;
            break;
        }
      }

      public enum OrderConfig
      {
        StartWithLettersThenOne,
        StartWithLettersThenZero,
        StartWithOne
      }
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
