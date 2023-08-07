namespace VideotekaAPI
{
    public class ResponseDetail
    {
        public bool IsSuccess { get; set; } = false;
        public string? ErrorMessage { get; set; }
        public Exception? Exception { get; set; }

        public ResponseDetail(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public ResponseDetail(bool isSuccess, string? errorMessage, Exception? exception) : this(isSuccess)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }
    }
}
