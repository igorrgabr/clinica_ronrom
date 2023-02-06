using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Modelo;

namespace Negocio {
  static class NConsulta {
    private static List<Consulta> consultas;
  
    public static void Criar(Consulta c) {
      int id;
      consultas = Abrir();
      if (consultas.Count == 0)
        id = 0;
      else
        id = consultas.Max(i => i.Id);
      id++;
      c.Id = id;
      consultas.Add(c);
      Salvar(consultas);
    }
  
    public static List<Consulta> Listar() {
      consultas = Abrir();
      return consultas.OrderBy(c => c.Data).ToList();
    }
  
    public static void Atualizar(Consulta c) {
      consultas = Abrir();
      Consulta current = Procurar(c.Id);
      if (current != null) {
        current.IdGato = c.IdGato;
        current.Total = c.Total;
        current.Status = c.Status;
        current.Data = c.Data;
        Salvar(consultas);
      }
    }
  
    public static void Deletar(Consulta c) {
      Consulta current = Procurar(c.Id);
      if (current != null) {
        consultas.Remove(current);
        Salvar(consultas);
      }
    }

    public static Consulta Procurar(int id) {
      consultas = Abrir();
      foreach (Consulta obj in consultas) {
        if (obj.Id == id) return obj;
      }
      return null;
    }

    private static string arquivo = "./consultas.xml";
    private static List<Consulta> Abrir() {
      try {
        return Arquivo< List<Consulta> >.Abrir(arquivo);
      }
      catch (FileNotFoundException) {
        return new List<Consulta>();
      }
    }
    private static void Salvar(List<Consulta> obj) {
      Arquivo< List<Consulta> >.Salvar(arquivo, obj);
    }
  }
}