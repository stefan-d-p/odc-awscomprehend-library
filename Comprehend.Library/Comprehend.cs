using System.Net;
using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;
using AutoMapper;
using Without.Systems.Comprehend.Extensions;
using Without.Systems.Comprehend.Structures;
using Without.Systems.Comprehend.Util;

namespace Without.Systems.Comprehend;

public class Comprehend : IComprehend
{

    private readonly IMapper _mapper;
    
    public Comprehend()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            /*
             * Request Mapping Configurations
             */
            
            cfg.CreateMap<Structures.DetectEntitiesRequest, Amazon.Comprehend.Model.DetectEntitiesRequest>()
                .ForMember(dest => dest.EndpointArn, opt => opt.Condition(src => !string.IsNullOrEmpty(src.EndpointArn)))
                .ForMember(dest => dest.Text, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Text)))
                .ForMember(dest => dest.DocumentReaderConfig, opt => opt.Condition(src => src.Bytes is { Length: > 0 }))
                .ForMember(dest => dest.LanguageCode, opt => opt.Condition(src => !string.IsNullOrEmpty(src.LanguageCode)))
                .ForMember(dest => dest.LanguageCode, opt => opt.MapFrom(src => LanguageCode.FindValue(src.LanguageCode)))
                .ForMember(dest => dest.Bytes, opt => opt.Condition(src => src.Bytes is { Length: > 0 }))
                .ForMember(dest => dest.Bytes, opt => opt.MapFrom(src => new MemoryStream(src.Bytes!)));
            
            cfg.CreateMap<Structures.ClassifyDocumentRequest, Amazon.Comprehend.Model.ClassifyDocumentRequest>()
                .ForMember(dest => dest.EndpointArn, opt => opt.Condition(src => !string.IsNullOrEmpty(src.EndpointArn)))
                .ForMember(dest => dest.Text, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Text)))
                .ForMember(dest => dest.DocumentReaderConfig, opt => opt.Condition(src => src.Bytes is { Length: > 0 }))
                .ForMember(dest => dest.Bytes, opt => opt.Condition(src => src.Bytes is { Length: > 0 }))
                .ForMember(dest => dest.Bytes, opt => opt.MapFrom(src => new MemoryStream(src.Bytes!)));

            cfg.CreateMap<Structures.DetectKeyPhrasesRequest, Amazon.Comprehend.Model.DetectKeyPhrasesRequest>()
                .ForMember(dest => dest.LanguageCode,
                    opt => opt.MapFrom(src => LanguageCode.FindValue(src.LanguageCode)));

            cfg.CreateMap<Structures.DetectPiiEntitiesRequest, Amazon.Comprehend.Model.DetectPiiEntitiesRequest>()
                .ForMember(dest => dest.LanguageCode,
                    opt => opt.MapFrom(src => LanguageCode.FindValue(src.LanguageCode)));
            
            cfg.CreateMap<Structures.DetectSentimentRequest, Amazon.Comprehend.Model.DetectSentimentRequest>()
                .ForMember(dest => dest.LanguageCode,
                    opt => opt.MapFrom(src => LanguageCode.FindValue(src.LanguageCode)));
            
            cfg.CreateMap<Structures.DetectSyntaxRequest, Amazon.Comprehend.Model.DetectSyntaxRequest>()
                .ForMember(dest => dest.LanguageCode,
                    opt => opt.MapFrom(src => SyntaxLanguageCode.FindValue(src.LanguageCode)));
            
            /*
             * Response Mapping Configuration
             */
            
            cfg.CreateMap<Amazon.Comprehend.Model.DetectEntitiesResponse,Structures.DetectEntitiesResponse>();
            
            cfg.CreateMap<Amazon.Comprehend.Model.DetectKeyPhrasesResponse,Structures.DetectKeyPhrasesResponse>();
            
            cfg.CreateMap<Amazon.Comprehend.Model.DetectPiiEntitiesResponse,Structures.DetectPiiEntitiesResponse>();
            
            cfg.CreateMap<Amazon.Comprehend.Model.DetectSentimentResponse,Structures.DetectSentimentResponse>();
            
            cfg.CreateMap<Amazon.Comprehend.Model.DetectSyntaxResponse,Structures.DetectSyntaxResponse>();

            cfg.CreateMap<Amazon.Comprehend.Model.ClassifyDocumentResponse, Structures.ClassifyDocumentResponse>();
            
            /*
             * Individual Mappings
             */
            
            cfg.CreateMap<Amazon.Comprehend.Model.DominantLanguage,Structures.DominantLanguage>();
            cfg.CreateMap<Amazon.Comprehend.Model.Block, Structures.Block>();
            cfg.CreateMap<Amazon.Comprehend.Model.BlockReference, Structures.BlockReference>();
            cfg.CreateMap<Amazon.Comprehend.Model.BoundingBox, Structures.BoundingBox>();
            cfg.CreateMap<Amazon.Comprehend.Model.ChildBlock, Structures.ChildBlock>();
            cfg.CreateMap<Amazon.Comprehend.Model.DocumentMetadata, Structures.DocumentMetadata>();
            cfg.CreateMap<Amazon.Comprehend.Model.DocumentTypeListItem, Structures.DocumentTypeListItem>();
            cfg.CreateMap<Amazon.Comprehend.Model.Entity, Structures.Entity>();
            cfg.CreateMap<Amazon.Comprehend.Model.ErrorsListItem, Structures.ErrorsListItem>();
            cfg.CreateMap<Amazon.Comprehend.Model.ExtractedCharactersListItem, Structures.ExtractedCharactersListItem>();
            cfg.CreateMap<Amazon.Comprehend.Model.Geometry, Structures.Geometry>();
            cfg.CreateMap<Amazon.Comprehend.Model.Point, Structures.Point>();
            cfg.CreateMap<Amazon.Comprehend.Model.RelationshipsListItem, Structures.RelationshipsListItem>();
            cfg.CreateMap<Amazon.Comprehend.Model.DocumentReaderConfig, Structures.DocumentReaderConfig>();
            cfg.CreateMap<Amazon.Comprehend.Model.KeyPhrase, Structures.KeyPhrase>();
            cfg.CreateMap<Amazon.Comprehend.Model.PiiEntity, Structures.PiiEntity>();
            cfg.CreateMap<Amazon.Comprehend.Model.SentimentScore, Structures.SentimentScore>();
            cfg.CreateMap<Amazon.Comprehend.Model.PartOfSpeechTag, Structures.PartOfSpeechTag>();
            cfg.CreateMap<Amazon.Comprehend.Model.SyntaxToken, Structures.SyntaxToken>();
            cfg.CreateMap<Amazon.Comprehend.Model.DocumentLabel, Structures.DocumentLabel>();
            cfg.CreateMap<Amazon.Comprehend.Model.DocumentClass, Structures.DocumentClass>();
            cfg.CreateMap<Amazon.Comprehend.Model.WarningsListItem, Structures.WarningsListItem>();

        });
        _mapper = mapperConfiguration.CreateMapper();
    }

    /// <summary>
    /// Determines the dominant language of the input text. For a list of languages that Amazon Comprehend can detect.
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="text">A UTF-8 text string. The string must contain at least 20 characters. The maximum string size is 100 KB.</param>
    /// <returns>Array of languages that Amazon Comprehend detected in the input text. The array is sorted in descending order of the score (the dominant language is always the first element in the array)</returns>
    public List<Structures.DominantLanguage> DetectDominantLanguage(Credentials credentials, string region, string text)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);

        DetectDominantLanguageRequest request = new DetectDominantLanguageRequest
        {
            Text = text
        };

        DetectDominantLanguageResponse response = AsyncUtil.RunSync(() => client.DetectDominantLanguageAsync(request));
        ParseResponse(response);
        
        return _mapper.Map<List<Structures.DominantLanguage>>(response.Languages);
    }

    /// <summary>
    /// Detects named entities in input text when you use the pre-trained model. Detects custom entities if you have a custom entity recognition model
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="detectEntitiesRequest">Detect Entities Request</param>
    /// <returns>Detected Entities result</returns>
    public Structures.DetectEntitiesResponse DetectEntities(Credentials credentials, string region, Structures.DetectEntitiesRequest detectEntitiesRequest)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);
        var request = _mapper.Map<Amazon.Comprehend.Model.DetectEntitiesRequest>(detectEntitiesRequest);
        
        Amazon.Comprehend.Model.DetectEntitiesResponse response = AsyncUtil.RunSync(() => client.DetectEntitiesAsync(request));
        ParseResponse(response);
        
        return _mapper.Map<Structures.DetectEntitiesResponse>(response);
    }

    /// <summary>
    /// Detects the key noun phrases found in the text
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="detectKeyPhrasesRequest">Detect Key Phrases Request Parameters</param>
    /// <returns>Detected Key Phrases Array</returns>
    public Structures.DetectKeyPhrasesResponse DetectKeyPhrases(Credentials credentials, string region,
        Structures.DetectKeyPhrasesRequest detectKeyPhrasesRequest)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);
        var request = _mapper.Map<Amazon.Comprehend.Model.DetectKeyPhrasesRequest>(detectKeyPhrasesRequest);
        Amazon.Comprehend.Model.DetectKeyPhrasesResponse response = AsyncUtil.RunSync(() => client.DetectKeyPhrasesAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.DetectKeyPhrasesResponse>(response);
    }

    /// <summary>
    /// Inspects the input text for entities that contain personally identifiable information (PII) and returns information about them
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="detectPiiEntitiesRequest">Detect PII Entities Request parameters</param>
    /// <returns>Detected PII Entities</returns>
    public Structures.DetectPiiEntitiesResponse DetectPiiEntities(Credentials credentials, string region,
        Structures.DetectPiiEntitiesRequest detectPiiEntitiesRequest)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);
        var request = _mapper.Map<Amazon.Comprehend.Model.DetectPiiEntitiesRequest>(detectPiiEntitiesRequest);
        Amazon.Comprehend.Model.DetectPiiEntitiesResponse response = AsyncUtil.RunSync(() => client.DetectPiiEntitiesAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.DetectPiiEntitiesResponse>(response);
    }

    /// <summary>
    /// Inspects text and returns an inference of the prevailing sentiment (POSITIVE, NEUTRAL, MIXED, or NEGATIVE)
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="detectSentimentRequest">Detect Sentiment Request Parameters</param>
    /// <returns>Detected Sentiment</returns>
    public Structures.DetectSentimentResponse DetectSentiment(Credentials credentials, string region,
        Structures.DetectSentimentRequest detectSentimentRequest)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);
        var request = _mapper.Map<Amazon.Comprehend.Model.DetectSentimentRequest>(detectSentimentRequest);
        Amazon.Comprehend.Model.DetectSentimentResponse response = AsyncUtil.RunSync(() => client.DetectSentimentAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.DetectSentimentResponse>(response);
    }

    /// <summary>
    /// Inspects text for syntax and the part of speech of words in the document.
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="detectSyntaxRequest">Detect Syntax Request Parameters</param>
    /// <returns>Array of Syntax Tokens</returns>
    public Structures.DetectSyntaxResponse DetectSyntax(Credentials credentials, string region,
        Structures.DetectSyntaxRequest detectSyntaxRequest)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);
        var request = _mapper.Map<Amazon.Comprehend.Model.DetectSyntaxRequest>(detectSyntaxRequest);
        Amazon.Comprehend.Model.DetectSyntaxResponse response = AsyncUtil.RunSync(() => client.DetectSyntaxAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.DetectSyntaxResponse>(response);
    }
    
    /// <summary>
    /// Creates a classification request to analyze a single document in real-time. ClassifyDocument supports the following model types:
    /// Custom classifier - a custom model that you have created and trained. For input, you can provide plain text, a single-page document (PDF, Word, or image), or Amazon Textract API output. For more information, see Custom classification in the Amazon Comprehend Developer Guide.
    /// Prompt safety classifier - Amazon Comprehend provides a pre-trained model for classifying input prompts for generative AI applications. For input, you provide English plain text input. For prompt safety classification, the response includes only the Classes field. For more information about prompt safety classifiers, see Prompt safety classification in the Amazon Comprehend Developer Guide.
    /// If the system detects errors while processing a page in the input document, the API response includes an Errors field that describes the errors.
    /// </summary>
    /// <param name="credentials">AWS IAM Credentials</param>
    /// <param name="region">System name of AWS region</param>
    /// <param name="classifyDocumentRequest">Classify Document Request Parameters</param>
    /// <returns>Classify Document Result Structure</returns>
    public Structures.ClassifyDocumentResponse ClassifyDocument(Credentials credentials, string region, 
        Structures.ClassifyDocumentRequest classifyDocumentRequest)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);
        var request = _mapper.Map<Amazon.Comprehend.Model.ClassifyDocumentRequest>(classifyDocumentRequest);
        Amazon.Comprehend.Model.ClassifyDocumentResponse response = AsyncUtil.RunSync(() => client.ClassifyDocumentAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.ClassifyDocumentResponse>(response);
    }
    
    private AmazonComprehendClient GetComprehendClient(Credentials credentials, string region) =>
        new AmazonComprehendClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));
    
    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
}