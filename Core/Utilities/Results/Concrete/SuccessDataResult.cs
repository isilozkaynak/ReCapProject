using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //kullanıcıdan data ve mesaj bilgisi alındığında:
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        //kullanıcıdan sadece data bilgisi alındığında:
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        //kullanıcıdan herhangi bir değer alınmadığında:
        public SuccessDataResult() : base(default, true)
        {

        }

        //kullanıcıdan sadece mesaj bilgisi alındığında:
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
    }
}
