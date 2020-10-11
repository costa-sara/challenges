using System.Collections.Generic;

namespace Kenbi.Domain.Dto
{
    public class ApiResultDto<TResult>
    {
        public ApiResultDto()
        {
            this.HasError = true;
        }


        public TResult Result { get; set; }
        public bool HasError { get; set; }
        public Error Error { get; set; }


        public ApiResultDto<TResult> OK(TResult result)
        {
            this.Result = result;
            this.HasError = false;

            return this;
        }

        public ApiResultDto<TResult> BadRequestResult(KeyValuePair<int, string> keyPairError)
        {
            Error = Error ?? new Error();
            this.Error.Code = keyPairError.Key;
            this.Error.Message = keyPairError.Value;
            this.HasError = true;
            return this;
        }
    }
}
