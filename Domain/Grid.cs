
namespace PathConverter.Domain
{
  public class Grid
  {
    private readonly Row[] _rows;

    public Grid(int numberOfRows, int numberOfColumns)
    {
      _rows = new Row[numberOfRows];
      PopulateGrid(numberOfRows, numberOfColumns, new CharacterOrder());
    }

    public Row GetRowAtIndex(int index) => _rows[index];
    public void SetRowAtIndex(Row row, int index) => _rows[index] = row;

    private void PopulateGrid(int numberOfRows, int numberOfColumns, CharacterOrder order)
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

    internal class CharacterOrder
    {
      internal CharacterOrder() : this(0) { }

      internal CharacterOrder(int configCode)
      {
        SetConfiguration(configCode);
      }

      internal bool StartWithNumbers { get; set; }
      internal bool IsOneBeforeZero { get; set; }

      private void SetConfiguration(int configCode)
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

      private enum OrderConfig
      {
        StartWithLettersThenOne,
        StartWithLettersThenZero,
        StartWithOne
      }
    }

    private enum AsciiValues
    {
      Zero = 48,
      One = 49,
      Colon = 58,
      A = 65,
      OpenBracket = 91
    }
  }
}
