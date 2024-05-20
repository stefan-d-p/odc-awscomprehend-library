using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Syntax Request Parameters")]
public struct DetectSyntaxRequest
{
    [OSStructureField(Description = "The language code of the input documents. You can specify any of the following languages supported by Amazon Comprehend: German (\"de\"), English (\"en\"), Spanish (\"es\"), French (\"fr\"), Italian (\"it\"), or Portuguese (\"pt\")",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string LanguageCode;
    
    [OSStructureField(Description = "A UTF-8 string. The maximum string size is 5 KB",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text;
}