using Microsoft.AspNetCore.Http.HttpResults;
using MinhaAPI.Model;
using MinhaAPI.ViewModel;
using System.Net;

namespace MinhaAPI.Infraestrutura
{
    public class UsuarioRepositorio : IUsuario
    {
        private ConnectionContext _context = new ConnectionContext();
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario getUsuarioByCPF(string Numero_CPF)
        {
            return _context.Find<Usuario>(Numero_CPF) == null ? null : _context.Find<Usuario>(Numero_CPF);
        }

        public void Update(Usuario usuarioToUpdate)
        {
            _context.Update(usuarioToUpdate);
            _context.SaveChanges(true);
        }

        public HttpStatusCode Delete(string Numero_CPF)
        {
            Usuario usuarioToDelete = _context.Find<Usuario>(Numero_CPF);
            if (usuarioToDelete == null) return HttpStatusCode.NotFound;

            _context.Remove(usuarioToDelete);
            _context.SaveChanges();

            return HttpStatusCode.Accepted;
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }
    }
}
