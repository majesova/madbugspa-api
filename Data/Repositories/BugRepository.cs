using System.Collections.Generic;
using System.Linq;
using MadBugAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MadBugAPI.Data.Repositories
{
    public class BugRepository
    {
        private readonly MadBugContext _context;
        public BugRepository(MadBugContext context)
        {
            _context = context;
        }

        public void Insert(Bug bug){
            _context.Bugs.Add(bug);
        }

        public List<Bug> GetAll(){
            return _context.Bugs.ToList();
        }

        public Bug GetById(int id){
            return _context.Bugs.Find(id);
        }

        public void Update(Bug bug){
            _context.Bugs.Attach(bug);
            _context.Entry(bug).State = EntityState.Modified;
        }

        public void Delete(int id){
            var bugForDelete = _context.Bugs.Find(id);
            _context.Bugs.Remove(bugForDelete);     
        }

    }

}