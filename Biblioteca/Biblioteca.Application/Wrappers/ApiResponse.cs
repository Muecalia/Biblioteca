
namespace Biblioteca.Application.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }

        public ApiResponse(T data, string message)
        {
            Data = data;
            Succeeded = true;
            Message = message;            
        }

        public ApiResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }

    }
}
