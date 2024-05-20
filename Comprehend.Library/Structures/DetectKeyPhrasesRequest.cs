using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Key Phrases Request")]
public struct DetectKeyPhrasesRequest
{
    [OSStructureField(Description = "The language of the input documents. You can specify any of the primary languages supported by Amazon Comprehend. All documents must be in the same language",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string LanguageCode;
    
    [OSStructureField(Description = "A UTF-8 text string. The string must contain less than 100 KB of UTF-8 encoded characters",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text;
}