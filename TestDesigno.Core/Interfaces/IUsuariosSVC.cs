
using TestDesigno.Data.Entities;

namespace TestDesigno.Core.Interfaces
{
    public interface IUsuariosSVC
    {
        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dtoUser">El usuario a crear.</param>
        /// <returns>Un Task que representa la operación asíncrona.</returns>
        Task saveUser(Usuario dtoUser);

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="userId">El ID del usuario a eliminar.</param>
        /// <returns>Un Task que representa la operación asíncrona.</returns>
        Task deleteUser(Guid userId);

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="dtoUser">El usuario con los datos actualizados.</param>
        /// <returns>Un Task que representa la operación asíncrona.</returns>
        Task updateUser(Usuario dtoUser);

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="userId">El ID del usuario a buscar.</param>
        /// <returns>El usuario encontrado.</returns>
        Task<Usuario> getUserById(Guid userId);

        /// <summary>
        /// Busca usuarios por primer nombre o primer apellido con paginación.
        /// </summary>
        /// <param name="fName">El primer nombre para buscar.</param>
        /// <param name="lName">El primer apellido para buscar.</param>
        /// <param name="numPage">El número de la página a obtener.</param>
        /// <param name="szPages">La cantidad de registros a traer por página.</param>
        /// <returns>Una lista de usuarios encontrados.</returns>
        Task<IEnumerable<Usuario>> getUsers(string fName, string lName, int numPage, int szPage);
    }
}
