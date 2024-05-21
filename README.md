# OutSystems Developer Cloud External Logic Connector Library for AWS Comprehend

## Actions
The library exposes the following actions

### DetectDominantLanguage

Determines the dominant language of the input text. For a list of languages that Amazon Comprehend can detect.

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `text` - A UTF-8 text string. The string must contain at least 20 characters. The maximum string size is 100 KB.

**Result**

* `list` - Array of languages that Amazon Comprehend detected in the input text. The array is sorted in descending order of the score (the dominant language is always the first element in the array)

### DetectEntities

Detects named entities in input text when you use the pre-trained model. Detects custom entities if you have a custom entity recognition model

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `detectEntitiesRequest` - Detect Entities Request Parameters 

**Result**

* `result` - detected Entities

### DetectKeyPhrases

Detects the key noun phrases found in the text

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `detectKeyPhrasesRequest` - Detect Key Phrases Request Parameters

**Result**

* `result` - detected Key Phrases

### DetectPiiEntities

Inspects the input text for entities that contain personally identifiable information (PII) and returns information about them

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `detectPiiEntitiesRequest` - Detect PII Entities Request Parameters

**Result**

* `result` - detected PIIs

### DetectSentiment

Inspects text and returns an inference of the prevailing sentiment (POSITIVE, NEUTRAL, MIXED, or NEGATIVE)

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `detectSentimentRequest` - Detect Sentiment Request Parameters

**Result**

* `result` - detected Sentiment

### DetectSyntax

Inspects text for syntax and the part of speech of words in the document

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `detectSyntaxRequest` - Detect Syntax Request Parameters

**Result**

* `result` - detected Syntax

### ClassifyDocument

Creates a classification request to analyze a single document in real-time. **Requires a custom model**

**Input parameters**

* `credentials` - AWS IAM credentials. You can either use IAM user credentials (Access Key and Secret Access Key) or an IAM role (Access Key, Secret Access Key and Session Token)
* `region` - The AWS region system name (e.g. us-east-1).
* `classifyDocumentRequest` - Classify Document Request Parameters

**Result**

* `result` - detected Syntax


