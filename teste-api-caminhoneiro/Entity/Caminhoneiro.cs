using System.Collections.Generic;

namespace Entity
{
    public class Caminhoneiro
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string UltimoNome { get; set; }
    }

    public class Caminhao
    {
        public int Codigo { get; set; }
        public int CodigoProprietario { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Eixos { get; set; }
    }
}

