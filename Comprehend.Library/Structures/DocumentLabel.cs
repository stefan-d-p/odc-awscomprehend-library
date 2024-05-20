using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Specifies one of the label or labels that categorize the document being analyzed")]
public struct DocumentLabel
{
    [OSStructureField(Description = "The name of the label",
        DataType = OSDataType.Text)]
    public string Name;
    
    [OSStructureField(Description = "Page number where the label occurs. This field is present in the response only if your request includes the Byte parameter",
        DataType = OSDataType.Integer)]
    public int? Page;

    [OSStructureField(Description = "The confidence score that Amazon Comprehend has this label correctly attributed",
        DataType = OSDataType.Decimal)]
    public float? Score;
}