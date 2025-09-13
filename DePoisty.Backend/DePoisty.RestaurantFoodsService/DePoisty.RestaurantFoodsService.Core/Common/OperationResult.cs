namespace DePoisty.RestaurantFoodsService.Core.Common
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }

        public static OperationResult Success()
        {
            return new OperationResult { IsSuccess = true };
        }
        public static OperationResult Failure(string errorMessage)
        {
            return new OperationResult { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }
}
