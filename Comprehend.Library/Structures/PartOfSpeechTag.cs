using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Identifies the part of speech represented by the token and gives the confidence that Amazon Comprehend has that the part of speech was correctly identified")]
public struct PartOfSpeechTag
{
    [OSStructureField(
        Description = "The confidence that Amazon Comprehend has that the part of speech was correctly identified",
        DataType = OSDataType.Decimal)]
    public float Score;
    
    [OSStructureField(Description = "Identifies the part of speech that the token represents",
        DataType = OSDataType.Text)]
    public string Tag;
}