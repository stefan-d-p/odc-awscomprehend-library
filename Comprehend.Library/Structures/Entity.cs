using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Provides information about an entity")]
public struct Entity
{
    [OSStructureField(
        Description =
            "The zero-based offset from the beginning of the source text to the first character in the entity.\n\nThis field is empty for non-text input.",
        DataType = OSDataType.Integer)]
    public int BeginOffset;

    [OSStructureField(Description =
        "A reference to each block for this entity. This field is empty for plain-text input")]
    public List<BlockReference> BlockReferences;

    [OSStructureField(
        Description = "The zero-based offset from the beginning of the source text to the last character in the entity",
        DataType = OSDataType.Integer)]
    public int EndOffset;

    [OSStructureField(
        Description = "The level of confidence that Amazon Comprehend has in the accuracy of the detection",
        DataType = OSDataType.Decimal)]
    public float Score;
    
    [OSStructureField(
        Description = "The text of the entity",
        DataType = OSDataType.Text)]
    public string Text;

    [OSStructureField(
        Description =
            "The entity type. For entity detection using the built-in model, this field contains one of the standard entity types listed below.\n\nFor custom entity detection, this field contains one of the entity types that you specified when you trained your custom model.",
        DataType = OSDataType.Text)]
    public string Type;
}