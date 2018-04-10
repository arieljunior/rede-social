using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageService
{
    public class BlobService
    {
        private BlobRepository BlobDb { get; }
        public BlobService()
        {
            BlobDb = new BlobRepository();
        }
        public string UploadImage(String container, String fileName, System.IO.Stream inputStream, String contentType)
        {
            return BlobDb.UploadFile(container, fileName, inputStream, contentType);
        }
    }
}
