using System.Collections.Generic;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Services
{
    public class OrcamentoService
    {
        private OrcamentoRepository _repo = new OrcamentoRepository();

        public List<Orcamento> Listar()
        {
            // Retorna orçamentos do repositório
            return _repo.Listar();
        }

        public void Inserir(Orcamento orcamento, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode criar orçamentos.");

            // Persiste novo orçamento (o repositório insere orçamento e itens)
            _repo.Inserir(orcamento);
        }

        public void Aprovar(Orcamento orcamento, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode aprovar orçamentos.");

            // Marca como aprovado, gera número de pedido e atualiza no banco
            orcamento.Status = "Aprovado";
            orcamento.NumeroPedido = Dados.ProximoPedido++;
            _repo.Atualizar(orcamento);
        }

        public void Reprovar(Orcamento orcamento, string motivo, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode reprovar orçamentos.");

            // Marca como rejeitado com o motivo e salva
            orcamento.Status = "Rejeitado";
            orcamento.MotivoRejeicao = motivo;
            _repo.Atualizar(orcamento);
        }

        public void Excluir(int id, Usuario solicitante)
        {
            if (solicitante.Papel.Nome == "Visualizador")
                throw new System.Exception(
                    "Visualizador não pode excluir orçamentos.");

            // Exclui orçamento (e itens) via repositório
            _repo.Excluir(id);
        }
    }
}