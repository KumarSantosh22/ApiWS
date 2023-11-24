using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Service.Configs;

namespace Service
{
    public class AzureStorage
    {
        private readonly AzureConfig config;
        public AzureStorage(AzureConfig azureConfig)
        {
            this.config = azureConfig;
        }

        public async Task<BlobContentInfo> Upload(FileStream fileStream)
        {
            BlobContainerClient client = new BlobContainerClient(config.BlobConnectionString, config.BlobContainer);
            BlobClient blob = client.GetBlobClient("");
            BlobContentInfo info = await blob.UploadAsync(fileStream);
            return info;
        }


    }
}
