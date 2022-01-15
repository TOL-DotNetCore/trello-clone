using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using trello_clone.web.Data;
using trello_clone.web.Entities;
using trello_clone.web.Services.IServices;

namespace trello_clone.web.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ApplicationUser> GetUSer(string id)
        {
            var user = await _db.ApplicationUsers.FindAsync(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task UploadAvatar(IFormFile file, string userId)
        {
            const string AwsAccessKey = "AKIATYC5BMXR5PKO6AGO";
            const string AwsSecretAccessKey = "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";
            string bucketName = "chello";
            using (var client = new AmazonS3Client(AwsAccessKey, AwsSecretAccessKey, RegionEndpoint.APSoutheast1))
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = file.FileName,
                        BucketName = bucketName,
                        CannedACL = S3CannedACL.BucketOwnerFullControl
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    await fileTransferUtility.UploadAsync(uploadRequest);
                    var avatarUrl = string.Format("https://{0}.s3.ap-southeast-1.amazonaws.com/{1}", bucketName, file.FileName);

                    var user = await _db.ApplicationUsers.FindAsync(userId);
                    user.Avatar = avatarUrl;
                    _db.ApplicationUsers.Update(user);
                    _db.SaveChanges();
                }
            }

        }
    }
}
