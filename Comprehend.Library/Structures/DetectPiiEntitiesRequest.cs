using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;


[OSStructure(Description = "Detect PII Entities Request")]
public struct DetectPiiEntitiesRequest
{
    [OSStructureField(Description = "The language of the input text. Enter the language code for English (en) or Spanish (es).",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string LanguageCode;
    
    [OSStructureField(Description = "A UTF-8 text string. The maximum string size is 100 KB",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text;
}