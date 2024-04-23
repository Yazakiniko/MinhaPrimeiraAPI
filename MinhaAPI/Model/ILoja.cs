using System.Net;

namespace MinhaAPI.Model
{
    public interface ILoja
    {
        void Add(Loja loja);


        Loja getEmpresaByCNPJ(string Numero_CNPJ);

        void Update(Loja lojaToUpdate);

        HttpStatusCode Delete(string Numero_CNPJ);


        List<Loja> Get();
    }
}

