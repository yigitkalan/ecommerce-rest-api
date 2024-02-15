using Newtonsoft.Json;

namespace Ecommerce.Application.Exceptions;
public class ExceptionModel: ErrorStatusCode
{
    //keeping them as IEnumerable to handle inner exceptions
    public IEnumerable<string> Errors { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(Errors);
    

}

public class ErrorStatusCode{
    public int StatusCode { get; set; }
}
