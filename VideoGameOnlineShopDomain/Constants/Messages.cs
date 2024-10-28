namespace VideoGameOnlineShopDomain.Constants
{
    public static class Messages
    {
        public static string UnexpectedErrorOccured = "An unexpected error occurred.";
        public static string EntityNotFoundMessage(string entity)
        {
            return $"{entity} not found";
        }
    }
}
