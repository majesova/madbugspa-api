namespace MadBugAPI.Data.Repositories
{
    public class UserRepository
    {
        private MadBugContext _context;
        public UserRepository(MadBugContext context)
        {
            _context = context;
        }
        
    }
}