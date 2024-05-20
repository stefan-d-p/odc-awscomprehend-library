using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Provides configuration parameters to override the default actions for extracting text from PDF documents and image files.\n\nBy default, Amazon Comprehend performs the following actions to extract text from files, based on the input file type:\n\nWord files - Amazon Comprehend parser extracts the text.\n\nDigital PDF files - Amazon Comprehend parser extracts the text.\n\nImage files and scanned PDF files - Amazon Comprehend uses the Amazon Textract DetectDocumentText API to extract the text")]
public struct DocumentReaderConfig
{
    [OSStructureField(
        Description =
            "This field defines the Amazon Textract API operation that Amazon Comprehend uses to extract text from PDF files and image files. Enter one of the following values:\n\nTEXTRACT_DETECT_DOCUMENT_TEXT - The Amazon Comprehend service uses the DetectDocumentText API operation.\n\nTEXTRACT_ANALYZE_DOCUMENT - The Amazon Comprehend service uses the AnalyzeDocument API operation.",
        DataType = OSDataType.Text,
        IsMandatory = false,
        DefaultValue = "TEXTRACT_DETECT_DOCUMENT_TEXT")]
    public string? DocumentReadAction;

    [OSStructureField(
        Description =
            "Determines the text extraction actions for PDF files. Enter one of the following values:\n\nSERVICE_DEFAULT - use the Amazon Comprehend service defaults for PDF files.\n\nFORCE_DOCUMENT_READ_ACTION - Amazon Comprehend uses the Textract API specified by DocumentReadAction for all PDF files, including digital PDF files.",
        DataType = OSDataType.Text,
        IsMandatory = false,
        DefaultValue = "SERVICE_DEFAULT")]
    public string? DocumentReadMode;

    [OSStructureField(
        Description =
            "Specifies the type of Amazon Textract features to apply. If you chose TEXTRACT_ANALYZE_DOCUMENT as the read action, you must specify one or both of the following values:\n\nTABLES - Returns additional information about any tables that are detected in the input document.\n\nFORMS - Returns additional information about any forms that are detected in the input document.",
        IsMandatory = false)]
    public List<string>? FeatureTypes;


}