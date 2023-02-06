using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;

public class Clinica {
  private static bool sessaoAdm = false;
  private static Usuario sessaoAtual = null;
  private static int cliente = 0;

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
        case 12: VerDados(); break;
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
    Console.WriteLine("=(^-^)= Cadastros =(^-^)=\n");
    Console.WriteLine("5 - Listar\n");
    Console.WriteLine("=(^-^)= Consultas =(^-^)=\n");
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
    Console.WriteLine("11 - Atualizar dados pessoais");
    Console.WriteLine("12 - Ver dados pessoais\n");
    Console.WriteLine("99 - Logout\n");
    Console.WriteLine("=(^-^)=\n");
    Console.WriteLine("Opção: ");
    return int.Parse(Console.ReadLine());
  }

  public static void InserirServico() {
    Console.WriteLine("\n=(^-^)= Novo serviço =(^-^)=");
    Console.WriteLine("");

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
    Console.WriteLine("\n=(^-^)= Lista de serviços =(^-^)=");
    Console.WriteLine("");

    foreach (Servico obj in NServico.Listar())
      Console.WriteLine(obj);
  }
  public static void AtualizarServico() {
    Console.WriteLine("\n=(^-^)= Atualizar serviço =(^-^)=");
    Console.WriteLine("");

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
    Console.WriteLine("\n=(^-^)= Deletar serviço =(^-^)=");
    Console.WriteLine("");

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
    Console.WriteLine("\n=(^-^)= Lista de cadastros =(^-^)=");
    Console.WriteLine("");

    Console.WriteLine("= Clientes =\n");
    foreach (Cliente obj in NCliente.Listar())
      Console.WriteLine(obj);

    Console.WriteLine("= Gatos =\n");
    foreach (Gato obj in NGato.Listar())
      Console.WriteLine(obj);
  }
    
  public static void ListarConsulta() {
    Console.WriteLine("\n=(^-^)= Lista de consultas =(^-^)=");
    Console.WriteLine("");

    foreach (Consulta obj in NConsulta.Listar())
      Console.WriteLine(obj);
  }
  public static void AtualizarConsulta() {
    Console.WriteLine("\n=(^-^)= Atualizar consulta =(^-^)=");
    Console.WriteLine("");

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
    Console.WriteLine("\n=(^-^)= Adicionar gato =(^-^)=");
    Console.WriteLine("");

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
    g.IdCliente = cliente;

    NGato.Criar(g);

    Console.WriteLine("Gato cadastrado com sucesso!");
  }
  public static void ListarGato() {
    Console.WriteLine("\n=(^-^)= Seus gatos =(^-^)=");
    Console.WriteLine("");

    IEnumerable<Gato> ids = NGato.Listar().Where(g => g.IdCliente == cliente);
    foreach (Gato obj in ids) Console.WriteLine(obj);
  }
  public static void AtualizarGato() {
    Console.WriteLine("\n=(^-^)= Atualizar gato =(^-^)=");
    Console.WriteLine("");

    IEnumerable<Gato> ids = NGato.Listar().Where(g => g.IdCliente == cliente);
    foreach (Gato obj in ids) Console.WriteLine(obj);

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

    Gato gt = new Gato();
    gt.Id = id;
    gt.Nome = nome;
    gt.Cor = cor;
    gt.Peso = peso;
    gt.Idade = idade;
    gt.IdCliente = cliente;

    NGato.Atualizar(gt);

    Console.WriteLine("Informações do gato atualizadas com sucesso!");
  }
  public static void DeletarGato() {
    Console.WriteLine("\n=(^-^)= Remover gato =(^-^)=");
    Console.WriteLine("");

    IEnumerable<Gato> ids = NGato.Listar().Where(g => g.IdCliente == cliente);
    foreach (Gato obj in ids) Console.WriteLine(obj);

    Console.WriteLine("Informe o ID do gato para remover:");
    int id = int.Parse(Console.ReadLine());

    Gato gt = new Gato();
    gt.Id = id;

    NGato.Deletar(gt);

    Console.WriteLine("Informações do gato deletadas com sucesso!");
  }
            
  public static void InserirItem() {
    Console.WriteLine("\n=(^-^)= Inserir item na consulta =(^-^)=");
    Console.WriteLine("");
    
    foreach (Servico obj in NServico.Listar())
      Console.WriteLine(obj);

    Console.WriteLine("Informe o ID do serviço para adicionar:");
    int idservico = int.Parse(Console.ReadLine());

    IEnumerable<Gato> ids = NGato.Listar().Where(g => g.IdCliente == cliente);
    foreach (Gato obj in ids) Console.WriteLine(obj);
    
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
    Console.WriteLine("\n=(^-^)= Lista de itens na consulta =(^-^)=");
    Console.WriteLine("");

    IEnumerable<ItemConsulta> itemids = NItemConsulta.Listar().Where(i => NGato.Procurar(i.IdGato).IdCliente == cliente);
    foreach (ItemConsulta obj in itemids) Console.WriteLine(obj);
  }
  public static void DeletarItem() {
    Console.WriteLine("\n=(^-^)= Remover item da consulta =(^-^)=");
    Console.WriteLine("");

    IEnumerable<ItemConsulta> itemids = NItemConsulta.Listar().Where(i => NGato.Procurar(i.IdGato).IdCliente == cliente);
    foreach (ItemConsulta obj in itemids) Console.WriteLine(obj);

    Console.WriteLine("Informe o ID do item para remover:");
    int id = int.Parse(Console.ReadLine());

    ItemConsulta it = new ItemConsulta();
    it.Id = id;

    NItemConsulta.Deletar(it);

    Console.WriteLine("Item deletado com sucesso!");
  }
  
  public static void SolicitarConsulta() {
    Console.WriteLine("\n=(^-^)= Agendar consulta =(^-^)=");
    Console.WriteLine("");
    Console.WriteLine("Confirmar solicitação? (s/n)");
    string s = Console.ReadLine();
    if (s == "s") {
      Consulta c = new Consulta();
      double valor = 0;
      
      IEnumerable<ItemConsulta> itemids = NItemConsulta.Listar().Where(i => NGato.Procurar(i.IdGato).IdCliente == cliente);
      foreach (ItemConsulta obj in itemids) {
        valor += obj.Valor;
        c.IdGato = obj.IdGato;
      }
      
      c.Total = valor;
      c.Status = "Em aberto";
      c.Data = DateTime.Now;

      NConsulta.Criar(c);

      Console.WriteLine("Consulta marcada com sucesso!");
    }
  }
  public static void VerConsultas() {
    Console.WriteLine("\n=(^-^)= Suas consultas =(^-^)=");
    Console.WriteLine("");

    IEnumerable<Consulta> cons = NConsulta.Listar().Where(i => NGato.Procurar(i.IdGato).IdCliente == cliente);
    foreach (Consulta obj in cons) Console.WriteLine(obj);
  }

  public static void AtualizarCadastro() {
    Console.WriteLine("\n=(^-^)= Atualizar dados =(^-^)=");
    Console.WriteLine("");

    Console.WriteLine("Informe o novo nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Informe o novo endereço:");
    string end = Console.ReadLine();
    Console.WriteLine("Informe o novo telefone:");
    string tel = Console.ReadLine();
    Console.WriteLine("Informe o novo CPF:");
    string cpf = Console.ReadLine();

    Cliente c = new Cliente();
    c.IdUsuario = sessaoAtual.Id;
    c.Id = cliente;
    c.Nome = nome;
    c.Endereco = end;
    c.Telefone = tel;
    c.CPF = cpf;

    NCliente.Atualizar(c);

    Console.WriteLine("Informações atualizadas com sucesso!");
  }
  public static void VerDados() {
    Console.WriteLine("\n" + NCliente.Procurar(cliente));
  }
  
  public static bool Login() {
    Console.WriteLine("Usuário:");
    string nome = Console.ReadLine();
    Console.WriteLine("Senha:");
    string senha = Console.ReadLine();
    Usuario u = NUsuario.Validar(nome, senha);
    if (u != null) {
      sessaoAdm = u.Admin;
      sessaoAtual = NUsuario.Procurar(u.Id);
      if (!sessaoAdm) cliente = NCliente.ProcurarUser(sessaoAtual.Id).Id;
      Console.WriteLine("Sessão iniciada!\n");
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
    
    Console.WriteLine("Cliente cadastrado com sucesso!\n");
  }
  
}