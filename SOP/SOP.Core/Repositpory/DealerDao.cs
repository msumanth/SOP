using SOP.Core.Data;
using SOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOP.Core.Repositpory
{
    public class DealerDao
    {
        public List<Dealer> GetAllDealers()
        {
            using (var context = new SOPEntities())
            {
                var dealers = context.Dealers.ToList();
                return dealers;
            }
        }

        public List<ServiceType> GetAllServiceTypes()
        {
            using (var context = new SOPEntities())
            {
                var sts = context.ServiceTypes.ToList();
                return sts;
            }
        }

        public Dealer GetDealer(int userId)
        {
            using (var context = new SOPEntities())
            {
                var da = context.DealerAssociations.Where(u => u.UserId == userId).FirstOrDefault();
                var dealer = context.Dealers.Where(d => d.Id == da.DealerId).FirstOrDefault();
                return dealer;
            }
        }

        public Dealer CreateNewDealer(DealerModel model)
        {
            using (var context = new SOPEntities())
            {
                var user = context.SopUsers.Where(u => u.Id == model.UserId).FirstOrDefault();
                var ndid = context.Dealers.Count();
                var dealer = new Dealer
                {
                    Id = ndid + 1,
                    Name = model.DealerName,
                    Address = model.Address,
                    PrimaryContactPersonName = model.PrimaryContactPerson,
                    PrimaryContactPersonNum = decimal.Parse(model.SecondaryContactNumber),
                    SecondaryContactPersonName = model.SecondaryContactPerson,
                    SecondaryContactPersonNum = decimal.Parse(model.SecondaryContactNumber)
                };
                context.Dealers.Add(dealer);
                context.SaveChanges();

                var nwid = context.Workshops.Count();

                var workshop = new Workshop
                {
                    Id = nwid + 1,
                    Name = model.DealerName,
                    PhoneNumber = decimal.Parse(model.WorkShopNumber),
                    Location = model.DealerLocation,
                    MapCoordinates = model.WorkshopCoordinates,
                    GeneralManagerName = model.WorkShopGeneralManager,
                    GeneralManagerNum = decimal.Parse(model.WorkShopGeneralManagerNumber),
                    DelearId = dealer.Id
                };

                context.Workshops.Add(workshop);
                context.SaveChanges();


                var da = new DealerAssociation
                {
                    UserId = model.UserId,
                    DealerId = dealer.Id
                };

                context.DealerAssociations.Add(da);
                context.SaveChanges();

                return dealer;
            }
        }

        public List<Booking> GetDealerBookings(int dealerId)
        {
            using (var context = new SOPEntities())
            {
                var bookings = context.Bookings.Where(b => b.DelearId == dealerId).ToList();
                return bookings;
            }
        }

        public List<Booking> GetAllUserBookings(int userId)
        {
            using (var context = new SOPEntities())
            {
                var bookings = context.Bookings.Where(b => b.UserId == userId).ToList();
                return bookings;
            }
        }
    }
}
