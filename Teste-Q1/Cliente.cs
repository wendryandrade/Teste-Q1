using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_Q1
{
    class Cliente
    {
        public string nome { get; set; }
        public string CPF { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataNascimento { get; set; }

        public List<string> telefone = new List<string>();
    }
}
