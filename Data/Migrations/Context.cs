namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Model;  

    /// <summary>
    /// Setting the base avoids having the full namespace prefix for the database name
    /// </summary>
    public class CommunityDaysDb : DbContext
    {
        public CommunityDaysDb()
                : base("CommunityDays")
        {
        }

        //// The <> param is the model object and Opportunity is the name of the table to create in the database
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<CompanyUserProfileMap> CompanyUserProfileMap { get; set; }

        public DbSet<Opportunity> Opportunity { get; set; }

        public DbSet<OpportunityEmployeeMap> OpportunityEmployeeMap { get; set; }

        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Sets up Lookup data
        /// </summary>
        /// <param name="modelBuilder"></param>
        public DbSet<OpportunityStatus> OpportunityStatus { get; set; }

        public DbSet<EmployeeRole> EmployeeRole { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Directorate> Directorate { get; set; }

        public DbSet<Department> Department { get; set; }

        //    public DbSet<Champion> Champion { get; set; } todo

        public DbSet<OrganisationType> OrganisationType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }    
    }
}
