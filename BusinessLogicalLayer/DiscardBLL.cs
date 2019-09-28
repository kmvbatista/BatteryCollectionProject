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

        public void Add(Discard discard)
        {
            //adicionar outros métodos de validação e implementá-los
            try
            {
                validateDiscard(discard.UserId);
                Discard mappedDiscard = GetMappedDiscard(discard);
                discardsDbContext.Add(mappedDiscard);
                UserBLL userBLL = new UserBLL(discardsDbContext);
                userBLL.UpdatePoints(mappedDiscard.User, discard.Quantity);
                discardsDbContext.SaveChanges();
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        private void validateDiscard(int UserId)
        {
            Discard discardFound = discardsDbContext.Discards.First(x => 
            x.UserId == UserId && x.Date.DayOfYear== DateTime.Now.DayOfYear &&
            x.Date.Year == DateTime.Now.Year);
            if(discardFound != null) {
                throw new Exception();//personalizada
            }
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
            return discardsDbContext.Discards.Where(x => x.UserId==user.Id).ToList().Count;
        }

        public IEnumerable<Discard> GetAllDataDiscards(User user)
        {
            try
            {
                return discardsDbContext.Discards.Where(x => x.UserId==user.Id).ToList();
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

        public Discard GetMappedDiscard(Discard discard)
        {
            Place place =  GetPlace(discard.PlaceId);
            Material material =  GetMaterial(discard.MaterialId);
            User user = GetUser(discard.UserId);
            DateTime date = DateTime.Now;
            return new Discard(material, discard.MaterialId, user,
                discard.UserId, place, discard.PlaceId, discard.Quantity, date);
        }

        private  Material GetMaterial(int materialId)
        {
            try
            {
                MaterialBLL materialBLL = new MaterialBLL(discardsDbContext);
                return  materialBLL.Find(materialId);
            }
            catch
            {
                throw new Exception();
            }
        }

        private Place GetPlace(int placeId)
        {
            try
            {
                if(placeId<1) {
                    throw new Exception();
                }
                PlaceBLL placeBLL = new PlaceBLL(discardsDbContext);
                return placeBLL.Find(placeId);
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
                UserBLL userBLL = new UserBLL(this.discardsDbContext);
                return userBLL.Find(userId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
