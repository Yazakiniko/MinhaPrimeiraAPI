using MinhaAPI.ViewModel;
using System.Net;

namespace MinhaAPI.Model
{
    public interface IUsuario
    {
        void Add(Usuario usuario);

        Usuario getUsuarioByCPF(string Numero_CPF);

        void Update(Usuario usuarioToUpdate);

        HttpStatusCode Delete(string Numero_CPF);
        List<Usuario> Get();
    }
}
