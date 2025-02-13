﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
        
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public bool existePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }


        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça neste lugar!!");
            }
            else
            {
                pecas[pos.Linha, pos.Coluna] = p;
                p.posicao = pos;
            }       
        }
        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            else
            {
                Peca aux = peca(pos);
                aux.posicao = null;
                pecas[pos.Linha, pos.Coluna] = null;
                return aux;
            }
        }
        public bool posicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ValidarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!!!");
            }
        }



    }
}
