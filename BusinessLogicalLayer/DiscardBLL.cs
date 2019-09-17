using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;
using System;

namespace BusinessLogicalLayer
{
    public class DiscardBLL : IDISCARDCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly BatteryCollectorDbContext discardsDbContext;
        public DiscardBLL(BatteryCollectorDbContext _discardsDbContext)
        {
            discardsDbContext = _discardsDbContext;
        }

        public void Add(Discard discard)
        {
            //adicionar outros métodos de validação e implementá-los
            discard.Date = DateTime.Now.AddMonths(1);
            discardsDbContext.Add(discard);
            discardsDbContext.SaveChanges();
        }
        public Discard Find(int Id)
        {
            return discardsDbContext.Discards.Find(Id);
        }
        public void Update(Discard userPoints)
        {
            discardsDbContext.Update(userPoints);
            discardsDbContext.SaveChanges();
        }
        public IEnumerable<Discard> GetMonthlyDiscards(User user)
        {
            return discardsDbContext.Discards.Where(x => x.Date.Month == DateTime.Now.Month);
        }

        public IEnumerable<Discard> GetYearDiscards(User user)
        {
            return discardsDbContext.Discards.Where(x => x.Date.Year == DateTime.Now.Year);
        }
        public double GetTotalUserDiscards(User user)
        {
            return discardsDbContext.Discards.ToList().Count;
        }

        IEnumerable<Discard> IDISCARDCRUD.GetAllDataDiscards(User user)
        {
            try
            {
                return discardsDbContext.Discards.ToList();
            }
            catch
            {
                throw new Exception();
            }
        }

        Discard IDISCARDCRUD.Find(int Id)
        {
            return discardsDbContext.Discards.Find(Id);
        }
    }
}
