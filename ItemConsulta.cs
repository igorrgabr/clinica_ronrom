using System;
using System.Collections.Generic;

public class ItemConsulta : IComparable<ItemConsulta> {
  public int Id {get; set;}
  public int IdGato {get; set;}
  public int IdServico {get; set;}
  public double Valor {get; set;}

  public int CompareTo(ItemConsulta obj) {
    return Valor.CompareTo(obj.Valor);
  }

  public override string ToString() {
    return $"[Item da Consulta]
    ID: {this.Id}
    ID Gato: {this.IdGato}
    ID Serviço: {this.IdServico}
    Valor: R$ {this.Valor:0.00}
    ";
  }
}