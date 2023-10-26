using ProgrammingClubM.Data;
using ProgrammingClubM.Models.DBObjects;

namespace ProgrammingClubM.Repository
{
    public class MembershipTypeRepository
    {
        private ApplicationDbContext dbContext;

        public MembershipTypeRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public MembershipTypeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MembershipType> GetAllMembershipTypes()
        {
            List<MembershipType> membershipTypeList = new List<MembershipType>();

            foreach(MembershipType dbMembershipType in this.dbContext.MembershipTypes)
            {
                membershipTypeList.Add(MapDbObjectToModel(dbMembershipType));
            }

            return membershipTypeList;
        }

        public MembershipType GetMembershipTypeById(Guid id)
        {
            return MapDbObjectToModel(dbContext.MembershipTypes.FirstOrDefault(x => x.IdmembershipType == id));
        }

        public void InsertMembershipType(MembershipType membershipType)
        {
            membershipType.IdmembershipType = Guid.NewGuid();   

            dbContext.MembershipTypes.Add(MapModelToDbObject(membershipType));
            dbContext.SaveChanges();
        } 

        private MembershipType MapDbObjectToModel(MembershipType dbMembershipType)
        {
            MembershipType membershipType = new MembershipType();

            if (dbMembershipType != null)
            {
                membershipType.IdmembershipType = dbMembershipType.IdmembershipType;
                membershipType.Name = dbMembershipType.Name;
                membershipType.Description = dbMembershipType.Description;
                membershipType.SubscriptionLengthInMonths = dbMembershipType.SubscriptionLengthInMonths;
            }

            return membershipType;
        }

        private MembershipType MapModelToDbObject(MembershipType model)
        {
            MembershipType membershipType = new MembershipType();

            if (model != null)
            {
                membershipType.IdmembershipType = model.IdmembershipType;
                membershipType.Name = model.Name;
                membershipType.Description = model.Description;
                membershipType.SubscriptionLengthInMonths = model.SubscriptionLengthInMonths;
            }

            return membershipType;
        }
    }
}
