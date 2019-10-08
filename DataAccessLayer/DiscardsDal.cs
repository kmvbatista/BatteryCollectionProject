using System;
using System.Collections.Generic;
using System.Linq;
using DataTypeObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DiscardsDal : IDISCARDDAL
    {
        private readonly BatteryCollectorDbContext discardsDbContext;

        public DiscardsDal(BatteryCollectorDbContext _discardsDbContext)
        {
            discardsDbContext = _discardsDbContext;
        }

        public void Add(Discard discard)
        {
            discardsDbContext.Database.ExecuteSqlCommand($@"
                insert into Discards values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})
            ",1, 1, 1, 10,
            DateTime.Now, "Óleo", "prefeitura", 2);
        }

        public Discard Find(int Id)
        {
            return discardsDbContext.Discards.Find(Id);
        }

        public ChartData GetChartsData(User user)
        {
            ChartData chartData = new ChartData(new int[12], new int[4]);
            var yearList = discardsDbContext.Discards.Where(x => x.UserId == user.Id)
                 .GroupBy(d => d.Date.Month).Select(x => new KeyValueDiscards(x.Key, x.Count())).ToList();
            var weekList = discardsDbContext.Discards.Where(x => x.UserId == user.Id)
                 .GroupBy(d => d.DayOfWeek).Select(x => new KeyValueDiscards(x.Key, x.Count())).ToList();
            yearList.ForEach(x => chartData.YearPoints[x.Key - 1] = x.Discards);
            weekList.ForEach(x => chartData.WeekPoints[x.Key - 1] = x.Discards);
            return chartData;
        }

        public GeneralData GetGeneralData(User user)
        {
            Discard discardsQuantity = discardsDbContext.Discards.Where(x => x.UserId == user.Id).FirstOrDefault();
            if(discardsQuantity != null) {
                var mostVisited = discardsDbContext.Discards.Where(x => x.UserId == user.Id).GroupBy(d => d.PlaceName)
                    .OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToArray()[0];
                var mostDiscarded = discardsDbContext.Discards.Where(x => x.UserId == user.Id).GroupBy(d => d.MaterialName)
                    .OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToArray()[0];
                var totalPoints = discardsDbContext.Users.Find(user.Id).TotalPoints;
                var mostDiscardedMonth = discardsDbContext.Discards.Where(x => x.UserId == user.Id).GroupBy(d => d.Date.Month).OrderByDescending(gp => gp.Count()).Take(1).Select(g => g.Key).ToArray()[0];
                return new GeneralData { MostVisited = mostVisited, MostDiscarded = mostDiscarded, TotalPoints = totalPoints, MostDiscardedMonth = mostDiscardedMonth };
            }
            return new GeneralData {MostVisited = "Nenhum", MostDiscarded = "Nenhum", TotalPoints = 0, MostDiscardedMonth = 0};
        }

        public IEnumerable<Discard> GetMonthlyDiscards(User user)
        {
           return discardsDbContext.Discards.Where(x => x.Date.Month == DateTime.Now.Month);
        }

        public List<StringValuePair> GetPieChartData(int Id)
        {
            var materialsDiscarded = discardsDbContext.Discards.Where(x => x.UserId == Id).GroupBy(d => d.MaterialName)
            .Select(d => new StringValuePair() { Key = d.Key, Value = d.Count() }).ToList();
            return materialsDiscarded;
        }

        public double GetTotalUserDiscards(User user)
        {
            return discardsDbContext.Discards.Where(x => x.UserId == user.Id).ToList().Count;
        }

        public IEnumerable<Discard> GetYearDiscards(User user)
        {
            return discardsDbContext.Discards.Where(x => x.Date.Year == DateTime.Now.Year);
        }


        public void validateDiscard(Discard discard)
        {
            Discard discardFound = discardsDbContext.Discards.FirstOrDefault(x =>
            x.UserId == discard.UserId && x.Date.DayOfYear == discard.Date.DayOfYear &&
            x.Date.Year == discard.Date.Year);
            if (discardFound != null)
            {
                throw new Exception("Você já depositou hoje");//personalizada
            }
        }
    }
}
