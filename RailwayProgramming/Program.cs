// See https://aka.ms/new-console-template for more information
using RailwayProgramming;

Console.WriteLine("Hello, World!");

string abc = "xyz";



//Console.WriteLine(ad);

Result<decimal> ValidateMethod(decimal amount)
{
    return (amount > 0) ? Result<decimal>.Success(amount) : Result<decimal>.Failure(Error.AccountInvalid);
}
//public record class Email(string email_id);


Result<string> Create(string email)
{
    return Result<string>.Success(email);
}


var xy = Create("jagath").Validate(e => !string.IsNullOrEmpty(e), Error.CardExpired).Validate(e => e.Split("@").Length > 0, Error.Fail);

Console.WriteLine(xy);