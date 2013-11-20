using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hook.Data.Contracts;

namespace Hook.UnitTest
{
    public  class IControllerTest
    {
         public IUnitOfWork UnitOfWork;

        public IControllerTest()
        {

        }

        public IControllerTest(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
