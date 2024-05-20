using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Entities response")]
public struct DetectEntitiesResponse
{
    [OSStructureField(Description = "Information about each block of text in the input document. Blocks are nested. A page block contains a block for each line of text, which contains a block for each word.\n\nThe Block content for a Word input document does not include a Geometry field.\n\nThe Block field is not present in the response for plain-text inputs.")]
    public List<Block> Blocks;
    
    [OSStructureField(Description = "Information about the document, discovered during text extraction. This field is present in the response only if your request used the Byte parameter")]
    public DocumentMetadata DocumentMetadata;

    [OSStructureField(Description =
        "The document type for each page in the input document. This field is present in the response only if your request used the Byte parameter")]
    public List<DocumentTypeListItem> DocumentType;
    
    [OSStructureField(Description = "A collection of entities identified in the input text. For each entity, the response provides the entity text, entity type, where the entity text begins and ends, and the level of confidence that Amazon Comprehend has in the detection.\n\nIf your request uses a custom entity recognition model, Amazon Comprehend detects the entities that the model is trained to recognize. Otherwise, it detects the default entity types. For a list of default entity types, see Entities in the Comprehend Developer Guide.")]
    public List<Entity> Entities;
    
    [OSStructureField(Description = "Page-level errors that the system detected while processing the input document. The field is empty if the system encountered no errors")]
    public List<ErrorsListItem> Errors;
}