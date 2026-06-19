using System.Collections.Generic;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Services
{
    public class ServicoService
    {
        private ServicoRepository _repo = new ServicoRepository();

        public List<Servico> Listar()
        {
            return _repo.Listar();
        }

        public void Inserir(Servico servico, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode cadastrar serviços.");

            _repo.Inserir(servico);
        }

        public void Atualizar(Servico servico, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode editar serviços.");

            _repo.Atualizar(servico);
        }

        public void Excluir(int id, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode excluir serviços.");

            _repo.Excluir(id);
        }
    }
}