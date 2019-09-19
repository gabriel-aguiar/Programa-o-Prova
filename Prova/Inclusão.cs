using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Trabalho_programação
{
    class Inclusao
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public string Data { get; set; }
        public double Quantidade { get; set; }
        public float Andarestoque { get; set; }

        public void Produtos(double soma)
        {
            Quantidade = soma;
        }

        public void alteraNome(string novoproduto)
        {
            Produto = novoproduto;
        }
        public void alteraData(string novadata)
        {
            Data = novadata;
        }
        public void alteraEstoque(string novo)
        {
            Andarestoque = float.Parse(novo);
        }

        public override string ToString()
        {
            return "Id:" + Id
                + ", Produto: "
                + Produto
                 + " Data: " + Data +
                " Andar do estoque: " + Andarestoque
                + ", Quantidade de produto: "
                + Quantidade;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Inclusao objAsPart = obj as Inclusao;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(Inclusao other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }
    }
}