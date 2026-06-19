using System.Collections.Generic;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Services
{
    public class ClienteService
    {
        private ClienteRepository _repo = new ClienteRepository();

        public List<Cliente> Listar()
        {
            // Retorna lista de clientes do repositório
            return _repo.Listar();
        }

        public void Inserir(Cliente cliente, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode cadastrar clientes.");

            // Verificada autorização acima; persiste cliente
            _repo.Inserir(cliente);
        }

        public void Atualizar(Cliente cliente, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode editar clientes.");

            // Atualiza cliente no banco
            _repo.Atualizar(cliente);
        }

        public void Excluir(int id, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode excluir clientes.");

            // Exclui cliente
            _repo.Excluir(id);
        }
    }
}