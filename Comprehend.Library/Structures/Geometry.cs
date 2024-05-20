using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Information about the location of items on a document page")]
public struct Geometry
{
    [OSStructureField(Description = "An axis-aligned coarse representation of the location of the recognized item on the document page")]
    public BoundingBox BoundingBox;
    
    [OSStructureField(Description = "Within the bounding box, a fine-grained polygon around the recognized item")]
    public List<Point> Polygon;
}