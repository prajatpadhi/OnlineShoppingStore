using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CodeProject.BusinessEntities;

namespace WebAPI_CodeProject.BusinessServices
{
    interface IUserServices
    {
        UserEntity Authenticate(string username, String password);
    }
}
