using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDesigno.Core.Interfaces;
using TestDesigno.Data.Entities;

namespace TestDesigno.Core.Services
{
    class UsuariosSVC : IUsuariosSVC
    {
        public Task deleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> getUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> getUsers(string fName, string lName, int numPage, int szPage)
        {
            throw new NotImplementedException();
        }

        public Task saveUser(Usuario dtoUser)
        {
            throw new NotImplementedException();
        }

        public Task updateUser(Usuario dtoUser)
        {
            throw new NotImplementedException();
        }
    }
}
