using System.IO;

namespace PortalApp
{
    public class Fluent
    {
        public string conStr = "";
        //FluentBlobTransfer fluent = new FluentBlobTransfer("sdd");

        //FluentBlobTransfer flue = new 

        public void TestFixture()
        {
            //FluentBlobTransfer flue;
            //FluentBlobTransfer.Connect("").

            FluentBlobTransfer
                .Connect("storageAccountConnectionString")
                .OnBlob("blobName")
                //.Upload("")
                .Download("fileName")
                .ToFile(@"D:\Azure\Downloads\");

        }
    }


    public interface IAzureBlob
    {
        IAzureAction OnBlob(string blobBlockPath);
    }

    public interface IAzureAction
    {
        IAzureWrite Download(string fileName);
        IAzureRead Upload(string fileName);
    }

    public interface IAzureWrite
    {
        void ToFile(string filePath);
        void ToStream(Stream stream);
    }

    public interface IAzureRead
    {
        void FromFile(string filePath);
        void FromStream(Stream stream);
    }

    public sealed class FluentBlobTransfer : IAzureBlob, IAzureAction, IAzureWrite, IAzureRead
    {
        private readonly string connectionString;
        private string blobBlockPath;
        private string fileName;

        private FluentBlobTransfer(string connectionString) => this.connectionString = connectionString;

        public static IAzureBlob Connect(string connectionString) => new FluentBlobTransfer(connectionString);

        public IAzureAction OnBlob(string blobBlockPath)
        {
            this.blobBlockPath = blobBlockPath;

            return this;
        }

        public IAzureWrite Download(string fileName)
        {
            this.fileName = fileName;

            return this;
        }

        public IAzureRead Upload(string fileName)
        {
            this.fileName = fileName;

            return this;
        }

        public void ToFile(string filePath)
        {
            // Code to download from Azure Blob Storage to file
        }

        public void ToStream(Stream stream)
        {
            // Code to download from Azure Blob Storage to stream
        }

        public void FromFile(string filePath)
        {
            // Code to upload from file to Azure Blob Storage
        }

        public void FromStream(Stream stream)
        {
            // Code to upload from stream to Azure Blob Storage
        }
    }
}