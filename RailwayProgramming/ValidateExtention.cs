using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RailwayProgramming
{
    public static class ValidateExtention
    {
        //https://www.slideshare.net/Tama000/railway-orientated-programming-in-c
        public static Result<T> Validate<T>(this Result<T> output, Func<T, bool> predicate, Error error)
        {
            if (!output.Success())
            {
                return output;
            }
            return predicate(output.Data) ? output : Result<T>.Failure(error);
        }

        public static Result<Tout> Bind<Tin, Tout>(this Result<Tin> value, Func<Tin, Tout> singleFunc)
        {
            return value.Success() ? Result<Tout>.Success(singleFunc(value.Data)) : Result<Tout>.Failure(value.Error);
        }

        public static Result<Tout> Succeed<Tin, Tout>(this Result<Tin> value, Func<Tin, Tout> singleFunc)
        {
            return Result<Tout>.Success(singleFunc(value.Data));
        }

        public static Result<Tout> TryCatch<Tin, Tout>(this Result<Tin> value, Func<Tin, Tout> singleFunc)
        {
            try
            {
                return value.Success() ? Result<Tout>.Success(singleFunc(value.Data)) : Result<Tout>.Failure(value.Error);

            }
            catch
            {
                return Result<Tout>.Failure(Error.ExceptionRaised);
            }
        }
        public static Result<Tout> Fail<Tin, Tout>(this Result<Tin> value, Func<Tin, Tout> singleFunc)
        {
            singleFunc(value.Data);
            return Result<Tout>.Failure(Error.Fail);
        }
        public static Result<Tout> Map<Tin, Tout>(this Result<Tin> value, Func<Tin, Result<Tout>> mapFun)
        {
            return value.Success() ? mapFun(value.Data) : Result<Tout>.Failure(value.Error);
        }

        public static Result<Tout> DoubleMap<Tin, Tout>(this Result<Tin> value, Func<Tin, Tout> singleFunc, Func<Tin, Tout> failureSingleFunc)
        {
            if (value.Success())
            {
                return Result<Tout>.Success(singleFunc(value.Data));
            }
            failureSingleFunc(value.Data);
            return Result<Tout>.Failure(value.Error);
        }

        public static Result<T> Tee<T>(this Result<T> value, Action<T> deadEndFunc)
        {
            if (value.Success())
            {
                deadEndFunc(value.Data);
            }

            return value;
        }

        public static Result<bool> BooleanSwitch<Tin>(this Result<Tin> value, Func<Tin, bool> singleFunc)
        {
            if (value.Success())
            {
                return singleFunc(value.Data) ? Result<bool>.Success(true) : Result<bool>.Failure(Error.ReturnedFalse);
            }

            return Result<bool>.Failure(value.Error);
        }

        
    }





}
