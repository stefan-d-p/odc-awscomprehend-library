using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "The bounding box around the detected page or around an element on a document page. The left (x-coordinate) and top (y-coordinate) are coordinates that represent the top and left sides of the bounding box. Note that the upper-left corner of the image is the origin (0,0)")]
public struct BoundingBox
{
    [OSStructureField(Description = "The height of the bounding box as a ratio of the overall document page height",
        DataType = OSDataType.Decimal)]
    public float Height;

    [OSStructureField(Description = "The left coordinate of the bounding box as a ratio of overall document page width",
        DataType = OSDataType.Decimal)]
    public float Left;

    [OSStructureField(Description = "The top coordinate of the bounding box as a ratio of overall document page height",
        DataType = OSDataType.Decimal)]
    public float Top;

    [OSStructureField(Description = "The width of the bounding box as a ratio of the overall document page width",
        DataType = OSDataType.Decimal)]
    public float Width;
}