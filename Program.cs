using Microsoft.ML.Data;

public class OddEvenData
{
  [LoadColumn(0)]
  public float Number { get; set; }
  
  [LoadColumn(1)]
  public bool Label { get; set; }
}