﻿using Chapter.Contexts;
using Chapter.Interfaces;
using Chapter.Models;

namespace Chapter.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _context;

        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
           Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;

                _context.Usuarios.Update(usuarioEncontrado);

                _context.SaveChanges();


            }
        }

        public Usuario BuscarId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);

            _context.Usuarios.RemoveRange(usuario);

            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
