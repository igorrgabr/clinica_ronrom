using System;
using System.Collections.Generic;

namespace Modelo {
  public class Usuario : IComparable<Usuario> {
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Senha {get; set;}
    public bool Admin {get; set;}

    public int CompareTo(Usuario obj) {
      return Nome.CompareTo(obj.Nome);
    }
    
    public override string ToString() {
      return $"[Dados da sessão atual]
      ID: {this.Id}
      Usuário: {this.Nome}\n
      ";
    }
  }
}