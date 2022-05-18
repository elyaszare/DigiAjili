//Operation Messages File
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
        //Succeeded Message
        public OperationResult Succeeded(string message = "عملیسات با موفقیت انجام شد")
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }
        //Failed Message
        public OperationResult Failed(string message)
        {
            IsSucceeded = false;
            Message = message;
            return this;
        }
    }
}
