using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayProgramming
{
    public sealed class Result<T>
    {
        public T Data { get; set; }
        public Error Error { get; set; }
        public readonly bool _isSuccess;
        private Result(T data)
        {
            Data = data;
            _isSuccess = true;
        }

        private Result(Error error)
        {
            Error = error;
            _isSuccess = false;
        }
        public bool Success() => _isSuccess;
        public static Result<T> Success(T data) => new Result<T>(data);

        public static Result<T> Failure(Error error) => new Result<T>(error);




    }


    public enum Error
    {
        Fail,
        ReturnedFalse,
        ExceptionRaised,
        InvalidAmount,
        AccountInvalid,
        CreditCardInvalid,
        PaymentFailed,
        OutofFunds,
        CardExpired,
        AccountSuspended
    }
}
