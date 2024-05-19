using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(
    Description = "Returns the code for the dominant language in the input text and the level of confidence that Amazon Comprehend has in the accuracy of the detection.")]
public struct DominantLanguage
{
    [OSStructureField(
        Description =
            "The RFC 5646 language code for the dominant language. For more information about RFC 5646, see Tags for Identifying Languages on the IETF Tools web site.",
        DataType = OSDataType.Text)]
    public string LanguageCode;

    [OSStructureField(
        Description = "The level of confidence that Amazon Comprehend has in the accuracy of the detection.",
        DataType = OSDataType.Decimal)]
    public float Score;
}