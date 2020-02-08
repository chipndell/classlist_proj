using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FinalProject.Model
{
    class Upload_Files
    {
        //Uploads the JSON File to the specified Directory
        //its working code, addressed will be updared and method will be called, once desired JSON is produced!
        static string username = @"bdat100119f/bdat1001/site/wwwroot/Content";
        static string password = "bdat1001";
       
        string url = "https://bdat100119f.azurewebsites.net/Students/Details/200445936";
        string uploadfile = @"C:\Users\Manan\Desktop\students.json";

        static string UploadFile(string url, string uploadfile)
        {
            
            string output;

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);

            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);

            // Copy the contents of the file to the request stream.
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader(uploadfile))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            //Get the length or size of the file
            request.ContentLength = fileContents.Length;

            //Write the file to the stream on the server
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            //Send the request
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                output = $"Upload File Complete, status {response.StatusDescription}";
            }
            return (output);
        }
    }
}