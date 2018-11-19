class MultilineString
{
  public int LineAmount { get; set; }
  public class Line
  {
    public int LineNumber { get; set; }
    public string Content { get; set; }
    public Line NextLine { get; set; }
    public Line PreviousLine { get; set; }
  
    public Line(string content)
    {
      Content = content;
      NextLine = null;
      PreviousLine = null;
    }
  }
  
  public void NewLine(string content)
  {
    if(FirstLine == null)
    {
      FirstLine = new Line(content);
      LastLine = FirstLine;
    }
    else
    {
      Line newLine = new Line(content);
      LastLine.NextLine = newLine;
      newLine.PreviousLine = LastLine;
      LastLine = newLine;
    }
    AssignLineNumbers();
    LineAmount++;
  }
  
  public void InsertBefore (string content, int lineNumber)
  {
    Line line = LastLine;
    if (line != null)
    {
      NewLine(content);
    }
    while (line != null)
    {
      Line beforeLine = line.Previous;
      if(line.LineNumber == lineNumber)
      {
        Line newLine = line;
        line = new Line(content);
        line.NextLine = new Line();
        newLine.PreviousLine = beforeLine;
        beforeLine.Next = line;
        LineAmount++;
        break;
      }
      line = line.PreviousLine;
    }
  }
}
