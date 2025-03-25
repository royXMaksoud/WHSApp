namespace WHS.Domain.Exceptions;

//public class NotFoundException(string resourceType,string resourceIdentifier):Exception($"{resourceType} with id {resourceIdentifier} doesn't exist")
//{
//}
public class NotFoundException : Exception
{
    public string ResourceType { get; }
    public string ResourceIdentifier { get; }
    public int StatusCode { get; } = 404;  // with message number)

    public NotFoundException(string resourceType, string resourceIdentifier)
        : base($"{resourceType} with id {resourceIdentifier} doesn't exist")
    {
        ResourceType = resourceType;
        ResourceIdentifier = resourceIdentifier;
    }

    //add json message formatted
    public string ToJsonResponse()
    {
        return $"{{ \"error\": \"{Message}\", \"status\": {StatusCode} }}";
    }
}