using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;
using Modelo;
using Negocio;

namespace Visao {
  public class Clinica {
    private static bool sessaoAdm = false;
    private static Usuario sessaoCliente = null;

    public static void InserirAdm() {
      Usuario u = new Usuario();
      u.Nome = "admin";
      u.Senha = "admin";
      u.Admin = true;
      NUsuario.Criar(u);
    }
    
    public static void Main() {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);
      
      //InserirAdm();

      Console.WriteLine("Bem-vindo à Clínica Ronrom!\n");
      int opc = 0;
      do {
        try {
          opc = Menu();
          switch (opc) {
          case 01:
              if (Login()) {
                if (sessaoAdm) PaginaAdmin();
                else PaginaCliente();
              }
              else
                Console.WriteLine("Usuário ou senha inválidos!\n");
              break;
          case 02:
              Cadastro();
            break;
          }
        }
        catch (Exception error) {
          Console.WriteLine(error.Message);
        }
      } while (opc != 99);
    }

    public static void PaginaAdmin() {
      int opc = 0;
      do {
        try {
          opc = MenuAdmin();
          switch (opc) {
          case 01: InserirServico(); break;
          case 02: ListarServico(); break;
          case 03: AtualizarServico(); break;
          case 04: DeletarServico(); break;
      
          case 05: ListarCadastro(); break;
      
          case 06: ListarConsulta(); break;
          case 07: AtualizarConsulta(); break;
          }
        }
        catch (Exception error) {
          Console.WriteLine(error.GetType() + "\n" + error.Message);
        }
      } while (opc != 99);
    }

    public static void PaginaCliente() {
      int opc = 0;
      do {
        try {
          opc = MenuCliente();
          switch (opc) {
          case 01: InserirGato(); break;
          case 02: ListarGato(); break;
          case 03: AtualizarGato(); break;
          case 04: DeletarGato(); break;
              
          case 05: ListarServico(); break;
              
          case 06: InserirItem(); break;
          case 07: VerItens(); break;
          case 08: DeletarItem(); break;
    
          case 09: SolicitarConsulta(); break;
          case 10: VerConsultas(); break;
            
          case 11: AtualizarCadastro(); break;
          }
        }
        catch (Exception error) {
          Console.WriteLine(error.GetType() + "\n" + error.Message);
        }
      } while (opc != 99);
    }

    public static int Menu() {
      Console.WriteLine("=(^-^)= Página de Login =(^-^)=\n");
      Console.WriteLine("1 - Login");
      Console.WriteLine("2 - Cadastro\n");
      Console.WriteLine("99 - Sair\n");
      Console.WriteLine("=(^-^)=\n");
      Console.WriteLine("Opção: ");
      return int.Parse(Console.ReadLine());
    }

    public static int MenuAdmin() {
      Console.WriteLine("= PAINEL ADMIN =\n");
      Console.WriteLine("=(^-^)= Serviços =(^-^)=\n");
      Console.WriteLine("1 - Inserir");
      Console.WriteLine("2 - Listar");
      Console.WriteLine("3 - Atualizar");
      Console.WriteLine("4 - Deletar\n");
      Console.WriteLine("=(^-^)= Cadastros =(^-^)=");
      Console.WriteLine("5 - Listar\n");
      Console.WriteLine("=(^-^)= Consultas =(^-^)=");
      Console.WriteLine("6 - Listar");
      Console.WriteLine("7 - Atualizar\n");
      Console.WriteLine("99 - Logout\n");
      Console.WriteLine("=(^-^)=\n");
      Console.WriteLine("Opção: ");
      return int.Parse(Console.ReadLine());
    }

