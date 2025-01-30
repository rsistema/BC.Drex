namespace BC.Drex.API.Dtos
{
    public class ResultResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public static ResultResponse<T> SuccessResult(T? data, string message = "")
        {
            return new ResultResponse<T> { Success = true, Data = data, Message = message };
        }

        public static ResultResponse<T> FailureResult(string message)
        {
            return new ResultResponse<T> { Success = false, Message = message };
        }
    }
}
