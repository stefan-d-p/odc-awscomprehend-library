using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "The system identified one of the following warnings while processing the input document:\n\nThe document to classify is plain text, but the classifier is a native document model.\n\nThe document to classify is semi-structured, but the classifier is a plain-text model.")]
public struct WarningsListItem
{
    [OSStructureField(Description = "Page number in the input document",
        DataType = OSDataType.Integer)]
    public int? Page;

    [OSStructureField(Description = "The type of warning",
        DataType = OSDataType.Text)]
    public string WarnCode;

    [OSStructureField(Description = "Text message associated with the warning.",
        DataType = OSDataType.Text)]
    public string WarnMessage;
}