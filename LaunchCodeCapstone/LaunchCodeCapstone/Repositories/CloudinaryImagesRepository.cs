﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace LaunchCodeCapstone.Repositories
{
    public class CloudinaryImagesRepository : IImageRepository
    {
        private readonly IConfiguration configuration;
        private readonly Account account;

        public CloudinaryImagesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            //initializing the cloudinary account
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["CloudName"]
                );
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            //throw new NotImplementedException();

            //creating a new client
            var client = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };
            var uploadResult = await client.UploadAsync(uploadParams);

            //check if the upload was successful
            if(uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();

            }
            //if unsuccessful return null back
            return null;
        }
    }
}
