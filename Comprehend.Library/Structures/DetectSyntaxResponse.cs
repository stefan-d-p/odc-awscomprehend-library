using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Detect Syntax Response")]
public struct DetectSyntaxResponse
{
    [OSStructureField(Description = "A collection of syntax tokens describing the text. For each token, the response provides the text, the token type, where the text begins and ends, and the level of confidence that Amazon Comprehend has that the token is correct.")]
    public List<SyntaxToken> SyntaxTokens;
}