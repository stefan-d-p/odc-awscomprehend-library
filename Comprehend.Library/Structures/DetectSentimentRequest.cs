using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Sentiment Request")]
public struct DetectSentimentRequest
{
    [OSStructureField(Description = "The language of the input documents. You can specify any of the primary languages supported by Amazon Comprehend. All documents must be in the same language",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string LanguageCode;
    
    [OSStructureField(Description = "A UTF-8 text string. The maximum string size is 5 KB",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text;
}