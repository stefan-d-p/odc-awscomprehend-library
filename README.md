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
