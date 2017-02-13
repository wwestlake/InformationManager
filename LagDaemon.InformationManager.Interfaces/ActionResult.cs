using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.Interfaces
{
    public class ActionResult<TResult>
    {
        public ActionResult(TResult result, ResultType resultType, string errorMessage = null)
        {
            this.Result = result;
            this.ResultType = resultType;
            this.ErrorMessage = errorMessage;
        }

        public ResultType ResultType { get; set; }
        public TResult Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
