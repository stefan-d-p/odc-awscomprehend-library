using Amazon.Comprehend.Model;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Entities request")]
public struct DetectEntitiesRequest
{
    [OSStructureField(
        Description =
            "This field applies only when you use a custom entity recognition model that was trained with PDF annotations. For other cases, enter your text input in the Text field.\n\nUse the Bytes parameter to input a text, PDF, Word or image file. Using a plain-text file in the Bytes parameter is equivelent to using the Text parameter (the Entities field in the response is identical).\n\nYou can also use the Bytes parameter to input an Amazon Textract DetectDocumentText or AnalyzeDocument output file.",
        DataType = OSDataType.BinaryData,
        IsMandatory = false)]
    public byte[]? Bytes;

    [OSStructureField(
        Description =
            "Provides configuration parameters to override the default actions for extracting text from PDF documents and image files",
        IsMandatory = false)]
    public DocumentReaderConfig? DocumentReaderConfig;
    
    [OSStructureField(
        Description = "The Amazon Resource Name of an endpoint that is associated with a custom entity recognition model. Provide an endpoint if you want to detect entities by using your own custom model instead of the default model that is used by Amazon Comprehend.\n\nIf you specify an endpoint, Amazon Comprehend uses the language of your custom model, and it ignores any language code that you provide in your request.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? EndpointArn;
    
    [OSStructureField(Description = "The language of the input documents. You can specify any of the primary languages supported by Amazon Comprehend. If your request includes the endpoint for a custom entity recognition model, Amazon Comprehend uses the language of your custom model, and it ignores any language code that you specify here. Mandatory when used with Text parameter.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? LanguageCode;
    
    [OSStructureField(Description = "A UTF-8 text string. The maximum string size is 100 KB. If you enter text using this parameter, do not use the Bytes parameter",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? Text;
}