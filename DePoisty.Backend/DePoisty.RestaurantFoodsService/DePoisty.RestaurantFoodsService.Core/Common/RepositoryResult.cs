namespace DePoisty.RestaurantFoodsService.Core.Common
{
    public class RepositoryResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public static RepositoryResult Success()
        {
            return new RepositoryResult { IsSuccess = true };
        }
        public static RepositoryResult Failure(string errorMessage)
        {
            return new RepositoryResult { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }
}
