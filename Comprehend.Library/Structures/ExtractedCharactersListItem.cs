using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Array of the number of characters extracted from each page")]
public struct ExtractedCharactersListItem
{
    [OSStructureField(
        Description = "Number of characters extracted from each page",
        DataType = OSDataType.Integer)]
    public int Count;

    [OSStructureField(
        Description = "Page number",
        DataType = OSDataType.Integer)]
    public int Page;
}