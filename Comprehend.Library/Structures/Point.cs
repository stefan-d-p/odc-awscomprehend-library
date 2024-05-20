using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "The X and Y coordinates of a point on a document page.")]
public struct Point
{
    [OSStructureField(Description = "The value of the X coordinate for a point on a polygon",
        DataType = OSDataType.Decimal)]
    public float X;

    [OSStructureField(Description = "The value of the Y coordinate for a point on a polygon",
        DataType = OSDataType.Decimal)]
    public float Y;
}