using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;


class Program 
{
  static void Main(string[] args)
  {
    MLContext mLContext = new MLContext();

    var data = LoadData(mlContext);

    var dataProcessPipeline = mLContext.Transforms.Conversion.ConvertType("Features", nameof(OddEvenData.Number), DataKind.Single);

    var trainer = mLContext.BinaryClassification.Trainers.FastTree(
      labelColumnName: "Label",
      featureColumnName: "Features",
      NumberOfLeaves: 10,
      learningRate: 0.1,
      numberOfTrees: 50
    );

    
  }

}

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