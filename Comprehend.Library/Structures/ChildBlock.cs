using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Nested block contained within a block")]
public struct ChildBlock
{
    [OSStructureField(Description = "Offset of the start of the child block within its parent block",
        DataType = OSDataType.Integer)]
    public int BeginOffset;

    [OSStructureField(Description = "Unique identifier for the child block",
        DataType = OSDataType.Text)]
    public string ChildBlockId;

    [OSStructureField(Description = "Offset of the end of the child block within its parent block",
        DataType = OSDataType.Integer)]
    public int EndOffset;
    
}