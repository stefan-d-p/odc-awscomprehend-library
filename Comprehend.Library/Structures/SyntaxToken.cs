using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.Comprehend.Structures;

[OSStructure(Description = "Represents a work in the input text that was recognized and assigned a part of speech. There is one syntax token record for each word in the source text")]
public struct SyntaxToken
{
    [OSStructureField(Description = "The zero-based offset from the beginning of the source text to the first character in the word.",
        DataType = OSDataType.Integer)]
    public int BeginOffset;
    
    [OSStructureField(Description = "The zero-based offset from the beginning of the source text to the last character in the word.",
        DataType = OSDataType.Integer)]
    public int EndOffset;
    
    [OSStructureField(Description = "Provides the part of speech label and the confidence level that Amazon Comprehend has that the part of speech was correctly identified.")]
    public PartOfSpeechTag PartOfSpeech;
    
    [OSStructureField(Description = "The word that was recognized in the source text",
        DataType = OSDataType.Text)]
    public string Text;
    
    [OSStructureField(Description = "A unique identifier for a token",
        DataType = OSDataType.Text)]
    public string TokenId;
}