using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
   public class OperationResult
    {
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }

        public OperationResult()
        {
            IsSucceeded = false;
        }
        public OperationResult Succeeded(string message = "عملیسات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}
