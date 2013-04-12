namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Text;    
    using Data.Migrations;
    using Data.Model;   
    using WebMatrix.WebData;
 
    public class Configuration : DbMigrationsConfiguration<CommunityDaysDb>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CommunityDaysDb context)
         {
             ////  This method will be called after migrating to the latest version.

             ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
             ////  to avoid creating duplicate seed data. E.g.
             ////
             ////    context.People.AddOrUpdate(
             ////      p => p.FullName,
             ////      new Person { FullName = "Andrew Peters" },
             ////      new Person { FullName = "Brice Lambson" },
             ////      new Person { FullName = "Rowan Miller" }
             ////    );
             ////

             WebSecurity.InitializeDatabaseConnection("CommunityDays", "UserProfile", "UserId", "UserName", autoCreateTables: true);
         
             this.SetupStaticLookupData(context);
             this.SetupStaticCompanyData(context);
             this.SetupTestData(context);
         }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(CommunityDaysDb context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), 
                    ex); // Add the original exception as the innerException
            }
        }

        /// <summary>
        /// Create static lookup data, required not just for test
        /// </summary>
        /// <param name="context">The database context</param>
        private void SetupStaticLookupData(CommunityDaysDb context)
        {
            var newOpportunityStatuses = new List<Data.Model.OpportunityStatus>
            {
                new Data.Model.OpportunityStatus { OpportunityStatusId = 1, OpportunityStatusDescription = "Request received" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 2, OpportunityStatusDescription = "Request approved" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 3, OpportunityStatusDescription = "Request rejected" },                
                new Data.Model.OpportunityStatus { OpportunityStatusId = 4, OpportunityStatusDescription = "Project closed" }                
            };
            newOpportunityStatuses.ForEach(s => context.OpportunityStatus.AddOrUpdate(s));
            this.SaveChanges(context);

            var newEmployeeRole = new List<Data.Model.EmployeeRole>
            {
                new Data.Model.EmployeeRole { OpportunityRoleId = 1, OpportunityRoleDescription = "Volunteer" },
                new Data.Model.EmployeeRole { OpportunityRoleId = 2, OpportunityRoleDescription = "Project Leader" },
                new Data.Model.EmployeeRole { OpportunityRoleId = 3, OpportunityRoleDescription = "Champion" }
            };
            newEmployeeRole.ForEach(s => context.EmployeeRole.AddOrUpdate(s));
            this.SaveChanges(context);

            var newOrganisationType = new List<Data.Model.OrganisationType>
            {
                new Data.Model.OrganisationType { OrganisationTypeId = 1, OrganisationTypeName = "Charity" },
                new Data.Model.OrganisationType { OrganisationTypeId = 2, OrganisationTypeName = "NPO" },
                new Data.Model.OrganisationType { OrganisationTypeId = 3, OrganisationTypeName = "School" }
            };
            newOrganisationType.ForEach(s => context.OrganisationType.AddOrUpdate(s));
            this.SaveChanges(context);
        }

        /// <summary>
        /// Create static lookup data, required not just for test
        /// </summary>
        /// <param name="context">The database context</param>
        private void SetupStaticCompanyData(CommunityDaysDb context)
        {
            var newCountry = new List<Data.Model.Country>
            {
                new Data.Model.Country { CountryId = 1, CountryName = "England" },
                new Data.Model.Country { CountryId = 2, CountryName = "Scotland" },
                new Data.Model.Country { CountryId = 3, CountryName = "Wales" },
                new Data.Model.Country { CountryId = 4, CountryName = "Ireland" }
            };
            newCountry.ForEach(s => context.Country.AddOrUpdate(s));
            this.SaveChanges(context);

            var newLocation = new List<Data.Model.Location>
            {
                new Data.Model.Location { LocationId = 1, LocationName = "Aberdeen", CountryId = 2 },
                new Data.Model.Location { LocationId = 2, LocationName = "Aldershot", CountryId = 1 },
                new Data.Model.Location { LocationId = 3, LocationName = "Basingstoke", CountryId = 1 },
                new Data.Model.Location { LocationId = 4, LocationName = "Belfast", CountryId = 4 },
                new Data.Model.Location { LocationId = 5, LocationName = "Bristol", CountryId = 1 },
                new Data.Model.Location { LocationId = 6, LocationName = "Cardiff", CountryId = 3 },
                new Data.Model.Location { LocationId = 7, LocationName = "Cumbernauld", CountryId = 2 },
                new Data.Model.Location { LocationId = 8, LocationName = "Dublin", CountryId = 4 },
                new Data.Model.Location { LocationId = 9, LocationName = "Dundee", CountryId = 2 },
                new Data.Model.Location { LocationId = 10, LocationName = "Exeter", CountryId = 1 },
                new Data.Model.Location { LocationId = 11, LocationName = "Ferrybridge", CountryId = 1 },
                new Data.Model.Location { LocationId = 12, LocationName = "Fiddler's Ferry", CountryId = 1 },
                new Data.Model.Location { LocationId = 13, LocationName = "Glasgow", CountryId = 2 },
                new Data.Model.Location { LocationId = 14, LocationName = "Hedge End", CountryId = 1 },
                new Data.Model.Location { LocationId = 15, LocationName = "Inverness", CountryId = 2 },
                new Data.Model.Location { LocationId = 16, LocationName = "Isle of Wight", CountryId = 1 },
                new Data.Model.Location { LocationId = 17, LocationName = "Leeds", CountryId = 1 },
                new Data.Model.Location { LocationId = 18, LocationName = "London", CountryId = 1 },
                new Data.Model.Location { LocationId = 19, LocationName = "Lowestoft", CountryId = 1 },
                new Data.Model.Location { LocationId = 20, LocationName = "Melksham", CountryId = 1 },
                new Data.Model.Location { LocationId = 21, LocationName = "New Forest", CountryId = 1 },
                new Data.Model.Location { LocationId = 22, LocationName = "Newcastle", CountryId = 1 },
                new Data.Model.Location { LocationId = 23, LocationName = "Oxford", CountryId = 1 },
                new Data.Model.Location { LocationId = 24, LocationName = "Penner Road", CountryId = 1 },
                new Data.Model.Location { LocationId = 25, LocationName = "Perth", CountryId = 2 },
                new Data.Model.Location { LocationId = 26, LocationName = "Poole", CountryId = 1 },
                new Data.Model.Location { LocationId = 27, LocationName = "Portsmouth", CountryId = 1 },
                new Data.Model.Location { LocationId = 28, LocationName = "Reading", CountryId = 1 },
                new Data.Model.Location { LocationId = 29, LocationName = "Shetland", CountryId = 2 },
                new Data.Model.Location { LocationId = 30, LocationName = "Slough", CountryId = 1 },
                new Data.Model.Location { LocationId = 31, LocationName = "Southampton", CountryId = 1 },
                new Data.Model.Location { LocationId = 32, LocationName = "Taunton", CountryId = 1 },
                new Data.Model.Location { LocationId = 33, LocationName = "Thatcham", CountryId = 1 },
                new Data.Model.Location { LocationId = 34, LocationName = "Torquay", CountryId = 1 },
                new Data.Model.Location { LocationId = 35, LocationName = "Yeovil", CountryId = 1 }
            };
            newLocation.ForEach(s => context.Location.AddOrUpdate(s));
            this.SaveChanges(context);

            var newDirectorate = new List<Data.Model.Directorate>
            {
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "CHIEF EXECUTIVE'S CENTRES", Director = "Ian Marchant" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "NETWORKS", Director = "Mark Mathieson" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "REGULATION", Director = "Rob McDonald" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "CORPORATE AFFAIRS", Director = "Alan Young" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "RENEWABLES LCP", Director = "Jim Smith" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "GENERATION", Director = "Paul Smith" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "RETAIL", Director = "Will Morris" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "CONTRACTING", Director = "Kevin Greenhorn" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "ENERGY PORTFOLIO MANAGEMENT", Director = "David Franklin" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "FINANCE", Director = "Gregor Alexander" },
                new Data.Model.Directorate { DirectorateId = 1, DirectorateName = "GROUP SERVICES", Director = "Jim McPhillimy" }                
            };
            newDirectorate.ForEach(s => context.Directorate.AddOrUpdate(s));
            this.SaveChanges(context);

            var newDepartment = new List<Data.Model.Department>
             {
                new Data.Model.Department { DepartmentId = 1, DepartmentName = "CHIEF EXECUTIVE'S CENTRES", DirectorateId = 1 },
                new Data.Model.Department { DepartmentId = 2, DepartmentName = "NETWORKS", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 3, DepartmentName = "Power Distribution & SSEUS", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 4, DepartmentName = "Transmission", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 5, DepartmentName = "Utility Solutions", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 6, DepartmentName = "Telecoms", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 7, DepartmentName = "Lighting Services", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 8, DepartmentName = "Utility Solutions - Airtricity", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 9, DepartmentName = "Finance & Commercial", DirectorateId = 2 },
                new Data.Model.Department { DepartmentId = 10, DepartmentName = "REGULATION", DirectorateId = 3 },
                new Data.Model.Department { DepartmentId = 11, DepartmentName = "CORPORATE AFFAIRS", DirectorateId = 4 },
                new Data.Model.Department { DepartmentId = 12, DepartmentName = "RENEWABLES LCP", DirectorateId = 5 },                          
                new Data.Model.Department { DepartmentId = 13, DepartmentName = "GENERATION", DirectorateId = 6 },       
                new Data.Model.Department { DepartmentId = 14, DepartmentName = "Pipelines", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 15, DepartmentName = "Other", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 16, DepartmentName = "Asset Management", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 17, DepartmentName = "Hornsea", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 18, DepartmentName = "Renewable Ops", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 19, DepartmentName = "Thermal", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 20, DepartmentName = "Renewables Generation", DirectorateId = 6 },
                new Data.Model.Department { DepartmentId = 21, DepartmentName = "RETAIL", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 22, DepartmentName = "Energy Marketing", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 23, DepartmentName = "Business Sales Management", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 24, DepartmentName = "Domestic Sales", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 25, DepartmentName = "Energy Demand with CERT & CESP", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 26, DepartmentName = "Energy Service & Supply", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 27, DepartmentName = "Talk & Energy MGT EPCS & FITS", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 28, DepartmentName = "Customer Service", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 29, DepartmentName = "Metering", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 30, DepartmentName = "Retail", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 31, DepartmentName = "Smart Metering Projects", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 32, DepartmentName = "CSBUS - Business Customers", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 33, DepartmentName = "Renewables Supply", DirectorateId = 7 },
                new Data.Model.Department { DepartmentId = 34, DepartmentName = "CONTRACTING", DirectorateId = 8 },
                new Data.Model.Department { DepartmentId = 35, DepartmentName = "ENERGY PORTFOLIO MANAGEMENT", DirectorateId = 9 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "FINANCE", DirectorateId = 10 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Finance", DirectorateId = 10 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Renewables Finance", DirectorateId = 10 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "GROUP SERVICES", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Human Resources", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Health & Safety Services", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Corporate Infrastruture", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Procurement & Contracts", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "IT", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Large Capital Project Support", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Insurance", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Performance", DirectorateId = 11 },
                new Data.Model.Department { DepartmentId = 0, DepartmentName = "Forth Energy & 7CK", DirectorateId = 11 }
            };
            newDepartment.ForEach(s => context.Department.AddOrUpdate(s));
            this.SaveChanges(context);
        }

        /// <summary>
        /// Create test data
        /// </summary>
        /// <param name="context">The database context</param>
        private void SetupTestData(CommunityDaysDb context)
        {
            var newUserProfiles = new List<Data.Model.UserProfile>
            {
                new Data.Model.UserProfile { UserId = 1, UserName = "one" },
                new Data.Model.UserProfile { UserId = 2, UserName = "two" },
                new Data.Model.UserProfile { UserId = 3, UserName = "three" },
                new Data.Model.UserProfile { UserId = 4, UserName = "four" },
                new Data.Model.UserProfile { UserId = 5, UserName = "five" },
            };

            newUserProfiles.ForEach(s => context.UserProfiles.AddOrUpdate(s));

            var newCompanies = new List<Data.Model.Company>
            {
               new Data.Model.Company { CompanyId = 1, OrganisationTypeId = 2, CompanyName = "BREADALBANE CANOE CLUB", CompanyApprovedFlag = true, CompanyContactName = "Mary Shoe", CompanyContactEmail = "Mary@canoe.com", CompanyContactPhone = "02392 123123", CompanyAddress = "ABERFELDY", CompanyPostcode = "BD23 1PT", CharityNumber = "0", CompanyDetails = "Breadalbane Canoe Club is an active and inclusive club promoting both competitive and recreational paddling. We encourage participation at all levels and work to protect, improve and promote responsible paddle sports." },
                new Data.Model.Company { CompanyId = 2, OrganisationTypeId = 1, CompanyName = "RNLI", CompanyApprovedFlag = true, CompanyContactName = "Brian Boat", CompanyContactEmail = "Brian@RNLI.com", CompanyContactPhone = "02392 998877", CompanyAddress = "London", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "The RNLI is the charity that saves lives at sea" },            
                new Data.Model.Company { CompanyId = 3, OrganisationTypeId = 3, CompanyName = "St Stephens Primary School, Blairgowrie", CompanyApprovedFlag = true, CompanyContactName = "Sarah School", CompanyContactEmail = "Sarah@school.com", CompanyContactPhone = "02392 334455", CompanyAddress = "Coupar Angus", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "Fund-raising for school projects" },            
                new Data.Model.Company { CompanyId = 4, OrganisationTypeId = 2, CompanyName = "Whizz Kidz", CompanyApprovedFlag = true, CompanyContactName = "Keith Kidd", CompanyContactEmail = "Keith@whizzkids.com", CompanyContactPhone = "02392 889900", CompanyAddress = "London", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "Whizz-Kidz provides disabled children with the essential wheelchairs and other mobility equipment they need to lead fun and active childhoods." },      
                new Data.Model.Company { CompanyId = 5, OrganisationTypeId = 1, CompanyName = "Breast Cancer Care", CompanyApprovedFlag = true, CompanyContactName = "Brenda Boom", CompanyContactEmail = "Brenda@bcc.com", CompanyContactPhone = "02392 223355", CompanyAddress = "Scotland", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "http://www.breastcancercare.org.uk/ Follow Breast Cancer Care Scotland on Twitter @BccareScot" },                              
                /* new Data.Model.Company { CompanyId = 1, CompanyName = "BREADALBANE CANOE CLUB", CompanyApprovedFlag = true, CompanyContactName = "Mary Shoe", CompanyContactEmail = "Mary@canoe.com", CompanyContactPhone = "02392 123123", CompanyAddress = "ABERFELDY", CompanyPostcode = "BD23 1PT", CharityNumber = "0", CompanyDetails = "Breadalbane Canoe Club is an active and inclusive club promoting both competitive and recreational paddling. We encourage participation at all levels and work to protect, improve and promote responsible paddle sports." },
                new Data.Model.Company { CompanyId = 2, CompanyName = "RNLI", CompanyApprovedFlag = true, CompanyContactName = "Brian Boat", CompanyContactEmail = "Brian@RNLI.com", CompanyContactPhone = "02392 998877", CompanyAddress = "London", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "The RNLI is the charity that saves lives at sea" },            
                new Data.Model.Company { CompanyId = 3, CompanyName = "St Stephens Primary School, Blairgowrie", CompanyApprovedFlag = true, CompanyContactName = "Sarah School", CompanyContactEmail = "Sarah@school.com", CompanyContactPhone = "02392 334455", CompanyAddress = "Coupar Angus", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "Fund-raising for school projects" },            
                new Data.Model.Company { CompanyId = 4, CompanyName = "Whizz Kidz", CompanyApprovedFlag = true, CompanyContactName = "Keith Kidd", CompanyContactEmail = "Keith@whizzkids.com", CompanyContactPhone = "02392 889900", CompanyAddress = "London", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "Whizz-Kidz provides disabled children with the essential wheelchairs and other mobility equipment they need to lead fun and active childhoods." },      
                new Data.Model.Company { CompanyId = 5, CompanyName = "Breast Cancer Care", CompanyApprovedFlag = true, CompanyContactName = "Brenda Boom", CompanyContactEmail = "Brenda@bcc.com", CompanyContactPhone = "02392 223355", CompanyAddress = "Scotland", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "http://www.breastcancercare.org.uk/ Follow Breast Cancer Care Scotland on Twitter @BccareScot" },*/
            };

            newCompanies.ForEach(s => context.Company.AddOrUpdate(s));

            var newCompanyUserProfile = new List<Data.Model.CompanyUserProfileMap>
            {
                new Data.Model.CompanyUserProfileMap { CompanyId = 1, UserId = 1 },
                new Data.Model.CompanyUserProfileMap { CompanyId = 2, UserId = 2 },            
                new Data.Model.CompanyUserProfileMap { CompanyId = 3, UserId = 3 },            
                new Data.Model.CompanyUserProfileMap { CompanyId = 4, UserId = 4 },      
                new Data.Model.CompanyUserProfileMap { CompanyId = 5, UserId = 5 },              
            };

            newCompanyUserProfile.ForEach(s => context.CompanyUserProfileMap.AddOrUpdate(s));

            var today = System.DateTime.Now;
            var newOpportunities = new List<Data.Model.Opportunity>
            {
                new Data.Model.Opportunity { OpportunityId = 1, OpportunityStatusId = 1, CompanyId = 1, MaxNumberofVolunteers = 1, OpportunityLocationName = "ABERFELDY", OpportunityPostcode = "BD23 1PT", OpportunityTitle = "BREADALBANE CANOE CLUB EVENT", OpportunityDescription = "ASSIST AS HELPERS AT OUR SLALOM KAYAKING COMPETITION IN ABERFELDY 1ST & 2ND OF APRIL - CAR PARKING, CATERING TENT, HELPING CHILDREN GET IN AND OUT OF BOATS, HELP CARRY BOATS, ETC. OUR OTHER COMPETITION AT GRANDTULLY ON THE 30TH AND 31ST OF MARCH WOULD BENEFIT FROM ANY HELPERS AS WELL. IT IS A PREMIER EVENT AND SOME PREVIOUS OLYMPIC MEDALISTS COMPETE THERE. THE ADVENTURE SHOW ALSO FILMS THE EVENT.", OpportunityDate = today.AddDays(5).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 2, OpportunityStatusId = 1, CompanyId = 2, MaxNumberofVolunteers = 10, OpportunityLocationName = "London", OpportunityPostcode = string.Empty, OpportunityTitle = "London Lifeboat Day", OpportunityDescription = "London Lifeboat Day is coming up on 30th April and we are looking for volunteers to collect donations at London stations.", OpportunityDate = today.AddDays(10).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 3, OpportunityStatusId = 2, CompanyId = 3, MaxNumberofVolunteers = 5, OpportunityLocationName = "Blairgowrie", OpportunityPostcode = string.Empty, OpportunityTitle = "St Stephens Primary School, Blairgowriee", OpportunityDescription = "The School have the use of a charity shop in Coupar Angus from Sunday 21st April until Saturday 27th April and are looking for volunteers who could help staff the shop from 10-4pm", OpportunityDate = today.AddDays(15).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 4, OpportunityStatusId = 2, CompanyId = 4, MaxNumberofVolunteers = 2, OpportunityLocationName = "London", OpportunityPostcode = string.Empty, OpportunityTitle = "Whizz Kidz", OpportunityDescription = "Whizz Kidz are looking for help at the following events: London Marathon 21st April (stewarding) and Sitting Volleyball Tournament, Reebok Centre, Canary Wharf 28th Feb (helpers).", OpportunityDate = today.AddDays(20).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 5, OpportunityStatusId = 2, CompanyId = 5, MaxNumberofVolunteers = 25, MinNumberofVolunteers = 5, OpportunityLocationName = "Scotland", OpportunityPostcode = string.Empty, OpportunityTitle = "Breast Cancer Care - Big Pink Bucket Collection", OpportunityDescription = "We are looking for volunteers all over Scotland for the week commencing 4th who would be willing to either organise their own collections in their area or be part of a collection organised by BCC. Dates & Locations available at: www.breastcancercare.org.uk/bigpinkbucketcollection", OpportunityDate = today.AddDays(25).ToShortDateString(), OpportunityCreatedDate = today }            
            };       
              
            newOpportunities.ForEach(s => context.Opportunity.AddOrUpdate(s));
            //// context.SaveChanges();
            this.SaveChanges(context);
         }
    }
}