    public static int MenuCliente() {
      Console.WriteLine("");
      Console.WriteLine("=(^-^)= Menu =(^-^)=\n");
      Console.WriteLine("1 - Cadastrar gato");
      Console.WriteLine("2 - Listar gatos");
      Console.WriteLine("3 - Atualizar gato");
      Console.WriteLine("4 - Deletar gato\n");
      Console.WriteLine("5 - Listar serviços\n");
      Console.WriteLine("6 - Inserir item na consulta");
      Console.WriteLine("7 - Ver itens");
      Console.WriteLine("8 - Deletar item\n");
      Console.WriteLine("9 - Solicitar consulta");
      Console.WriteLine("10 - Ver consultas\n");
      Console.WriteLine("11 - Atualizar dados pessoais\n");
      Console.WriteLine("99 - Logout\n");
      Console.WriteLine("=(^-^)=\n");
      Console.WriteLine("Opção: ");
      return int.Parse(Console.ReadLine());
    }

    public static void InserirServico() {
      Console.WriteLine("=(^-^)= Novo serviço =(^-^)=");

      Console.WriteLine("Informe o nome do serviço:");
      string nome = Console.ReadLine();
      Console.WriteLine("Informe o valor:");
      double valor = double.Parse(Console.ReadLine());
      Console.WriteLine("Informe a descrição:");
      string desc = Console.ReadLine();

      Servico s = new Servico();
      s.Nome = nome;
      s.Valor = valor;
      s.Descricao = desc;

      NServico.Criar(s);

      Console.WriteLine("Serviço adicionado com sucesso!");
    }
    public static void ListarServico() {
      Console.WriteLine("=(^-^)= Lista de serviços =(^-^)=");

      foreach (Servico obj in NServico.Listar())
        Console.WriteLine(obj);
    }
    public static void AtualizarServico() {
      Console.WriteLine("=(^-^)= Atualizar serviço =(^-^)=");

      foreach (Servico obj in NServico.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID do serviço para atualizar:");
      int id = int.Parse(Console.ReadLine());

      Console.WriteLine("Informe o novo nome:");
      string nome = Console.ReadLine();
      Console.WriteLine("Informe o novo valor:");
      double valor = double.Parse(Console.ReadLine());
      Console.WriteLine("Informe a nova descrição:");
      string desc = Console.ReadLine();

      Servico s = new Servico();
      s.Id = id;
      s.Nome = nome;
      s.Valor = valor;
      s.Descricao = desc;

      NServico.Atualizar(s);

      Console.WriteLine("Serviço atualizado com sucesso!");
    }
    public static void DeletarServico() {
      Console.WriteLine("=(^-^)= Deletar serviço =(^-^)=");

      foreach (Servico obj in NServico.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID do serviço para remover:");
      int id = int.Parse(Console.ReadLine());

      Servico s = new Servico();
      s.Id = id;

      NServico.Deletar(s);

      Console.WriteLine("Serviço deletado com sucesso!");
    }
      
    public static void ListarCadastro() {
      Console.WriteLine("=(^-^)= Lista de cadastros =(^-^)=");

      Console.WriteLine("Clientes:");
      foreach (Cliente obj in NCliente.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Gatos:");
      foreach (Gato obj in NGato.Listar())
        Console.WriteLine(obj);
    }
      
    public static void ListarConsulta() {
      Console.WriteLine("=(^-^)= Lista de consultas =(^-^)=");

      foreach (Consulta obj in NConsulta.Listar())
        Console.WriteLine(obj);
    }
    public static void AtualizarConsulta() {
      Console.WriteLine("=(^-^)= Atualizar consulta =(^-^)=");

      foreach (Consulta obj in NConsulta.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID da consulta para atualizar:");
      int id = int.Parse(Console.ReadLine());

      Console.WriteLine("Informe o ID do gato:");
      int idgato = int.Parse(Console.ReadLine());
      Console.WriteLine("Informe o novo valor:");
      double valor = double.Parse(Console.ReadLine());
      Console.WriteLine("Informe o novo status:");
      string status = Console.ReadLine();
      Console.WriteLine("Informe a nova data:");
      DateTime data = DateTime.Now;

      Consulta c = new Consulta();
      c.Id = id;
      c.IdGato = idgato;
      c.Total = valor;
      c.Status = status;
      c.Data = data;

      NConsulta.Atualizar(c);

      Console.WriteLine("Consulta atualizada com sucesso!");
    }
  
    public static void InserirGato() {
      Console.WriteLine("=(^-^)= Adicionar gato =(^-^)=");

      Console.WriteLine("Informe o nome:");
      string nome = Console.ReadLine();
      Console.WriteLine("Informe a cor:");
      string cor = Console.ReadLine();
      Console.WriteLine("Informe o peso:");
      double peso = double.Parse(Console.ReadLine());
      Console.WriteLine("Informe a idade:");
      double idade = double.Parse(Console.ReadLine());

      Gato g = new Gato();
      g.Nome = nome;
      g.Cor = cor;
      g.Peso = peso;
      g.Idade = idade;
      g.IdCliente = sessaoCliente.Id;

      NGato.Criar(g);

      Console.WriteLine("Gato cadastrado com sucesso!");
    }
    public static void ListarGato() {
      Console.WriteLine("=(^-^)= Meus gatos =(^-^)=");

      foreach (Gato obj in NGato.Listar())
        Console.WriteLine(obj);
    }
    public static void AtualizarGato() {
      Console.WriteLine("=(^-^)= Atualizar gato =(^-^)=");

      foreach (Gato obj in NGato.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID do gato para atualizar:");
      int id = int.Parse(Console.ReadLine());

      Console.WriteLine("Informe o novo nome:");
      string nome = Console.ReadLine();
      Console.WriteLine("Informe a nova cor:");
      string cor = Console.ReadLine();
      Console.WriteLine("Informe o novo peso:");
      double peso = double.Parse(Console.ReadLine());
      Console.WriteLine("Informe a nova idade:");
      double idade = double.Parse(Console.ReadLine());

      Gato g = new Gato();
      g.Id = id;
      g.Nome = nome;
      g.Cor = cor;
      g.Peso = peso;
      g.Idade = idade;
      g.IdCliente = sessaoCliente.Id;

      NGato.Atualizar(g);

      Console.WriteLine("Informações do gato atualizadas com sucesso!");
    }
    public static void DeletarGato() {
      Console.WriteLine("=(^-^)= Remover gato =(^-^)=");

      foreach (Gato obj in NGato.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID do gato para remover:");
      int id = int.Parse(Console.ReadLine());

      Gato g = new Gato();
      g.Id = id;

      NGato.Deletar(g);

      Console.WriteLine("Informações do gato deletadas com sucesso!");
    }
              
    public static void InserirItem() {
      Console.WriteLine("=(^-^)= Inserir item =(^-^)=");
      
      foreach (Servico obj in NServico.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID do serviço para adicionar:");
      int idservico = int.Parse(Console.ReadLine());

      foreach (Gato obj in NGato.Listar()) {
        if (obj.IdCliente == sessaoCliente.Id) Console.WriteLine(obj);
      }
      
      Console.WriteLine("Informe o ID do gato que receberá o serviço:");
      int idgato = int.Parse(Console.ReadLine());

      ItemConsulta item = new ItemConsulta();
      item.IdServico = idservico;
      item.IdGato = idgato;
      item.Valor = NServico.Procurar(idservico).Valor;

      NItemConsulta.Criar(item);

      Console.WriteLine("Item adicionado com sucesso!");
    }
    public static void VerItens() {
      Console.WriteLine("=(^-^)= Lista de itens na consulta =(^-^)=");

      foreach (ItemConsulta obj in NItemConsulta.Listar()) {
        int cliente = NGato.Procurar(obj.IdGato).IdCliente;
        if (cliente == sessaoCliente.Id) Console.WriteLine(obj);
      }
    }
    public static void DeletarItem() {
      Console.WriteLine("=(^-^)= Remover item da consulta =(^-^)=");

      foreach (ItemConsulta obj in NItemConsulta.Listar())
        Console.WriteLine(obj);

      Console.WriteLine("Informe o ID do item para remover:");
      int id = int.Parse(Console.ReadLine());

      ItemConsulta i = new ItemConsulta();
      i.Id = id;

      NItemConsulta.Deletar(i);

      Console.WriteLine("Item deletado com sucesso!");
    }
    
    public static void SolicitarConsulta() {
      Console.WriteLine("=(^-^)= Agendar consulta =(^-^)=");
      Console.WriteLine("Confirmar solicitação? (s/n)");
      string s = Console.ReadLine();
      if (s == "s") {
        Consulta c = new Consulta();
        double valor = 0;
        foreach (ItemConsulta obj in NItemConsulta.Listar()) {
          int cliente = NGato.Procurar(obj.IdGato).IdCliente;
          if (cliente == sessaoCliente.Id) {
            valor += obj.Valor;
            c.IdGato = obj.IdGato;
          }
        }
        c.Total = valor;
        c.Status = "Em aberto";
        c.Data = DateTime.Now;

        NConsulta.Criar(c);
      }
    }
    public static void VerConsultas() {
      Console.WriteLine("=(^-^)= Lista de consultas =(^-^)=");

      foreach (Consulta obj in NConsulta.Listar()) {
        int cliente = NGato.Procurar(obj.IdGato).IdCliente;
        if (cliente == sessaoCliente.Id) Console.WriteLine(obj);
      }
    }

    public static void AtualizarCadastro() {
      Console.WriteLine("=(^-^)= Atualizar dados =(^-^)=");

      Console.WriteLine("Informe o novo nome:");
      string nome = Console.ReadLine();
      Console.WriteLine("Informe o novo endereço:");
      string end = Console.ReadLine();
      Console.WriteLine("Informe o novo telefone:");
      string tel = Console.ReadLine();
      Console.WriteLine("Informe o novo CPF:");
      string cpf = Console.ReadLine();

      Cliente c = new Cliente();
      c.IdUsuario = sessaoCliente.Id;
      c.Id = NCliente.ProcurarUser(c.IdUsuario).Id;
      c.Nome = nome;
      c.Endereco = end;
      c.Telefone = tel;
      c.CPF = cpf;

      NCliente.Atualizar(c);

      Console.WriteLine("Informações atualizadas com sucesso!");
    }
    
    public static bool Login() {
      Console.WriteLine("Usuário:");
      string nome = Console.ReadLine();
      Console.WriteLine("Senha:");
      string senha = Console.ReadLine();
      Usuario u = NUsuario.Validar(nome, senha);
      if (u != null) {
        sessaoAdm = u.Admin;
        sessaoCliente = NUsuario.Procurar(u.Id);
        return true;
      }
      return false;
    }
    public static void Cadastro() {
      Console.WriteLine("Usuário:");
      string nome = Console.ReadLine();
      Console.WriteLine("Senha:");
      string senha = Console.ReadLine();
      
      Usuario u = new Usuario();
      u.Nome = nome;
      u.Senha = senha;
      u.Admin = false;
      int idUsuario = NUsuario.Criar(u);

      Console.WriteLine("=(^-^)= Dados pessoais =(^-^)=");
      Console.WriteLine("Nome completo:");
      string nomeCompl = Console.ReadLine();
      Console.WriteLine("Endereço:");
      string end = Console.ReadLine();
      Console.WriteLine("Telefone: (DDD) 9 XXXX-XXXX");
      string tel = Console.ReadLine();
      Console.WriteLine("CPF: (XXX.XXX.XXX-XX)");
      string cpf = Console.ReadLine();
      
      Cliente c = new Cliente();
      c.Nome = nomeCompl;
      c.IdUsuario = idUsuario;
      c.Endereco = end;
      c.Telefone = tel;
      c.CPF = cpf;
      NCliente.Criar(c);
      
      Console.WriteLine("Cliente cadastrado com sucesso!");
    }
    
  }
}