using Championship.DAL.Models;

namespace Championship.DAL.Repositories
{
    public class TeamRepository
    {
        private readonly Context _context;
        public TeamRepository(Context context)
        {
            _context = context;
        }
        public void Add(object entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
        public void Remove(object entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(object entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public List<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }


    }
}
