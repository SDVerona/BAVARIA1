using Repo.Enums;
namespace Repo.Models;


public class BAVException:Exception
{ 
    public EnumErrorCode ErrorCode { get; set; }
    
    public BAVException(string? message = null, EnumErrorCode errorCode = EnumErrorCode.Unknown) : base(message ?? errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

    public BAVException(EnumErrorCode errorCode) : base(errorCode.GetDescription())
    {
        ErrorCode = errorCode;
    }

   
}