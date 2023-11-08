namespace midis.muchik.market.crosscutting.models
{
    public class GenericResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public T Data { get; set; } = null!;

        public GenericResponse(T data) {
            Success = true;
            Message = string.Empty;
            Data = data;
        }

        public GenericResponse(string message) {
            Success = false;
            Message = message;
        }
    }
}
