using Microsoft.AspNetCore.Mvc;
using TestDesigno.Core.Dtos;
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
        public async Task<IActionResult> saveUser([FromBody] UsuarioDto dtoUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _userSVC.saveUser(dtoUser);
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="dtoUser">El usuario con los datos actualizados.</param>
        /// <returns>Un resultado indicando el estado de la operación.</returns>
        [Route("updateUser")]
        [HttpPut]
        public async Task<IActionResult> updateUser([FromBody] UsuarioDto dtoUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var res = await _userSVC.updateUser(dtoUser);
                if (res == null)
                    return NoContent();
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            try
            {
                var res = await _userSVC.deleteUser(userId);
                if (res == null)
                    return NoContent();
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="userId">El ID del usuario a buscar.</param>
        /// <returns>El usuario encontrado.</returns>
        [Route("getUserById")]
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> getUserById(Guid userId)
        {
            try
            {
                var usuario = await _userSVC.getUserById(userId);
                if (usuario == null)
                    return NoContent();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> getUsers(string primerNombre, string primerApellido, int numeroPagina = 1, int tamanioPagina = 10)
        {
            try
            {
                var usuarios = await _userSVC.getUsers(primerNombre, primerApellido, numeroPagina, tamanioPagina);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
