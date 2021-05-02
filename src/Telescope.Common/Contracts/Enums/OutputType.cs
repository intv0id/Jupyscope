namespace Telescope.Common.Contracts.Enums
{
    public enum OutputType
    {
        stream,
        display_data,
        execute_result,
        error,
    }

    public static class OutputTypeNames
    {
        public const string Stream = "stream";
        public const string DisplayData = "display_data";
        public const string ExecuteResult = "execute_result";
        public const string Error = "error";
    }
}