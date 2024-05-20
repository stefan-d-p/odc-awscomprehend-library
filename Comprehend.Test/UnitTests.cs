using Amazon.Comprehend.Model;
using Microsoft.Extensions.Configuration;
using Without.Systems.Comprehend.Structures;
using DetectEntitiesRequest = Without.Systems.Comprehend.Structures.DetectEntitiesRequest;
using DetectKeyPhrasesRequest = Without.Systems.Comprehend.Structures.DetectKeyPhrasesRequest;
using DocumentReaderConfig = Amazon.Comprehend.Model.DocumentReaderConfig;

namespace Without.Systems.Comprehend.Test;

public class Tests
{
    private static readonly IComprehend _actions = new Comprehend();
    private Credentials _credentials;
    private readonly string _awsRegion = "eu-central-1";

    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        string awsAccessKey = configuration["AWSAccessKey"] ?? throw new InvalidOperationException();
        string awsSecretAccessKey = configuration["AWSSecretAccessKey"] ?? throw new InvalidOperationException();

        _credentials = new Credentials(awsAccessKey, awsSecretAccessKey);
        
    }

    [Test]
    public void DetectDominantLanguage_English()
    {

        string text =
            "We are excited to announce that Knowledge Bases for Amazon Bedrock (KB) now lets you configure inference parameters to have greater control over personalizing the responses generated by a foundation model (FM).";
        var result = _actions.DetectDominantLanguage(_credentials, _awsRegion, text);
        Assert.That(result.FirstOrDefault().LanguageCode, Is.EqualTo("en"));
    }

    [Test]
    public void DetectEntities()
    {
        string text =
            "Molly Gamble, vice president of editorial for Becker’s Healthcare, kicked off the webinar with results from her organization’s healthcare transformation trends survey. The survey, performed in partnership with Amazon Web Services (AWS), gathered responses from 115 healthcare leaders.";
        
        
        /* With empty initializer because OutSystems send default values for everything */
        DetectEntitiesRequest request = new DetectEntitiesRequest
        {
            Text = text,
            LanguageCode = "en",
            EndpointArn = "",
            Bytes = Array.Empty<byte>(),
            DocumentReaderConfig = new DocumentReaderConfig()
        };
        var result = _actions.DetectEntities(_credentials, _awsRegion, request);
        Assert.That(result.Entities.Count, Is.Positive);
    }
    
    [Test]
    public void DetectKeyPhrases()
    {
        string text =
            "Molly Gamble, vice president of editorial for Becker’s Healthcare, kicked off the webinar with results from her organization’s healthcare transformation trends survey. The survey, performed in partnership with Amazon Web Services (AWS), gathered responses from 115 healthcare leaders.";

        DetectKeyPhrasesRequest request = new DetectKeyPhrasesRequest
        {
            Text = text,
            LanguageCode = "en"
        };
        
        var result = _actions.DetectKeyPhrases(_credentials, _awsRegion, request);
        Assert.That(result.KeyPhrases.Count, Is.Positive);
    }

    [Test]
    public void DetectPiiEntities()
    {
        string text =
            "Molly Gamble, vice president of editorial for Becker’s Healthcare, kicked off the webinar with results from her organization’s healthcare transformation trends survey. The survey, performed in partnership with Amazon Web Services (AWS), gathered responses from 115 healthcare leaders.";

        Structures.DetectPiiEntitiesRequest request = new Structures.DetectPiiEntitiesRequest
        {
            Text = text,
            LanguageCode = "en"
        };
        
        var result = _actions.DetectPiiEntities(_credentials, _awsRegion, request);
        Assert.That(result.Entities.Count, Is.Positive);
    }

    [Test]
    public void DetectSentiment()
    {
        string text =
            "Molly Gamble, vice president of editorial for Becker’s Healthcare, kicked off the webinar with results from her organization’s healthcare transformation trends survey. The survey, performed in partnership with Amazon Web Services (AWS), gathered responses from 115 healthcare leaders.";
        
        Structures.DetectSentimentRequest request = new Structures.DetectSentimentRequest
        {
            Text = text,
            LanguageCode = "en"
        };
        
        var result = _actions.DetectSentiment(_credentials, _awsRegion, request);
        Assert.That(result.Sentiment,Is.EqualTo("NEUTRAL"));

    }

    [Test]
    public void DetectSyntax()
    {
        string text =
            "Molly Gamble, vice president of editorial for Becker’s Healthcare, kicked off the webinar with results from her organization’s healthcare transformation trends survey. The survey, performed in partnership with Amazon Web Services (AWS), gathered responses from 115 healthcare leaders.";

        Structures.DetectSyntaxRequest request = new Structures.DetectSyntaxRequest
        {
            Text = text,
            LanguageCode = "en"
        };

        var result = _actions.DetectSyntax(_credentials, _awsRegion, request);
        Assert.That(result.SyntaxTokens.Count, Is.Positive);
        
    }
}