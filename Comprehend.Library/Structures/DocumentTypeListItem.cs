using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Document type for each page in the document")]
public struct DocumentTypeListItem
{
    [OSStructureField(Description = "Page number",
        DataType = OSDataType.Integer)]
    public int Page;

    [OSStructureField(Description = "Document type",
        DataType = OSDataType.Text)]
    public string Type;
}