namespace FarmerAPI.Domain.Contracts
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public int statusCode { get; set; }
    }
}
