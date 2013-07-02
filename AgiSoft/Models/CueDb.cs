/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>CueDb.cs</file>                                                                        *
* <summary>Model classes for CueOwl client Entity Classes to Db</summary>                      *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiSoft.Models {

    public class CueDb : DbContext {
        public CueDb() : base("name=CueConnect") {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CodeSet> CodeSets { get; set; }
        public DbSet<CodeSetType> CodeSetTypes { get; set; }
        public DbSet<PasswordHistory> PasswordHistories { get; set; }
        public DbSet<PasswordQuestions> PasswordQuestions { get; set; }
        public DbSet<PassQuesAnswers> PassQuesAnswers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Registrations> Registrations { get; set; }
        public DbSet<ClientProdReg> ClientProdRegs { get; set; }
    }

    public class Client {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        
        [Required]
        public string Company { get; set; }

        [Required]
        [Display(Name="Contact First Name: ")]
        public string ContactFName { get; set; }

        [Required]
        [Display(Name = "Contact Last Name: ")]
        public string ContactLName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Company size: ")]
        public int CompanySize { get; set; }

        public DateTime JoinDate { get; set; }
    }

    public class Products {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProdId { get; set; }
        public string ProdName { get; set; }
    }

    public class Registrations {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegId { get; set; }
        public string RegCode { get; set; }
        public DateTime RegDate { get; set; }
    }

    public class ClientProdReg {
        [Key]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [Key]
        [ForeignKey("Products")]
        public int ProdId { get; set; }
        [Key]
        [ForeignKey("Registrations")]
        public int RegId { get; set; }
    }
}