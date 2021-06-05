using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Baralho {
    public partial class Form1 : Form {
        Random rnd = new Random();
        Thread cadastro;
        int valor;
        int pontosJog1 = 0;
        int pontosJog2 = 0;
        int turnoJogadores=0;
        int resetTempo = 1;
        int tempo;
        //Lista de botões
        List<Button> botoes = new List<Button>();
        


        public Form1(string jogador1, string jogador2) {
            InitializeComponent();            
            jogadorLabel1.Text = jogador1;
            jogadorLabel2.Text = jogador2;
            tempo = resetTempo;
            botoes.Add(buttonCarta1);
            botoes.Add(buttonCarta2);
            botoes.Add(buttonCarta3);
            botoes.Add(buttonCarta4);
            botoes.Add(buttonCarta5);
            botoes.Add(buttonCarta6);
            botoes.Add(buttonCarta7);
            botoes.Add(buttonCarta8);
            foreach(Button bton in botoes) {
                if(jogadorLabel1.Text =="Jogador1" || jogadorLabel2.Text == "Jogador2") {
                    bton.Enabled = false;
                }
                else {
                    bton.Enabled = true;
                }
            }

        }

        //Botões:
        private void buttonCarta1_Click(object sender,EventArgs e) {    
            Inicializacao(buttonCarta1);
        }   
        private void buttonCarta2_Click(object sender,EventArgs e) {            
            Inicializacao(buttonCarta2);
        }

        private void buttonCarta3_Click(object sender,EventArgs e) {            
            Inicializacao(buttonCarta3);
        }

        private void buttonCarta4_Click(object sender,EventArgs e) {           
            Inicializacao(buttonCarta4);
        }

        private void buttonCarta5_Click(object sender,EventArgs e) {            
            Inicializacao(buttonCarta5);
        }

        private void buttonCarta6_Click(object sender,EventArgs e) {            
            Inicializacao(buttonCarta6);
        }

        private void buttonCarta7_Click(object sender,EventArgs e) {            
            Inicializacao(buttonCarta7);           
        }

        private void buttonCarta8_Click(object sender,EventArgs e) {            
            Inicializacao(buttonCarta8);
        }


        private void button1_Click(object sender,EventArgs e) {
            bool estaCadastrado = false;          
            if(jogadorLabel1.Text =="Jogador1" || jogadorLabel2.Text == "Jogador2") {
                richTextBox1.Text = "Cadastre os jogadores!";
                richTextBox2.Text = "Cadastre os jogadores!";
            }
            else{
                 estaCadastrado = true;
            } 
        }
        //Fecha o forms1 e abre o cadastro forms2
        private void button2_Click(object sender,EventArgs e) {
            this.Close();
            cadastro = new Thread(newCadastro);
            cadastro.SetApartmentState(ApartmentState.STA);
            cadastro.Start();      
        
        }
        //Troca o turno dos jogadores
        private void mudaTurnoJogadores(int turno) {
            turnoJogadores = (turno > 0) ? turnoJogadores = 0 : turnoJogadores = 1;            
            Console.WriteLine("É a vez do jogador {0}", turnoJogadores+1);
        }
        //Acrescenta os pontos dos jogadores
        private void acrescentaPontosJogadores(int turno, int valor) {
            if(turno > 0) {
                pontosJog2 += valor;
                richTextBox2.Text = "Pontuação atual: \n\n";
                richTextBox2.AppendText("Pontos: "+pontosJog2);
            }
            else {
                pontosJog1 += valor;
                richTextBox1.Text = "Pontuação atual:\n\n ";
                richTextBox1.AppendText("Pontos: " + pontosJog1);
            }
        }
        //Faz com que todas as funções sejam executadas para não ocupar muito espaço
        private void Inicializacao(Button botao) {
            valor = rnd.Next(1,10);
            Console.WriteLine(valor);
            ColocaCartaAleatoria(valor,botao);
            mudaTurnoJogadores(turnoJogadores);
            acrescentaPontosJogadores(turnoJogadores,valor);
            VerificaPontos(pontosJog1,pontosJog2);
            timer1.Start();
            tempo += 1;
        }

        private void VerificaPontos(int jogador1, int jogador2) {
            if(jogador1 == 21) {
                richTextBox1.Text = "O jogador: " + jogadorLabel1.Text + " pois bateu exatamente 21";
                richTextBox2.Text = "O jogador: " + jogadorLabel1.Text + " pois bateu exatamente 21";
            }
            else if( jogador2 ==21) {
                richTextBox1.Text = "O jogador: " + jogadorLabel2.Text + " pois bateu exatamente 21";
                richTextBox2.Text = "O jogador: " + jogadorLabel2.Text + " pois bateu exatamente 21";
            }else if( jogador1 >21 && jogador2 > 21) {
                VerificaPontos21(jogador1,jogador2);
            }
            
        }

        private void VerificaPontos21(int valor1, int valor2) {
            int pontos1 = valor1 - 21;
            int pontos2 = valor2 - 21;
            if(pontos1 < pontos2) {
                richTextBox1.Text = "O jogador: " + jogadorLabel1.Text + " ganhou pois tem a pontuação" +
                    " mais proxima de 21";
            }else if(pontos2 < pontos1) {
                richTextBox2.Text = "O jogador: " + jogadorLabel2.Text + " ganhou pois tem a pontuação" +
                                    " mais proxima de 21";
            }else if(pontos1 == pontos2) {
                richTextBox1.Text = "Empate!";
                richTextBox2.Text = "Empate!";
            }
        }
        
            //Chama o forms 2
        private void newCadastro() {
                Application.Run(new Form2());
        }

        private void ColocaCartaAleatoria(int valor, Button botao) {            
            switch(valor) {                
                case 1:
                    botao.BackgroundImage = Properties.Resources.a_c;                                      
                   
                    break;
                case 2:
                    botao.BackgroundImage = Properties.Resources.c2_c;
                    
                    break;
                case 3:
                    botao.BackgroundImage = Properties.Resources.c3_c;
                    
                    break;
                case 4:
                    botao.BackgroundImage = Properties.Resources.c4_c;
                   
                    break;
                case 5:
                    botao.BackgroundImage = Properties.Resources._5_c;
                    
                    break;
                case 6:
                    botao.BackgroundImage = Properties.Resources._6_c;
                    
                    break;
                case 7:
                    botao.BackgroundImage = Properties.Resources._7_c;
                    
                    break;
                case 8:
                    botao.BackgroundImage = Properties.Resources._8_c;
                   
                    break;
                case 9:
                    botao.BackgroundImage = Properties.Resources._9_c;
                   
                    break;
                case 10:
                    botao.BackgroundImage = Properties.Resources._10_c;
                   
                    break;

            }
        }

        private void timer1_Tick(object sender,EventArgs e) {
            tempo--;
            Console.WriteLine(tempo);
            if(tempo == 0) {
                timer1.Stop();
                tempo = resetTempo;
                foreach(Button bton in botoes) {
                    bton.BackgroundImage = Properties.Resources.Verso;
                }
            }
        }

        private void timer2_Tick(object sender,EventArgs e) {

        }
    }
}
