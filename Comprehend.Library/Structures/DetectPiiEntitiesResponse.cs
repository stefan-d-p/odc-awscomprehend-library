using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect PII Entities Response")]
public struct DetectPiiEntitiesResponse
{
    [OSStructureField(Description = "A collection of PII entities identified in the input text. For each entity, the response provides the entity type, where the entity text begins and ends, and the level of confidence that Amazon Comprehend has in the detection.")]
    public List<PiiEntity> Entities;
}