using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDesigno.Data.Entities;

namespace TestDesigno.Data.Repositories
{
    public interface IUsuariosRepository
    {
        Task saveUser(Usuario dtoUser);
        Task deleteUser(Usuario dtoUser);
        Task updateUser(Usuario dtoUser);
        Task<Usuario> getUserById(Guid userId);
        Task<IEnumerable<Usuario>> getUsers(string fName, string lName, int numPage, int szPage);
    }
}
