using MinhaAPI.Model;
using System.Net;

namespace MinhaAPI.Infraestrutura
{
    public class LojaRepositorio : ILoja
    {
        private  ConnectionContext _context = new ConnectionContext();
        public void Add(Loja loja)
        {
            _context.Lojas.Add(loja);
            _context.SaveChanges();
        }
        public Loja getEmpresaByCNPJ(string Numero_CNPJ)
        {
            return _context.Find<Loja>(Numero_CNPJ) == null ? null : _context.Find<Loja>(Numero_CNPJ);
        }

        public void Update(Loja lojaToUpdate)
        {
            _context.Update(lojaToUpdate);
            _context.SaveChanges(true);
        }

        public HttpStatusCode Delete(string Numero_CNPJ)
        {
            Loja lojaToDelete = _context.Find<Loja>(Numero_CNPJ);
            if (lojaToDelete == null) return HttpStatusCode.NotFound;

            _context.Remove(lojaToDelete);
            _context.SaveChanges();

            return HttpStatusCode.Accepted;
        }

        public List<Loja> Get()
        {
            return _context.Lojas.ToList();
        }
    }
}
