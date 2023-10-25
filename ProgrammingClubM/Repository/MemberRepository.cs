using ProgrammingClubM.Data;
using ProgrammingClubM.Models.DBObjects;

namespace ProgrammingClubM.Repository
{
    public class MemberRepository
    {
        private ApplicationDbContext dbContext;
        public MemberRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public MemberRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Member> GetAllMembers()
        {
            List<Member> memberList = new List<Member>();

            foreach (Member dbMember in this.dbContext.Members)
            {
                memberList.Add(this.MapDbObjectToModel(dbMember));
            }

            return memberList;
        }

        public Member GetMemberById (Guid id)
        {
            return MapDbObjectToModel(dbContext.Members.FirstOrDefault(x => x.Idmember == id));
        }

        public void InsertMember(Member member)
        {
            member.Idmember = Guid.NewGuid();

            dbContext.Members.Add(MapModelToDbObjec(member));
            dbContext.SaveChanges();
        }

        private Member MapDbObjectToModel(Member dbMember)
        {
            Member member = new Member();

            if (dbMember !=  null)
            {
                member.Idmember = dbMember.Idmember;
                member.Name = dbMember.Name;
                member.Title = dbMember.Title;
                member.Position = dbMember.Position;
                member.Description = dbMember.Description;
                member.Resume = dbMember.Resume;
            }

            return member;
        }

        private Member MapModelToDbObjec(Member model)
        {
            Member member = new Member();

            if (model != null)
            {
                member.Idmember = model.Idmember;
                member.Name = model.Name;
                member.Title = model.Title;
                member.Position = model.Position;
                member.Description = model.Description;
                member.Resume = model.Resume;
            }

            return member;
        }
    }
}
