using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOP.Core.Repositpory
{
    public class DbRepository
    {
        private UserDao _userdao;
        private DealerDao _dealer;
        private BookingDao _bookingdao;

        public UserDao UserDao
        {
            get
            {
                if (_userdao == null)
                    _userdao = new UserDao();

                return _userdao;
            }
        }

        public DealerDao DealerDao
        {
            get
            {
                if (_dealer == null)
                    _dealer = new DealerDao();

                return _dealer;
            }
        }

        public BookingDao BookingDao
        {
            get
            {
                if (_bookingdao == null)
                    _bookingdao = new BookingDao();

                return _bookingdao;
            }
        }
    }
}
