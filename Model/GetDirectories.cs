using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FinalProject.Model
{    
    class GetDirectories
    {
        static string username = @"bdat100119f\bdat1001";
        static string password = "bdat1001";

        //Method below extracts the list of directory and produces the path to read info.csv in 'Program' class
        public static string GetDirectory(string url)
        {
            string output;
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            //request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    output = reader.ReadToEnd();
                }
            }
            Console.WriteLine($"Directory List Complete with status code: {response.StatusDescription}");
            return (output);
        }

        //Concept of Block below is taken from, Reference: https://stackoverflow.com/questions/6098694/read-file-from-ftp-to-memory-in-c-sharp
        //Block below read the file 'info.csv' located at specified FTP address and stores the data in list of Student with approprite data stored as List
            }
}
