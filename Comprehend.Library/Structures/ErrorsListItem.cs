using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Text extraction encountered one or more page-level errors in the input document.\n\nThe ErrorCode contains one of the following values:\n\nTEXTRACT_BAD_PAGE - Amazon Textract cannot read the page. For more information about page limits in Amazon Textract, see Page Quotas in Amazon Textract.\n\nTEXTRACT_PROVISIONED_THROUGHPUT_EXCEEDED - The number of requests exceeded your throughput limit. For more information about throughput quotas in Amazon Textract, see Default quotas in Amazon Textract.\n\nPAGE_CHARACTERS_EXCEEDED - Too many text characters on the page (10,000 characters maximum).\n\nPAGE_SIZE_EXCEEDED - The maximum page size is 10 MB.\n\nINTERNAL_SERVER_ERROR - The request encountered a service issue. Try the API request again.")]
public struct ErrorsListItem
{
    [OSStructureField(Description = "Error code for the cause of the error",
        DataType = OSDataType.Text)]
    public string ErrorCode;
    
    [OSStructureField(Description = "Text message explaining the reason of the error",
        DataType = OSDataType.Text)]
    public string ErrorMessage;
    
    [OSStructureField(Description = "Page number where the error occured",
        DataType = OSDataType.Integer)]
    public int Page;
}