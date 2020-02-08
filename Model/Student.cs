using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Model
{
    class Student
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Title { get; set; }
        public string PersonalWebsite { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }        
        public string ImagePathe { get; set; }
        public string Description { get; set; }
        public bool IsME { get; set; }
        public string ImageURL { get; set; }
        public override string ToString()
        {
            return ($"{StudentId} {FirstName} {LastName}");
            //return base.ToString();
        }
        public string ToCSV()
        {
            return $"{StudentId},{FirstName},{LastName},{Email},{DateOfBirth},{Title},{PersonalWebsite},{FacebookUrl},{InstagramUrl},{TwitterUrl},{LinkedInUrl},{ImagePathe},{Description},{ImageURL}";
        }
    }
}