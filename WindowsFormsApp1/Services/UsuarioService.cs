using System.Collections.Generic;
using WindowsFormsApp1.Modelos;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Services
{
    public class UsuarioService
    {
        private UsuarioRepository _repo = new UsuarioRepository();

        public Usuario Autenticar(string login, string senha)
        {
            return _repo.Validar(login, senha);
        }

        public void CadastrarUsuario(Usuario usuario, Usuario solicitante)
        {
            if (solicitante.Papel.Nome != "Admin")
                throw new System.Exception(
                    "Apenas Admin pode cadastrar usuários.");

            _repo.Inserir(usuario);
        }

        public List<Usuario> Listar(Usuario solicitante)
        {
            if (solicitante.Papel.Nome != "Admin")
                throw new System.Exception(
                    "Apenas Admin pode listar usuários.");

            return _repo.Listar();
        }

        public void Excluir(int id, Usuario solicitante)
        {
            if (solicitante.Papel.Nome != "Admin")
                throw new System.Exception(
                    "Apenas Admin pode excluir usuários.");

            _repo.Excluir(id);
        }

        public List<Papel> ListarPapeis()
        {
            return _repo.ListarPapeis();
        }

        public bool ExisteAlgumUsuario()
        {
            return _repo.ExisteAlgumUsuario();
        }
    }
}