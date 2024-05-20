using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Information about the document, discovered during text extraction")]
public struct DocumentMetadata
{
    [OSStructureField(
        Description = "List of pages in the document, with the number of characters extracted from each page")]
    public List<ExtractedCharactersListItem> ExtractedCharacters;

    [OSStructureField(
        Description = "Number of pages in the document",
        DataType = OSDataType.Integer)]
    public int Pages;
}