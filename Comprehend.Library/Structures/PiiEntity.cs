using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Provides information about a PII entity")]
public struct PiiEntity
{
    [OSStructureField(Description = "The zero-based offset from the beginning of the source text to the first character in the entity",
        DataType = OSDataType.Integer)]
    public int BeginOffset;
    
    [OSStructureField(Description = "The zero-based offset from the beginning of the source text to the last character in the entity",
        DataType = OSDataType.Integer)]
    public int EndOffset;

    [OSStructureField(
        Description = "The level of confidence that Amazon Comprehend has in the accuracy of the detection",
        DataType = OSDataType.Decimal)]
    public float Score;
    
    [OSStructureField(Description = "The entity's type",
        DataType = OSDataType.Text)]
    public string Type;
}