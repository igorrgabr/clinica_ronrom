using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class NCliente {
  private static List<Cliente> clientes;

  public static void Criar(Cliente c) {
    int id;
    clientes = Abrir();
    if (clientes.Count == 0)
      id = 0;
    else
      id = clientes.Max(i => i.Id);
    id++;
    c.Id = id;
    clientes.Add(c);
    Salvar(clientes);
  }

  public static List<Cliente> Listar() {
    clientes = Abrir();
    return clientes.OrderBy(c => c.Nome).ThenBy(c => c.Id).ToList();
  }

  public static void Atualizar(Cliente c) {
    clientes = Abrir();
    Cliente current = Procurar(c.Id);
    if (current != null) {
      current.Nome = c.Nome;
      current.Endereco = c.Endereco;
      current.Telefone = c.Telefone;
      current.CPF = c.CPF;
      Salvar(clientes);
    }
  }

  public static void Deletar(Cliente c) {
    Cliente current = Procurar(c.Id);
    if (current != null) {
      clientes.Remove(current);
      Salvar(clientes);
    }
  }

  public static Cliente Procurar(int id) {
    clientes = Abrir();
    foreach (Cliente obj in clientes) {
      if (obj.Id == id) return obj;
    }
    return null;
  }

  public static Cliente ProcurarUser(int id) {
    clientes = Abrir();
    foreach (Cliente obj in clientes) {
      if (obj.IdUsuario == id) return obj;
    }
    return null;
  }

  private static string arquivo = "./clientes.xml";
  private static List<Cliente> Abrir() {
    try {
      return Arquivo< List<Cliente> >.Abrir(arquivo);
    }
    catch (FileNotFoundException) {
      return new List<Cliente>();
    }
  }
  private static void Salvar(List<Cliente> obj) {
    Arquivo< List<Cliente> >.Salvar(arquivo, obj);
  }
}