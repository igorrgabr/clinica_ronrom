using System;
using System.Collections.Generic;

namespace Modelo {
  public class Servico : IComparable<Servico> {
    public int Id {get; set;}
    public string Nome {get; set;}
    public double Valor {get; set;}
    public string Descricao {get; set;}

    public int CompareTo(Servico obj) {
      return Nome.CompareTo(obj.Nome);
    }
    
    public override string ToString() {
      return $"[Dados do serviço]
      ID: {this.Id}
      Serviço: {this.Nome}
      Valor: R$ {this.Valor:0.00}
      Descrição: {this.Descricao}\n
      ";
    }
  }
}