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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiSoft.Models {

    /* This is table for AgiDb  */
    [Table("UserProfile")]
    public class UserProfile {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }
        
        public bool IsLocked { get; set; }

        public bool IsActiveUser { get; set; }

        public int SettingId { get; set; }

        public DateTime ChangeDate { get; set; }
    }

    /* This is table for CueDb  */
    [Table("User")]
    public class User {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }

    public class webpages_Membership {
        [Key,ForeignKey("UserProfile")]
        public int UserId { get; set; }

        public DateTime CreateDate { get; set; }
        public string ConfirmationToken { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; }
        public DateTime PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime PasswordVerificationTokenExpirationDate { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }

    public class webpages_Roles {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }

    public class webpages_UsersInRoles {
        [Key, ForeignKey("Roles")]
        [Column(Order=1)]
        public int RoleId { get; set; }

        [Key, ForeignKey("UserProfile")]
        [Column(Order = 2)]
        public int UserId { get; set; }

        public virtual webpages_Roles Roles { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }

    public class CodeSet {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CodeSetId { get; set; }

        public string CodeSetCode { get; set; }

        public string CodeSetDesc { get; set; }

        [ForeignKey("CodeSetType")]
        public int CodeSetTypeId { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual CodeSetType CodeSetType { get; set; }
    }

    public class CodeSetType {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int CodeSetTypeId { get; set; }

        public string CodeSetTypeCode { get; set; }

        public string CodeSetTypeDesc { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }

    public class PassQuesAnswers {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PassAnswerId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("PasswordQuestions")]
        public int PassQuesId { get; set; }

        [Display(Name = "Secret Answer")]
        public string Answer { get; set; }

        public bool IsValid { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public virtual PasswordQuestions PasswordQuestions { get; set; }
    }

    public class PasswordHistory {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PasswdHistId { get; set; }

        public int UserId { get; set; }

        public string Password { get; set; }

        public DateTime Date { get; set; }

    }

    public class PasswordQuestions {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PassQuestionId { get; set; }

        [Display(Name = "Secret Question")]
        public string PassQuestion { get; set; }

        public bool IsActive { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ChangeDate { get; set; }
    }

    
}