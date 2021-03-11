using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    //void metotlar için
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
