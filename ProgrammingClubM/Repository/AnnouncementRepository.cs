using ProgrammingClubM.Data;
using ProgrammingClubM.Models.DBObjects;

namespace ProgrammingClubM.Repository
{
    public class AnnouncementRepository
    {
        private ApplicationDbContext dbContext;
        public AnnouncementRepository() 
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AnnouncementRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcementList = new List<Announcement>();

            foreach (Announcement dbAnnouncement in dbContext.Announcements)
            {
                announcementList.Add(MapDbObjectToModel(dbAnnouncement));
            }

            return announcementList;
        }

        public Announcement GetAnnouncementById(Guid id)
        {
            return MapDbObjectToModel(dbContext.Announcements.FirstOrDefault(x => x.Idannouncement == id));
        }

        public List<Announcement> GetAnnouncementsByEffectiveDates(DateTime validFrom, DateTime validTo)
        {
            List<Announcement> announcemmentList = new List<Announcement>();

            foreach (Announcement dbAnnouncement in  dbContext.Announcements.Where(x => x.ValidFrom >= validFrom && x.ValidTo <= validTo)) {
                announcemmentList.Add(MapDbObjectToModel(dbAnnouncement));
            }

            return announcemmentList;
        }

        public List<Announcement> GetAnnouncementsByEventDate(DateTime eventDate)
        {
            List<Announcement> announcemmentList = new List<Announcement>();

            foreach (Announcement dbAnnouncement in dbContext.Announcements.Where(x => x.EventDateTime == eventDate ))
            {
                announcemmentList.Add(MapDbObjectToModel(dbAnnouncement));
            }

            return announcemmentList;
        }

        public void InsertAnnouncement(Announcement announcemment)
        {
            announcemment.Idannouncement = Guid.NewGuid();

            dbContext.Announcements.Add(MapModelToDbObject(announcemment));
            dbContext.SaveChanges();
        }

        private Announcement MapDbObjectToModel(Announcement dbAnnouncement)
        {
            Announcement announcemment = new Announcement();

            if (dbAnnouncement != null)
            {
                announcemment.Idannouncement = dbAnnouncement.Idannouncement;
                announcemment.ValidFrom = dbAnnouncement.ValidFrom;
                announcemment.ValidTo = dbAnnouncement.ValidTo;
                announcemment.Title = dbAnnouncement.Title;
                announcemment.Text = dbAnnouncement.Text;
                announcemment.EventDateTime = dbAnnouncement.EventDateTime;
                announcemment.Tags = dbAnnouncement.Tags;
            }

            return announcemment;
        }

        private Announcement MapModelToDbObject(Announcement model)
        {
            Announcement announcemment = new Announcement();

            if (model != null)
            {
                announcemment.Idannouncement = model.Idannouncement;
                announcemment.ValidFrom = model.ValidFrom;
                announcemment.ValidTo = model.ValidTo;
                announcemment.Title = model.Title;
                announcemment.Text = model.Text;
                announcemment.EventDateTime = model.EventDateTime;
                announcemment.Tags = model.Tags;
            }

            return announcemment;
        }
    }
}
