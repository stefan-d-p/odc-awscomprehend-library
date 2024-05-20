using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "List of child blocks for the current block")]
public struct RelationshipsListItem
{
    [OSStructureField(
        Description = "Identifers of the child blocks")]
    public List<string> Ids;

    [OSStructureField(
        Description = "Only supported relationship is a child relationship",
        DataType = OSDataType.Text)]
    public string Type;
}