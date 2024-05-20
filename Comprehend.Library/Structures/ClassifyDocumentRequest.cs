using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Classify Document Request Parameters")]
public struct ClassifyDocumentRequest
{
    [OSStructureField(
        Description =
            "Use the Bytes parameter to input a text, PDF, Word or image file.\n\nWhen you classify a document using a custom model, you can also use the Bytes parameter to input an Amazon Textract DetectDocumentText or AnalyzeDocument output file.\n\nTo classify a document using the prompt safety classifier, use the Text parameter for input.",
        DataType = OSDataType.BinaryData,
        IsMandatory = false)]
    public byte[]? Bytes;

    [OSStructureField(
        Description =
            "Provides configuration parameters to override the default actions for extracting text from PDF documents and image files",
        IsMandatory = false)]
    public Amazon.Comprehend.Model.DocumentReaderConfig? DocumentReaderConfig;
    
    [OSStructureField(
        Description = "The Amazon Resource Number (ARN) of the endpoint. Mandatory.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string EndpointArn;
    
    [OSStructureField(Description = "A UTF-8 text string. The maximum string size is 100 KB. If you enter text using this parameter, do not use the Bytes parameter",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? Text;
}