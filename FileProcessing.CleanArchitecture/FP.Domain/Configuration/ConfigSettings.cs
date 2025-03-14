namespace FP.Domain.Configuration
{
    public class ConfigSettings
    {
        public string StoragePath { get; set; } = string.Empty;
        public int MaxFileSize { get; set; }
        public bool EnableLogging { get; set; }
    }
}

