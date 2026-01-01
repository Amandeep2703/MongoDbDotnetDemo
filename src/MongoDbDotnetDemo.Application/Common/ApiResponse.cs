using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Application.Common
{
    public class ApiResponse<T>
    {
        public bool Success
        {
            get; init;
        }
        public string Message { get; init; } = string.Empty;
        public T? Data
        {
            get; init;
        }
        public IReadOnlyList<string>? Errors
        {
            get; init;
        }

        public static ApiResponse<T> Ok(T data, string message) =>
            new()
            {
                Success = true,
                Message = message,
                Data = data
            };

        public static ApiResponse<T> Fail(string message, params string[] errors) =>
            new()
            {
                Success = false,
                Message = message,
                Errors = errors
            };
    }
}
