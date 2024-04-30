namespace Smarti.Models
{
    
        public class ResponseMessage<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }

            public ResponseMessage(bool success, string message, T data)
            {
                Success = success;
                Message = message;
                Data = data;
            }
        }

    
}
