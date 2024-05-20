using OutSystems.ExternalLibraries.SDK;
using Without.Systems.Comprehend.Structures;

namespace Without.Systems.Comprehend
{
    [OSInterface(
        Name = "AWSComprehend",
        Description = "Amazon Comprehend uses natural language processing (NLP) to extract insights about the content of documents. It develops insights by recognizing the entities, key phrases, language, sentiments, and other common elements in a document.",
        IconResourceName = "Without.Systems.Comprehend.Resources.Comprehend.png")]
    public interface IComprehend
    {

        [OSAction(
            Description =
                "Determines the dominant language of the input text. For a list of languages that Amazon Comprehend can detect",
            ReturnName = "list",
            ReturnDescription =
                "Array of languages that Amazon Comprehend detected in the input text. The array is sorted in descending order of the score (the dominant language is always the first element in the array)",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.Comprehend.Resources.Comprehend.png")]
        List<DominantLanguage> DetectDominantLanguage(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description =
                    "A UTF-8 text string. The string must contain at least 20 characters. The maximum string size is 100 KB.",
                DataType = OSDataType.Text)]
            string text);

        [OSAction(
            Description =
                "Detects named entities in input text when you use the pre-trained model. Detects custom entities if you have a custom entity recognition model",
            ReturnName = "result",
            ReturnDescription =
                "Detected Entities Result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.Comprehend.Resources.Comprehend.png")]
        DetectEntitiesResponse DetectEntities(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Detect Entities Request Parameters")]
            DetectEntitiesRequest detectEntitiesRequest);

        [OSAction(
            Description =
                "Detects the key noun phrases found in the text",
            ReturnName = "result",
            ReturnDescription =
                "Detected Key Phrases Result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.Comprehend.Resources.Comprehend.png")]
        DetectKeyPhrasesResponse DetectKeyPhrases(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Detect Key Phrases Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            DetectKeyPhrasesRequest detectKeyPhrasesRequest);

        [OSAction(
            Description =
                "Inspects the input text for entities that contain personally identifiable information (PII) and returns information about them",
            ReturnName = "result",
            ReturnDescription =
                "Detected PII Entities Result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.Comprehend.Resources.Comprehend.png")]
        DetectPiiEntitiesResponse DetectPiiEntities(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "Detect PII Entities Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            DetectPiiEntitiesRequest detectPiiEntitiesRequest);
    }
}