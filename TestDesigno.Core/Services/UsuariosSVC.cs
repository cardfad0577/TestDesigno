﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDesigno.Core.Dtos;
using TestDesigno.Core.Interfaces;
using TestDesigno.Data.Entities;
using TestDesigno.Data.Repositories;


namespace TestDesigno.Core.Services
{
    public class UsuariosSVC : IUsuariosSVC
    {
        private readonly IUsuariosRepository _usuarioRepository;

        public UsuariosSVC(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task saveUser(UsuarioDto obj)
        {
            try
            {

                Usuario objUsuario = new()
                {
                    UsuarioId = obj.UsuarioId,
                    PrimerNombre = obj.PrimerNombre,
                    SegundoNombre = obj.SegundoNombre,
                    FechaNacimiento = DateOnly.FromDateTime(obj.FechaNacimiento),
                    PrimerApellido = obj.PrimerApellido,
                    SegundoApellido = obj.SegundoApellido,
                    Sueldo = obj.Sueldo,
                    FechaCreacion = DateTime.Now,
                };

                await _usuarioRepository.saveUser(objUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error SVC - SU: " + ex.Message);
            }
        }

        async public Task<object> deleteUser(Guid userId)
        {
            try
            {
                var usuario = await _usuarioRepository.getUserById(userId);
                if (usuario == null)
                    return null;

                await _usuarioRepository.deleteUser(usuario);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error SVC - DU: " + ex.Message);
            }
        }

        async public Task<UsuarioDto> getUserById(Guid userId)
        {
            try
            {
                var usuario = await _usuarioRepository.getUserById(userId);
                if (usuario == null)
                    return null;

                return new UsuarioDto
                {
                    UsuarioId = usuario.UsuarioId,
                    PrimerNombre = usuario.PrimerNombre,
                    SegundoNombre = usuario.SegundoNombre,
                    PrimerApellido = usuario.PrimerApellido,
                    SegundoApellido = usuario.SegundoApellido,
                    FechaNacimiento = usuario.FechaNacimiento.ToDateTime(TimeOnly.MinValue),
                    Sueldo = usuario.Sueldo,
                    FechaCreacion = usuario.FechaCreacion,
                    FechaModificacion = usuario.FechaModificacion
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error SVC - GU: " + ex.Message);
            }
        }

        public Task<IEnumerable<UsuarioDto>> getUsers(string fName, string lName, int numPage, int szPage)
        {
            throw new NotImplementedException();
        }

        async public Task updateUser(UsuarioDto obj)
        {
            try
            {
                Usuario objUsuario = new()
                {
                    UsuarioId = obj.UsuarioId,
                    PrimerNombre = obj.PrimerNombre,
                    SegundoNombre = obj.SegundoNombre,
                    PrimerApellido = obj.PrimerApellido,
                    SegundoApellido = obj.SegundoApellido,
                    FechaNacimiento = DateOnly.FromDateTime(obj.FechaNacimiento),
                    Sueldo = obj.Sueldo,
                    FechaCreacion = obj.FechaCreacion,
                    FechaModificacion = obj.FechaModificacion
                };

                await _usuarioRepository.updateUser(objUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error SVC - UU: " + ex.Message);
            }
        }
    }
}
