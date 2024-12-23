using DumpDrive.Data.Enums;

namespace DumpDrive.Domain.Extensions
{
    public static class StatusExtensions
    {
        public static bool IsOneOf(this Status status, params Status[] statusesToCheck)
        {
            return statusesToCheck.Contains(status);
        }
    }
}
