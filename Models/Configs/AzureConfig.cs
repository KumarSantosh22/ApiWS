namespace Service.Configs
{
    public class AzureConfig
    {
        public string BlobConnectionString { get; set; } = string.Empty;
        public string StorageBaseUrl { get; set; } = "https://sanplaygroundbece.blob.core.windows.net";
        public string BlobContainer { get; set; } = "file-upload";
    }
}
