using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class NItemConsulta {
  private static List<ItemConsulta> itens;

  public static void Criar(ItemConsulta item) {
    int id;
    itens = Abrir();
    if (itens.Count == 0)
      id = 0;
    else
      id = itens.Max(i => i.Id);
    id++;
    item.Id = id;
    itens.Add(item);
    Salvar(itens);
  }

  public static List<ItemConsulta> Listar() {
    itens = Abrir();
    return itens.OrderBy(i => i.Valor).ThenBy(i => i.Id).ToList();
  }

  public static void Atualizar(ItemConsulta item) {
    itens = Abrir();
    ItemConsulta current = Procurar(item.Id);
    if (current != null) {
      current.IdGato = item.IdGato;
      current.IdServico = item.IdServico;
      current.Valor = item.Valor;
      Salvar(itens);
    }
  }

  public static void Deletar(ItemConsulta item) {
    ItemConsulta current = Procurar(item.Id);
    if (current != null) {
      itens.Remove(current);
      Salvar(itens);
    }
  }

  public static ItemConsulta Procurar(int id) {
    itens = Abrir();
    foreach (ItemConsulta obj in itens) {
      if (obj.Id == id) return obj;
    }
    return null;
  }

  private static string arquivo = "./itens.xml";
  private static List<ItemConsulta> Abrir() {
    try {
      return Arquivo< List<ItemConsulta> >.Abrir(arquivo);
    }
    catch (FileNotFoundException) {
      return new List<ItemConsulta>();
    }
  }
  private static void Salvar(List<ItemConsulta> obj) {
    Arquivo< List<ItemConsulta> >.Salvar(arquivo, obj);
  }
}