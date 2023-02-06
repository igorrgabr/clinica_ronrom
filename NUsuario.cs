using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class NUsuario {
  private static List<Usuario> usuarios;

  public static Usuario Validar(string user, string password) {
    usuarios = Abrir();
    foreach (Usuario obj in usuarios) {
      if (obj.Nome == user && obj.Senha == password) return obj;
    }
    return null;
  }

  public static int Criar(Usuario u) {
    int id;
    usuarios = Abrir();
    if (usuarios.Count == 0)
      id = 0;
    else
      id = usuarios.Max(i => i.Id);
    id++;
    u.Id = id;
    usuarios.Add(u);
    Salvar(usuarios);
    return id;
  }

  public static void Atualizar(Usuario u) {
    usuarios = Abrir();
    Usuario current = Procurar(u.Id);
    if (current != null) {
      current.Senha = u.Senha;
      Salvar(usuarios);
    }
  }

  public static void Deletar(Usuario u) {
    Usuario current = Procurar(u.Id);
    if (current != null) {
      usuarios.Remove(current);
      Salvar(usuarios);
    }
  }

  public static Usuario Procurar(int id) {
    usuarios = Abrir();
    foreach (Usuario obj in usuarios) {
      if (obj.Id == id) return obj;
    }
    return null;
  }
  
  private static string arquivo = "./usuarios.xml";
  private static List<Usuario> Abrir() {
    try {
      return Arquivo< List<Usuario> >.Abrir(arquivo);
    }
    catch (FileNotFoundException) {
      return new List<Usuario>();
    }
  }
  private static void Salvar(List<Usuario> obj) {
    Arquivo< List<Usuario> >.Salvar(arquivo, obj);
  }
}