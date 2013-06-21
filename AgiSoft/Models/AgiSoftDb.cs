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