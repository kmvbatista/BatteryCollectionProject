using System.Collections.Generic;
using DataTypeObject;
using System;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class DiscardBLL : IDISCARDCRUD
    {
        List<ErrorField> errors = new List<ErrorField>();
        private readonly IUSERDAL userDal;
        private readonly IDISCARDDAL discardDal;
        private readonly IUSERCRUD userBll;
        private readonly IMATERIALCRUD materialBll;
        private readonly IPLACECRUD placeBll;

        public DiscardBLL(IUSERDAL uSERDAL, IDISCARDDAL dISCARDDAL, IUSERCRUD _userBll,
            IMATERIALCRUD _materialBll, IPLACECRUD placeBLL)
        {
            this.userDal = uSERDAL;
            this.discardDal = dISCARDDAL;
            this.userBll = _userBll;
            this.materialBll = _materialBll;
            this.placeBll = placeBLL;
        }

        public void Add(Discard discard)
        {
            //adicionar outros métodos de validação e implementá-los
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    validateDiscard(discard);
                    User user = this.GetUser(discard.UserId);
                    Discard mappedDiscard = GetMappedDiscard(discard, user);
                    discardDal.Add(mappedDiscard);
                    userBll.UpdatePoints(user);
                    scope.Complete();
                }
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        private void validateDiscard(Discard discard)
        {
            discardDal.validateDiscard(discard);
        }

        public void UpdateUserPoints(User user)
        {
            userBll.Update(user);
        }


        public ChartData GetChartsData(User user)
        {
            try
            {
                return discardDal.GetChartsData(user);
            }
            catch
            {
                throw new Exception();
            }
        }

        public GeneralData GetGeneralData(User user)
        {
            return discardDal.GetGeneralData(user);
        }

        public IEnumerable<Discard> GetMonthlyDiscards(User user)
        {
            return discardDal.GetMonthlyDiscards(user);
        }

        public IEnumerable<Discard> GetYearDiscards(User user)
        {
            return discardDal.GetYearDiscards(user);
        }
        public double GetTotalUserDiscards(User user)
        {
            return discardDal.GetTotalUserDiscards(user);
        }

        public List<StringValuePair> GetPieChartData(int Id) {
            return discardDal.GetPieChartData(Id);
        }

        public Discard Find(int Id)
        {
            return discardDal.Find(Id);
        }

        public Discard GetMappedDiscard(Discard discard, User user)
        {
            DateTime date = DateTime.Now;
            Material material = GetMaterial(discard.MaterialId);
            Place place = GetPlace(discard.PlaceId);
            int weekOfMonth = getWeekOfMonth(date.Day);
            return new Discard(discard.MaterialId, discard.UserId, discard.PlaceId,
                discard.Quantity, DateTime.Now, material.Description, place.Name, weekOfMonth);
        }

        private int getWeekOfMonth(int day)
        {
            if(day <= 7) {
            return 1;
            }
            else if(day <= 14) {
            return 2;
            }
            else if(day <= 21) {
            return 3;
            }
            return 4;
        }

        private  Material GetMaterial(int materialId)
        {
            try
            {
                return  materialBll.Find(materialId);
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
                return placeBll.Find(placeId);
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
                return userBll.Find(userId);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
