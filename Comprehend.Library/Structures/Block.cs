using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Information about each word or line of text in the input document")]
public struct Block
{
    [OSStructureField(
        Description = "The block represents a line of text or one word of text.\n\nWORD - A word that's detected on a document page. A word is one or more ISO basic Latin script characters that aren't separated by spaces.\n\nLINE - A string of tab-delimited, contiguous words that are detected on a document page",
        DataType = OSDataType.Text)]
    public string BlockType;
    
    [OSStructureField(
        Description = "Co-ordinates of the rectangle or polygon that contains the text")]
    public Geometry Geometry;
    
    [OSStructureField(
        Description = "Unique identifier for the block",
        DataType = OSDataType.Text)]
    public string Id;
    
    [OSStructureField(
        Description = "Page number where the block appears",
        DataType = OSDataType.Integer)]
    public int Page;
    
    [OSStructureField(
        Description = "A list of child blocks of the current block. For example, a LINE object has child blocks for each WORD block that's part of the line of text")]
    public List<RelationshipsListItem> Relationships;
    
    [OSStructureField(
        Description = "The word or line of text extracted from the block",
        DataType = OSDataType.Text)]
    public string Text;
}