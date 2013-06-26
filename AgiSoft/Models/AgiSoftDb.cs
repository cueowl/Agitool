/***********************************************************************************************
************************************************************************************************
* <author>Ralph Bohn & Harshad Deshmukh</author>                                               *
* <email>info@cueowl.com</email>                                                               *
* <date>2013-06-01</date>                                                                      *
* <file>AgiSoftDb.cs</file>                                                                    *
* <summary>not sure if really need this file as-is need change?</summary>                      *
************************************************************************************************      
************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgiSoft.Models {
    public class AgiSoftDb : DbContext {

        public AgiSoftDb()
            : base("name=DefaultConnection") {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}