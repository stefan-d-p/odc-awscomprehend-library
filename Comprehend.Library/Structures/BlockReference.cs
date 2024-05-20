using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "A reference to a block")]
public struct BlockReference
{
    [OSStructureField(Description = "Offset of the start of the block within its parent block",
        DataType = OSDataType.Integer)]
    public int BeginOffset;
    
    [OSStructureField(Description = "Unique identifier for the block",
        DataType = OSDataType.Text)]
    public string BlockId;

    [OSStructureField(Description = "List of child blocks within this block")]
    public List<ChildBlock> ChildBlocks;
    
    [OSStructureField(Description = "Offset of the end of the block within its parent block",
        DataType = OSDataType.Integer)]
    public int EndOffset;
}