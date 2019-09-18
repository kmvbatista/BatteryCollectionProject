using System.Collections.Generic;
using DataAccessLayer;
using DataTypeObject;
using System.Linq;
using System;
using System.Threading.Tasks;

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

        public async Task Add(Discard discard)
        {
            //adicionar outros métodos de validação e implementá-los
            try
            {
                validateDiscard(discard);
                Discard mappedDiscard = await GetMappedDiscard(discard);
                discardsDbContext.Add(mappedDiscard);
                discardsDbContext.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
            
        }

        private void validateDiscard(Discard discard)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Discard> GetAllDataDiscards(User user)
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

        public Discard Find(int Id)
        {
            return discardsDbContext.Discards.Find(Id);
        }

        public async Task<Discard> GetMappedDiscard(Discard discard)
        {
            User user = GetUser(discard.UserId);
            Place place = await GetPlace(discard.PlaceId);
            Material material = await GetMaterial(discard.MaterialId);
            DateTime date = DateTime.Now;
            return new Discard(material, discard.MaterialId, user,
                discard.UserId, place, discard.PlaceId, discard.Quantity, date);
        }

        private async Task<Material> GetMaterial(int materialId)
        {
            try
            {
                MaterialBLL materialBLL = new MaterialBLL();
                return await materialBLL.Find(materialId);
            }
            catch
            {
                throw new Exception();
            }
        }

        private async Task<Place> GetPlace(int placeId)
        {
            try
            {
                PlaceBLL placeBLL = new PlaceBLL();
                return await placeBLL.Find(placeId);
            }
            catch
            {
                throw new Exception();
            }
        }

        private User GetUser(int userId)
        {
            try
            {
                UserBLL userBLL = new UserBLL();
                return userBLL.Find(userId);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
