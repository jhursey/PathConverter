
namespace PathConverter.Domain
{
  public class Grid
  {
    private Row[] _rows;

    public Grid(int size)
    {
      _rows = new Row[size];
    }

    public Row GetRowAtIndex(int index) => _rows[index];
    public void SetRowAtIndex(Row row, int index) => _rows[index] = row;
    public void SetRows(Row[] rows) => _rows = rows;
  }
}
