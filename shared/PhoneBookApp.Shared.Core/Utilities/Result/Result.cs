namespace PhoneBookApp.Shared.Core.Utilities.Result
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public static Result Success(string? message = null)
        {
            return new Result
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static Result Fail(string message)
        {
            return new Result
            {
                IsSuccess = false,
                Message = message
            };
        }
    }

    public class Result<T> : Result
    {
        public T? Data { get; set; }

        public static Result<T> Success(T? data, string? message = null)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        public static new Result<T> Fail(string message)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Message = message,
                Data = default
            };
        }
    }
}
