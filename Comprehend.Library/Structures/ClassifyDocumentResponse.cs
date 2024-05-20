using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Classify Document Response")]
public struct ClassifyDocumentResponse
{
    [OSStructureField(Description =
        "The classes used by the document being analyzed. These are used for models trained in multi-class mode. Individual classes are mutually exclusive and each document is expected to have only a single class assigned to it. For example, an animal can be a dog or a cat, but not both at the same time.\n\nFor prompt safety classification, the response includes only two classes (SAFE_PROMPT and UNSAFE_PROMPT), along with a confidence score for each class. The value range of the score is zero to one, where one is the highest confidence.")]
    public List<DocumentClass> Classes;

    [OSStructureField(Description =
        "Extraction information about the document. This field is present in the response only if your request includes the Byte parameter")]
    public DocumentMetadata DocumentMetadata;

    [OSStructureField(Description =
        "The document type for each page in the input document. This field is present in the response only if your request includes the Byte parameter.")]
    public List<DocumentTypeListItem> DocumentType;

    [OSStructureField(Description =
        "Page-level errors that the system detected while processing the input document. The field is empty if the system encountered no errors.")]
    public List<ErrorsListItem> Errors;

    [OSStructureField(Description =
        "The labels used in the document being analyzed. These are used for multi-label trained models. Individual labels represent different categories that are related in some manner and are not mutually exclusive. For example, a movie can be just an action movie, or it can be an action movie, a science fiction movie, and a comedy, all at the same time.")]
    public List<DocumentLabel> Labels;

    [OSStructureField(Description =
        "Warnings detected while processing the input document. The response includes a warning if there is a mismatch between the input document type and the model type associated with the endpoint that you specified. The response can also include warnings for individual pages that have a mismatch.")]
    public List<WarningsListItem> Warnings;
}