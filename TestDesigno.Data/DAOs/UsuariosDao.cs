using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDesigno.Data.Entities;
using TestDesigno.Data.Models;
using TestDesigno.Data.Repositories;

namespace TestDesigno.Data.DAOs
{
    public class UsuariosDao : IUsuariosRepository
    {
        private readonly TestDesignoContext _context;

        public UsuariosDao(TestDesignoContext context)
        {
            _context = context;
        }

        async public Task deleteUser(Usuario dtoUser)
        {
            try
            {
                _context.Usuarios.Remove(dtoUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO - DU: " + ex.Message);
            }
        }

        async public Task<Usuario> getUserById(Guid userId)
        {
            try
            {
                var user = await _context.Usuarios.FindAsync(userId);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO - GU: " + ex.Message);
            }
        }

        async public Task<IEnumerable<Usuario>> getUsers(string fName, string lName, int numPage, int szPage)
        {
            try
            {
                var query = _context.Usuarios.AsQueryable();

                if (!string.IsNullOrEmpty(fName))
                    query = query.Where(u => u.PrimerNombre.Contains(fName));

                if (!string.IsNullOrEmpty(lName))
                    query = query.Where(u => u.PrimerApellido.Contains(lName));

                query = query.OrderBy(u => u.FechaCreacion);

                query = query.Skip((numPage - 1) * szPage).Take(szPage);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO - GU: " + ex.Message);
            }
        }

        async public Task saveUser(Usuario dtoUser)
        {
            try
            {
                await _context.Usuarios.AddAsync(dtoUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO - SU: " + ex.Message);
            }
        }

        async public Task updateUser(Usuario dtoUser)
        {
            try
            {
                var existingUser = await _context.Usuarios.FindAsync(dtoUser.UsuarioId);

                existingUser.PrimerNombre = dtoUser.PrimerNombre;
                existingUser.SegundoNombre = dtoUser.SegundoNombre;
                existingUser.PrimerApellido = dtoUser.PrimerApellido;
                existingUser.SegundoApellido = dtoUser.SegundoApellido;
                existingUser.FechaNacimiento = dtoUser.FechaNacimiento;
                existingUser.Sueldo = dtoUser.Sueldo;
                existingUser.FechaModificacion = DateTime.Now;

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO - UU: " + ex.Message);
            }
        }
    }
}
