/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>UserProfile.cs</file>                                                                  *
* <summary>Class-Model identifying "User" table and the custom tables added</summary>          *
* NOTE: This MUST match the table for Users                                                    * 
************************************************************************************************      
************************************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgiSoft.Models {

    [Table("Users")]
    public class UserProfile {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Mobile { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        
        public bool IsLocked { get; set; }
    }

}