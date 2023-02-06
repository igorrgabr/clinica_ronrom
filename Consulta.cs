using System;
using System.Collections.Generic;

namespace Modelo {
  public class Consulta : IComparable<Consulta> {
    public int Id {get; set;}
    public int IdGato {get; set;}
    public double Total {get; set;}
    public string Status {get; set;}
    public DateTime Data {get; set;}

    public int CompareTo(Consulta obj) {
      return Total.CompareTo(obj.Total);
    }
  
    public override string ToString() {
      return $"[Dados da consulta]
      ID: {this.Id}
      Status: {this.Status}
      Data: {this.Data.Date.ToString("d")}
      Valor total: R$ {this.Total:0.00}\n
      ";
    }
  }
}