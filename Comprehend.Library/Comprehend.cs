using System.Net;
using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;
using Amazon.Runtime;
using AutoMapper;
using OutSystems.ExternalLibraries.SDK;
using Without.Systems.Comprehend.Extensions;
using Without.Systems.Comprehend.Structures;
using Without.Systems.Comprehend.Util;
using DominantLanguage = Without.Systems.Comprehend.Structures.DominantLanguage;

namespace Without.Systems.Comprehend;

public class Comprehend : IComprehend
{

    private readonly IMapper _mapper;
    
    public Comprehend()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Amazon.Comprehend.Model.DominantLanguage,
                Without.Systems.Comprehend.Structures.DominantLanguage>();
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
    public List<DominantLanguage> DetectDominantLanguage(Credentials credentials, string region, string text)
    {
        AmazonComprehendClient client = GetComprehendClient(credentials, region);

        DetectDominantLanguageRequest request = new DetectDominantLanguageRequest
        {
            Text = text
        };

        DetectDominantLanguageResponse response = AsyncUtil.RunSync(() => client.DetectDominantLanguageAsync(request));
        ParseResponse(response);
        
        return _mapper.Map<List<DominantLanguage>>(response.Languages);
    }
    
    private AmazonComprehendClient GetComprehendClient(Credentials credentials, string region) =>
        new AmazonComprehendClient(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));
    
    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
}