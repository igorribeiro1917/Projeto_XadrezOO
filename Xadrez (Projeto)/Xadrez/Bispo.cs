using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override string ToString()
        {
            return "B";
        }
        private bool podeMover(Posicao pos)
        {
            if (tab.posicaoValida(pos) == true)
            {
                Peca p = tab.peca(pos);
                return p == null || p.cor != cor;
            }
            return false;
        } 
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //Testagem: Noroeste

            pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            while (podeMover(pos) && tab.posicaoValida(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna - 1);
            }
            //Testagem: Nordeste

            pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            while(podeMover(pos) && tab.posicaoValida(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha - 1, pos.Coluna + 1);
            }
            //Testagem: Sudeste

            pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            while(podeMover(pos) && tab.posicaoValida(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna + 1);
            }
            //Testagem: Sudoeste 

            pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            while (podeMover(pos) && tab.posicaoValida(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.definirValores(pos.Linha + 1, pos.Coluna - 1);
            }
            return mat;
        }


    }
}
