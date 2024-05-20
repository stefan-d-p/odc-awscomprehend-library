using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Describes a key noun phrase")]
public struct KeyPhrase
{
    [OSStructureField(Description = "The zero-based offset from the beginning of the source text to the first character in the key phrase",
        DataType = OSDataType.Integer)]
    public int BeginOffset;
    
    [OSStructureField(Description = "The zero-based offset from the beginning of the source text to the last character in the key phrase",
        DataType = OSDataType.Integer)]
    public int EndOffset;

    [OSStructureField(
        Description = "The level of confidence that Amazon Comprehend has in the accuracy of the detection",
        DataType = OSDataType.Decimal)]
    public float Score;
    
    [OSStructureField(Description = "The text of a key noun phrase", DataType = OSDataType.Text)]
    public string Text;
}