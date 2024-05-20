using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Sentiment Response")]
public struct DetectSentimentResponse
{
    [OSStructureField(Description = "The inferred sentiment that Amazon Comprehend has the highest level of confidence in",
        DataType = OSDataType.Text)]
    public string Sentiment;
    
    [OSStructureField(Description = "An object that lists the sentiments, and their corresponding confidence levels")]
    public SentimentScore SentimentScore;
}