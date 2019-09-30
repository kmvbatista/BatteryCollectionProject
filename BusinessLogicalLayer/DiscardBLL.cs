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
                validateDiscard(discard);
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

        private void validateDiscard(Discard discard)
        {
            Discard discardFound = discardsDbContext.Discards.FirstOrDefault(x => 
            x.UserId == discard.UserId && x.Date.DayOfYear== discard.Date.DayOfYear &&
            x.Date.Year == discard.Date.Year);
            if(discardFound != null) {
                throw new Exception("Você já depositou hoje");//personalizada
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

        public ChartData GetChartsData(User user)
        {
            try
            {
                ChartData chartData = new ChartData(new int[12], new int[4]);
                var yearList= discardsDbContext.Discards.Where(x => x.UserId == user.Id)
                     .GroupBy(d => d.Date.Month).Select(x => new KeyValueDiscards(x.Key, x.Count())).ToList();
                var weekList = discardsDbContext.Discards.Where(x => x.UserId == user.Id)
                     .GroupBy(d => d.DayOfWeek).Select(x => new KeyValueDiscards(x.Key, x.Count())).ToList();
                yearList.ForEach(x => chartData.YearPoints[x.Key-1] = x.Discards);
                weekList.ForEach(x => chartData.WeekPoints[x.Key-1] = x.Discards);
                return chartData;
            }
            catch
            {
                throw new Exception();
            }
        }

        public GeneralData GetGeneralData(User user)
        {
            var mostVisited = discardsDbContext.Discards.Where(x => x.UserId == user.Id).GroupBy(d => d.PlaceName)
                .OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToArray()[0];
            var mostDiscarded = discardsDbContext.Discards.Where(x => x.UserId == user.Id).GroupBy(d => d.MaterialName)
                .OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToArray()[0];
            var totalPoints = discardsDbContext.Users.Find(user.Id).TotalPoints;
            var mostDiscardedMonth = discardsDbContext.Discards.Where(x => x.UserId == user.Id).GroupBy(d => d.Date.Month).OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToArray()[0];
            return new GeneralData { MostVisited = mostVisited, MostDiscarded = mostDiscarded, TotalPoints= totalPoints, MostDiscardedMonth = mostDiscardedMonth };
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
                discard.UserId, place, discard.PlaceId, discard.Quantity,
                DateTime.Now.AddDays(2), discard.Material.Description, discard.Place.Name,
                discard.User.Name);
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
