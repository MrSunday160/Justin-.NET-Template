namespace __ProjectName__.Domain.Common {
    public class CrudResponse {

        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public Base? Entity { get; set; }
        public object? Objects { get; set; }

    }
}
