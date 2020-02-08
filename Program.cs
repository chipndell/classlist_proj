using FinalProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;                                                                                       // for the kyword like FtpWebRequest, NetworkCredential, WebRequest
using System.Text;

namespace FinslProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "ftp://waws-prod-dm1-127.ftp.azurewebsites.windows.net/bdat1001-10824";
            string directories = GetDirectories.GetDirectory(url);
            
            List<string> studentDirectories = directories.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();      //\r stands for carriage return and \n for new line feed, ToList creates a list. 
            List<Student> students = new List<Student>();

            
            foreach (var studentDirectory in studentDirectories)
            {
                string[] studentsInfo = studentDirectory.Split(" ", StringSplitOptions.None);
                Student str_student1 = new Student();
                str_student1.StudentId = studentsInfo[0];
                str_student1.FirstName = studentsInfo[1];
                str_student1.LastName = studentsInfo[2];
                Console.WriteLine($"{studentsInfo[0]}  { studentsInfo[1]}  { studentsInfo[2]}");        //to print the StudentId, FirstName and LastName from String Array named "studentsInfo"
                //students.Add(str_student);
                

                //Block below creates the JSON file at specified address on line 36
                //JSON Data per Student is Correct. PROBLEM = How to append the data??
                string filepath = $"{studentsInfo[0]}%20{ studentsInfo[1]}%20{ studentsInfo[2]}/info.csv";

                string username = @"bdat100119f\bdat1001";
                string password = "bdat1001";

                WebClient request = new WebClient();
                //string url = "ftp://waws-prod-dm1-127.ftp.azurewebsites.windows.net/bdat1001-10824/";
                request.Credentials = new NetworkCredential(username, password);

                try
                {
                    byte[] newFileData = request.DownloadData(url + filepath);
                    string fileString = System.Text.Encoding.UTF8.GetString(newFileData);

                    
                    Student info_student = new Student();
                    //string[] str_student = new string[];
                    List<string> line_str_student = fileString.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
                    string infoData = line_str_student[1];
                    List<string> str_student = fileString.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

                    info_student.StudentId = str_student[0];
                    info_student.FirstName = str_student[1];
                    info_student.LastName = str_student[2];
                    info_student.Email = str_student[3];
                    info_student.DateOfBirth = str_student[4];
                    info_student.Title = str_student[5];
                    info_student.PersonalWebsite = str_student[6];
                    info_student.FacebookUrl = str_student[7];
                    info_student.InstagramUrl = str_student[8];
                    info_student.TwitterUrl = str_student[9];
                    info_student.LinkedInUrl = str_student[10];
                    info_student.Description = str_student[11];
                    if (info_student.StudentId == "200445936")
                    {
                        info_student.IsME = true;
                    }
                    else
                    {
                        info_student.IsME = false;
                    }
                    //Console.WriteLine($"{info_student.Description}  {info_student.Email}  {info_student.FacebookUrl}  {info_student.DateOfBirth}");
                    students.Add(info_student);
                }
                catch
                {
                    //Console.WriteLine(e.Message);
                    // Do something such as log error, but this is based on OP's original code
                    // so for now we do nothing.
                    throw;
                }

                //Read_File(filepath);

            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(students);
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Manan\Desktop\student_info.json"))
            {
                sw.Write(json);
            }
        }

        public static void Read_File(string address)
        {
            
        }

    }
}