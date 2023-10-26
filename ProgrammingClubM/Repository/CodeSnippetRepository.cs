using ProgrammingClubM.Data;
using ProgrammingClubM.Models.DBObjects;

namespace ProgrammingClubM.Repository
{
    public class CodeSnippetRepository
    {
        private ApplicationDbContext dbContext;

        public CodeSnippetRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public CodeSnippetRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  List<CodeSnippet> GetAllCodeSnippets()
        {
            List<CodeSnippet> codeSnippetList = new List<CodeSnippet>();

            foreach (CodeSnippet dbCodeSnippet in this.dbContext.CodeSnippets)
            {
                codeSnippetList.Add(MapDbObjectToModel(dbCodeSnippet));
            }

            return codeSnippetList;
        }

        public CodeSnippet GetCodeSnippetById(Guid id)
        {
            return MapDbObjectToModel(dbContext.CodeSnippets.FirstOrDefault(x => x.IdcodeSnippet == id));
        }

        public void InsertCodeSnippet(CodeSnippet codeSnippet)
        {
            codeSnippet.IdcodeSnippet = Guid.NewGuid();

            dbContext.CodeSnippets.Add(MapModelToDbObject(codeSnippet));
            dbContext.SaveChanges();
        }

        private CodeSnippet MapDbObjectToModel(CodeSnippet dbCodeSnippet)
        {
            CodeSnippet codeSnippet = new CodeSnippet();

            if (dbCodeSnippet != null)
            {
                codeSnippet.IdcodeSnippet = dbCodeSnippet.IdcodeSnippet;
                codeSnippet.Title = dbCodeSnippet.Title;
                codeSnippet.ContentCode = dbCodeSnippet.ContentCode;
                codeSnippet.Idmember = dbCodeSnippet.Idmember;
                codeSnippet.Revision = dbCodeSnippet.Revision;
                codeSnippet.IdsnippetPreviousVersion = dbCodeSnippet.IdsnippetPreviousVersion;  
                codeSnippet.DateTimeAdded = dbCodeSnippet.DateTimeAdded;
                codeSnippet.IsPublished = dbCodeSnippet.IsPublished;
                codeSnippet.IdmemberNavigation = dbCodeSnippet.IdmemberNavigation;
                codeSnippet.IdsnippetPreviousVersionNavigation = dbCodeSnippet.IdsnippetPreviousVersionNavigation;
                codeSnippet.InverseIdsnippetPreviousVersionNavigation = dbCodeSnippet.InverseIdsnippetPreviousVersionNavigation;

            }

            return codeSnippet;
        }

        private CodeSnippet MapModelToDbObject(CodeSnippet model)
        {
            CodeSnippet codeSnippet = new CodeSnippet();

            if (model != null)
            {
                codeSnippet.IdcodeSnippet = model.IdcodeSnippet;
                codeSnippet.Title = model.Title;
                codeSnippet.ContentCode = model.ContentCode;
                codeSnippet.Idmember = model.Idmember;
                codeSnippet.Revision = model.Revision;
                codeSnippet.IdsnippetPreviousVersion = model.IdsnippetPreviousVersion;  
                codeSnippet.DateTimeAdded = model.DateTimeAdded;
                codeSnippet.IsPublished = model.IsPublished;
                codeSnippet.IdmemberNavigation = model.IdmemberNavigation;
                codeSnippet.IdsnippetPreviousVersionNavigation = model.IdsnippetPreviousVersionNavigation;
                codeSnippet.InverseIdsnippetPreviousVersionNavigation = model.InverseIdsnippetPreviousVersionNavigation;
            }

            return codeSnippet;
        }
    }
}
