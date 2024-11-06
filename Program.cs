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

    // Load Data
    var data = LoadData(mlContext);

    // Define Pipeline
    var dataProcessPipeline = mLContext.Transforms.Conversion.ConvertType("Features", nameof(OddEvenData.Number), DataKind.Single);

    var trainer = mLContext.BinaryClassification.Trainers.FastTree(
      labelColumnName: "Label",
      featureColumnName: "Features",
      NumberOfLeaves: 10,
      learningRate: 0.1,
      numberOfTrees: 50
    );

    var trainingPipeline = dataProcessPipeline.Append(trainer);

    // Train the Model
    var model = trainingPipeline.Fit(data);

    // PredictionEngine for Testing!
    var predictionEngine = mLContext.Model.CreatePredictionEngine<OddEvenData, OddEvenPrediction>(model);

    // Test predictions
    var testNumbers = new float[] { 1, 2, 3, 13, 21, 15, 43, 34, 12,};
    Console.WriteLine("Predictions:");
    foreach (var number in testNumbers)
    {
      var prediction = predictionEngine.Predict(new OddEvenData { Number = number });
      Console.WriteLine($"Number: {number}, Prediction: {(prediction.Prediction ? "Even" : "Odd")}, Probability: {prediction.Probability:P2}");
    }
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