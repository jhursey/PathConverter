
namespace PathConverter.Domain
{
  public class Grid
  {
    private Row[] _rows;
    private int _currentIndex;

    public Grid(int size)
    {
      _rows = new Row[size];
      _currentIndex = 0;
    }

    public Grid(int size, int currentIndex) : this(size)
    {
      _currentIndex = currentIndex;
    }

    public int GetCurrentIndex() => _currentIndex;
    public Row GetRowAtCurrentIndex() => _rows[_currentIndex];
    public Row GetRowAtIndex(int index) => _rows[index];
    public void SetCurrentIndex(int index) => _currentIndex = index;
    public void SetRows(Row[] rows) => _rows = rows;
    public void SetRowAtIndex(Row row, int index) => _rows[index] = row;
  }
}
