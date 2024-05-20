using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Key Phrases Response")]
public struct DetectKeyPhrasesResponse
{
    [OSStructureField(Description = "A collection of key phrases that Amazon Comprehend identified in the input text. For each key phrase, the response provides the text of the key phrase, where the key phrase begins and ends, and the level of confidence that Amazon Comprehend has in the accuracy of the detection")]
    public List<KeyPhrase> KeyPhrases;
}