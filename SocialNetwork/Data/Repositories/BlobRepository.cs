using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BlobRepository
    {
        public CloudStorageAccount StorageAccount { get; private set; }
        public BlobRepository()
        {
            StorageAccount = CloudStorageAccount.Parse(Data.Properties.Settings.Default.BlobConnectionString);
        }

        public String UploadFile(String container, String fileName, System.IO.Stream inputStream, String contentType)
        {
            //Classe que faz acesso ao Azure Storage Blob
            CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();

            //Classe que faz referência a um Container
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);

            //Cria um container novo se não existe
            blobContainer.CreateIfNotExists();

            //Referência a uma imagem
            CloudBlockBlob cloudBlockblob = blobContainer.GetBlockBlobReference(fileName);
            cloudBlockblob.Properties.ContentType = contentType;

            //Upload não assíncrono
            cloudBlockblob.UploadFromStream(inputStream);

            //Blob URL
            return cloudBlockblob.Uri.ToString();
        }
    }
}
