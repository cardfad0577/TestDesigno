using Microsoft.AspNetCore.Mvc;
using TestDesigno.Core.Interfaces;
using TestDesigno.Data.Entities;

namespace TestDesigno.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUsuariosSVC _userSVC;

        public UserController(IUsuariosSVC userSVC)
        {
            _userSVC = userSVC;
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="dtoUser">El usuario a crear.</param>
        /// <returns>El resultado de la creación.</returns>
        [Route("saveUser")]
        [HttpPost]
        public async Task<IActionResult> saveUser([FromBody] Usuario dtoUser)
        {
            await _userSVC.saveUser(dtoUser);
            return CreatedAtAction(nameof(updateUser), new { id = dtoUser.UsuarioId }, dtoUser);
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="dtoUser">El usuario con los datos actualizados.</param>
        /// <returns>Un resultado indicando el estado de la operación.</returns>
        [Route("updateUser")]
        [HttpPut]
        public async Task<IActionResult> updateUser([FromBody] Usuario dtoUser)
        {
            await _userSVC.updateUser(dtoUser);
            return NoContent();
        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="userId">El ID del usuario a eliminar.</param>
        /// <returns>Un resultado indicando el estado de la operación.</returns>
        [Route("deleteUser")]
        [HttpDelete]
        public async Task<IActionResult> deleteUser(Guid userId)
        {
            await _userSVC.deleteUser(userId);
            return NoContent();
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="userId">El ID del usuario a buscar.</param>
        /// <returns>El usuario encontrado.</returns>
        [Route("getUserById")]
        [HttpGet]
        public async Task<ActionResult<Usuario>> getUserById(Guid userId)
        {
            var usuario = await _userSVC.getUserById(userId);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Busca usuarios por primer nombre o primer apellido con paginación.
        /// </summary>
        /// <param name="primerNombre">El primer nombre para buscar.</param>
        /// <param name="primerApellido">El primer apellido para buscar.</param>
        /// <param name="numeroPagina">El número de la página a obtener.</param>
        /// <param name="tamanioPagina">La cantidad de registros a traer por página.</param>
        /// <returns>Una lista de usuarios encontrados.</returns>
        [Route("getUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> getUsers(string primerNombre, string primerApellido, int numeroPagina = 1, int tamanioPagina = 10)
        {
            var usuarios = await _userSVC.getUsers(primerNombre, primerApellido, numeroPagina, tamanioPagina);
            return Ok(usuarios);
        }
    }
}
