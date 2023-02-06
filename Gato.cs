using System;
using System.Collections.Generic;

public class Gato : IComparable<Gato> {
  public int Id {get; set;}
  public int IdCliente {get; set;}
  public string Nome {get; set;}
  public string Cor {get; set;}
  public double Peso {get; set;}
  public double Idade {get; set;}

  public int CompareTo(Gato obj) {
    return Nome.CompareTo(obj.Nome);
  }

  public override string ToString() {
    return $"[Dados do gato]
    ID: {this.Id}
    ID Dono: {this.IdCliente}
    Nome: {this.Nome}
    Cor: {this.Cor}
    Peso: {this.Peso} kg
    Idade: {this.Idade} anos
    ";
  }
}