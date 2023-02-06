using System;
using System.Collections.Generic;

public class Cliente : IComparable<Cliente> {
  public int Id {set; get;}
  public int IdUsuario {set; get;}
  public string Nome {set; get;}
  public string Endereco {set; get;}
  public string Telefone {set; get;}
  public string CPF {set; get;}

  public int CompareTo(Cliente obj) {
    return Nome.CompareTo(obj.Nome);
  }

  public override string ToString() {
    return $"[Dados do cliente]
    ID: {this.Id}
    ID Usuário: {this.IdUsuario}
    Nome: {this.Nome}
    CPF: {this.CPF}
    Endereço: {this.Endereco}
    Telefone: {this.Telefone}
    ";
  }
}