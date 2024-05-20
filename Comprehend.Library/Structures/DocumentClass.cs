using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Specifies the class that categorizes the document being analyzed")]
public struct DocumentClass
{
    [OSStructureField(Description = "The name of the class",
        DataType = OSDataType.Text)]
    public string Name;
    
    [OSStructureField(Description = "Page number in the input document. This field is present in the response only if your request includes the Byte parameter.",
        DataType = OSDataType.Integer)]
    public int? Page;
    
    [OSStructureField(Description = "The confidence level that Amazon Comprehend has in the accuracy of the detection",
        DataType = OSDataType.Decimal)]
    public float Score;
}