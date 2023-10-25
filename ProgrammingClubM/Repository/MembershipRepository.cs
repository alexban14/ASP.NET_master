using ProgrammingClubM.Data;
using ProgrammingClubM.Models.DBObjects;

namespace ProgrammingClubM.Repository
{
    public class MembershipRepository
    {
        private ApplicationDbContext dbContext;

        public MembershipRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public MembershipRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Membership> GetAMllMemberships()
        {
            List<Membership> list = new List<Membership>();

            foreach(Membership dbMembership in dbContext.Memberships)
            {
                list.Add(MapDbObjectToModel(dbMembership));
            }

            return list;
        }

        public Membership GetMembershipById(Guid id)
        {
            return MapDbObjectToModel(dbContext.Memberships.FirstOrDefault(x => x.Idmembership == id));
        }

        public void InsertMembership(Membership membership)
        {
            membership.Idmembership = Guid.NewGuid();

            dbContext.Memberships.Add(MapModelToDbObject(membership));
            dbContext.SaveChanges();
        }

        private Membership MapDbObjectToModel(Membership dbMembership)
        {
            Membership membership = new Membership();

            if (dbMembership != null)
            {
                membership.Idmembership = dbMembership.Idmembership;
                membership.Idmember = dbMembership.Idmember;
                membership.Idmembership = dbMembership.Idmembership;
                membership.StartDate = dbMembership.StartDate;
                membership.EndDate = dbMembership.EndDate;
                membership.Level = dbMembership.Level;
            }

            return membership;
        }

        private Membership MapModelToDbObject(Membership model)
        {
            Membership membership = new Membership();

            if (model != null)
            {
                membership.Idmembership = model.Idmembership;
                membership.Idmember = model.Idmember;
                membership.IdmembershipType = model.IdmembershipType;
                membership.StartDate = model.StartDate; 
                membership.EndDate = model.EndDate;
                membership.Level = model.Level;
            }

            return membership;
        }
    }
}
