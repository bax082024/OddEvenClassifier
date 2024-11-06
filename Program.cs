using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;


public class OddEvenData
{
  [LoadColumn(0)]
  public float Number { get; set; }

  [LoadColumn(1)]
  public bool Label { get; set; }
}

public class OddEvenPrediction
{
  [ColumnName("PredictedLabel")]
  public bool Prediction { get; set; }
  public float Probability { get; set; }
  public float Score { get; set; }
}