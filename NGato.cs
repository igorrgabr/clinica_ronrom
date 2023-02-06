using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Modelo;

namespace Negocio {
  static class NGato {
    private static List<Gato> gatos;
  
    public static void Criar(Gato g) {
      int id;
      gatos = Abrir();
      if (gatos.Count == 0)
        id = 0;
      else
        id = gatos.Max(i => i.Id);
      id++;
      g.Id = id;
      gatos.Add(g);
      Salvar(gatos);
    }
  
    public static List<Gato> Listar() {
      gatos = Abrir();
      return gatos.OrderBy(g => g.Nome).ThenBy(g => g.Idade).ToList();
    }
  
    public static void Atualizar(Gato g) {
      gatos = Abrir();
      Gato current = Procurar(g.Id);
      if (current != null) {
        current.IdCliente = g.IdCliente;
        current.Nome = g.Nome;
        current.Cor = g.Cor;
        current.Peso = g.Peso;
        current.Idade = g.Idade;
        Salvar(gatos);
      }
    }
  
    public static void Deletar(Gato g) {
      Gato current = Procurar(g.Id);
      if (current != null) {
        gatos.Remove(current);
        Salvar(gatos);
      }
    }

    public static Gato Procurar(int id) {
      gatos = Abrir();
      foreach (Gato obj in gatos) {
        if (obj.Id == id) return obj;
      }
      return null;
    }

    private static string arquivo = "./gatos.xml";
    private static List<Gato> Abrir() {
      try {
        return Arquivo< List<Gato> >.Abrir(arquivo);
      }
      catch (FileNotFoundException) {
        return new List<Gato>();
      }
    }
    private static void Salvar(List<Gato> obj) {
      Arquivo< List<Gato> >.Salvar(arquivo, obj);
    }
  }
}