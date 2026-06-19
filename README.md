[README.md](https://github.com/user-attachments/files/29118872/README.md)
# Sistema de Gestão de Orçamentos Platinum

Sistema desktop desenvolvido em **C# com Windows Forms e .NET Framework**, com banco de dados **SQLite**, login obrigatório e controle de acesso baseado em papéis (**RBAC**).

---

## Sobre o projeto

O sistema permite gerenciar clientes, serviços e orçamentos de forma completa. Os dados são salvos permanentemente em um banco SQLite local. O acesso é protegido por login com senha criptografada via **BCrypt**, e cada usuário possui um papel que determina o que ele pode fazer no sistema.

---

## Funcionalidades

- Cadastro, edição e exclusão de **clientes**
- Cadastro, edição e exclusão de **serviços**
- Criação de **orçamentos** com múltiplos itens
- Aprovação e reprovação de orçamentos com motivo
- **Login obrigatório** com senha protegida por BCrypt
- **RBAC** com 3 papéis: Admin, Operador e Visualizador
- Tela exclusiva para **gerenciamento de usuários** (apenas Admin)

---

## Controle de acesso — RBAC

| Papel | O que pode fazer |
|---|---|
| **Visualizador** | Apenas visualiza os dados. Botões de edição ficam desabilitados. |
| **Operador** | Realiza o CRUD completo de clientes, serviços e orçamentos. |
| **Admin** | Faz tudo do Operador e também gerencia usuários e seus papéis. |

A verificação do papel acontece tanto na interface (botões desabilitados) quanto na camada de serviço (Service), antes de qualquer operação no banco.

---

## Tecnologias utilizadas

- C# / .NET Framework
- Windows Forms
- SQLite (`System.Data.SQLite`)
- BCrypt (`BCrypt.Net-Next`)
- Visual Studio

---

## Arquitetura

O projeto segue uma arquitetura em camadas:

```
WindowsFormsApp1/
│
├── Data/               # Conexão e inicialização do banco
│   ├── Conexao.cs
│   └── Banco.cs
│
├── Modelos/            # Classes de domínio
│   ├── Cliente.cs
│   ├── Servico.cs
│   ├── Orcamento.cs
│   ├── ItemOrcamento.cs
│   ├── Usuario.cs
│   └── Papel.cs
│
├── Repositories/       # Acesso direto ao banco de dados
│   ├── ClienteRepository.cs
│   ├── ServicoRepository.cs
│   ├── OrcamentoRepository.cs
│   └── UsuarioRepository.cs
│
├── Services/           # Regras de negócio e verificação de papéis
│   ├── ClienteService.cs
│   ├── ServicoService.cs
│   ├── OrcamentoService.cs
│   └── UsuarioService.cs
│
├── Form1.cs            # Tela principal
├── FormLogin.cs        # Tela de login
└── FormUsuarios.cs     # Gerenciamento de usuários (Admin)
```

---

## Como rodar o projeto

### Pré-requisitos

- Visual Studio 2019 ou superior
- .NET Framework 4.7.2 ou superior
- Pacotes NuGet: `System.Data.SQLite` e `BCrypt.Net-Next`

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/bellatrixishere/projetoC
```

2. Abra o arquivo `.sln` no Visual Studio

3. Restaure os pacotes NuGet:
   - Clique com botão direito na solução → **Restore NuGet Packages**

4. Compile e execute com **F5**

5. No primeiro acesso, o sistema criará automaticamente o usuário administrador:
   - **Login:** `admin`
   - **Senha:** `1234`

---

## Primeiro acesso

Ao rodar pela primeira vez, o sistema detecta que não há usuários cadastrados e cria um admin padrão automaticamente. Uma mensagem será exibida com as credenciais iniciais.

Após entrar, acesse **Gerenciar Usuários** para cadastrar novos usuários e definir seus papéis.

---

## Desenvolvedores

| GitHub | Papel no projeto |
|---|---|
| [@bellatrixishere](https://github.com/bellatrixishere) | Desenvolvimento geral |
| [@CarlosHSiqueiraB](https://github.com/CarlosHSiqueiraB) | Desenvolvimento geral |

---

## Licença

Projeto acadêmico — desenvolvido para fins educacionais.
