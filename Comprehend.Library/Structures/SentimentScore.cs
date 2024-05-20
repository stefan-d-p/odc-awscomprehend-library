using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Describes the level of confidence that Amazon Comprehend has in the accuracy of its detection of sentiments")]
public struct SentimentScore
{
    [OSStructureField(
        Description =
            "The level of confidence that Amazon Comprehend has in the accuracy of its detection of the MIXED sentiment",
        DataType = OSDataType.Decimal)]
    public float Mixed;
    
    [OSStructureField(Description = "The level of confidence that Amazon Comprehend has in the accuracy of its detection of the NEGATIVE sentiment",
        DataType = OSDataType.Decimal)]
    public float Negative;
    
    [OSStructureField(Description = "The level of confidence that Amazon Comprehend has in the accuracy of its detection of the POSITIVE sentiment",
        DataType = OSDataType.Decimal)]
    public float Positive;
    
    [OSStructureField(Description = "The level of confidence that Amazon Comprehend has in the accuracy of its detection of the NEUTRAL sentiment",
        DataType = OSDataType.Decimal)]
    public float Neutral;
}