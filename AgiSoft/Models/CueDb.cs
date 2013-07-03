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
        public Client() {
            this.ClientProdRegs = new List<ClientProdReg>();
            this.Users = new List<User>();
        }

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
        public int? CompSize { get; set; }

        public DateTime JoinDate { get; set; }

        public virtual ICollection<ClientProdReg> ClientProdRegs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

    public class Products {
        public Products() {
            this.ClientProdRegs = new List<ClientProdReg>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public virtual ICollection<ClientProdReg> ClientProdRegs { get; set; }
    }

    public class Registrations {
        public Registrations() {
            this.ClientProdRegs = new List<ClientProdReg>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegId { get; set; }
        public string RegCode { get; set; }
        public DateTime RegDate { get; set; }
        public virtual ICollection<ClientProdReg> ClientProdRegs { get; set; }
    }

    public class ClientProdReg {
        [Key, ForeignKey("Client")]
        [Column(Order=1)]
        public int ClientId { get; set; }

        [Key, ForeignKey("Products")]
        [Column(Order = 2)]
        public int ProdId { get; set; }

        [Key, ForeignKey("Registrations")]
        [Column(Order = 3)]
        public int RegId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Products Products { get; set; }
        public virtual Registrations Registrations { get; set; }
    }
}