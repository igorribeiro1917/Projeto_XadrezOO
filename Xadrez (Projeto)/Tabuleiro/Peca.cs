using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal  abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QteMovimento { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            QteMovimento = 0;
        }
        public void incrementarQteMovimento()
        {
            this.QteMovimento++;
        }
        public void decrementarQteMovimento()
        {
            this.QteMovimento--;
        }
        public bool existeMovimentoPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i < tab.linhas; i++)
            {
                for(int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();


    }
}
