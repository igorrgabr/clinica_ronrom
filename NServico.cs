using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Modelo;

namespace Negocio {
  static class NServico {
    private static List<Servico> servicos;
  
    public static void Criar(Servico s) {
      int id;
      servicos = Abrir();
      if (servicos.Count == 0)
        id = 0;
      else
        id = servicos.Max(i => i.Id);
      id++;
      s.Id = id;
      servicos.Add(s);
      Salvar(servicos);
    }
  
    public static List<Servico> Listar() {
      servicos = Abrir();
      return servicos.OrderBy(i => i.Nome).ThenBy(i => i.Valor).ToList();
    }
  
    public static void Atualizar(Servico s) {
      servicos = Abrir();
      Servico current = Procurar(s.Id);
      if (current != null) {
        current.Nome = s.Nome;
        current.Valor = s.Valor;
        current.Descricao = s.Descricao;
        Salvar(servicos);
      }
    }
  
    public static void Deletar(Servico s) {
      Servico current = Procurar(s.Id);
      if (current != null) {
        servicos.Remove(current);
        Salvar(servicos);
      }
    }

    public static Servico Procurar(int id) {
      servicos = Abrir();
      foreach (Servico obj in servicos) {
        if (obj.Id == id) return obj;
      }
      return null;
    }

    private static string arquivo = "./servicos.xml";
    private static List<Servico> Abrir() {
      try {
        return Arquivo< List<Servico> >.Abrir(arquivo);
      }
      catch (FileNotFoundException) {
        return new List<Servico>();
      }
    }
    private static void Salvar(List<Servico> obj) {
      Arquivo< List<Servico> >.Salvar(arquivo, obj);
    }
  }
}