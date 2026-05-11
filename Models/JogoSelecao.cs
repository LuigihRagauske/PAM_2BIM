using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaApi.Models
{
    public class JogoSelecao
    {
        public int JogoId { get; set; }
        public int SelecaoId { get; set; }
        public int Golsa { get; set; }
        public int GlosProrrogacao { get; set; }
        public int GolsaDecisaoPenaltis { get; set; }

        public Jogo JogoIdNavegacao { get; set; }

        public Selecao SelecaoIdNavegacao { get; set; }
    }
}