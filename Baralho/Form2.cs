using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Baralho {
    public partial class Form2 : Form {
        //Thread
        Thread jogo;
        //Variáveis        
        string connectionString;
        string nickJogador1;
        string nickJogador2;
        public Form2() {
            InitializeComponent();
        }

        private void salvarDados_Click(object sender,EventArgs e) {
            connectionString= "server=remotemysql.com; port=3306; database=v9J6iJy1dR; username=v9J6iJy1dR; password=8EAT1H5Ykh ";
            MySqlConnection conexao = new MySqlConnection(connectionString);

            try {
                conexao.Open();
                MessageBox.Show("Você está conectado ao banco de dados!");
                //Envia os dados do jogador 1 e verifica com os metodos abaixo
                verificaSeEstaNull(textBoxNome1,textBoxApelido1,textBoxIdade1);
                //pega o apelido do jogador
                verificaChar(textBoxIdade1);
                nickJogador1 = textBoxApelido1.Text;
                string comando = "INSERT INTO jogadores (nome,apelido,idade)"
                                                +"VALUES('"+textBoxNome1.Text+"','"+textBoxApelido1.Text+"',"+textBoxIdade1.Text+")";
                MessageBox.Show(comando);
                MySqlCommand sqlComando = new MySqlCommand(comando,conexao);
                int value = sqlComando.ExecuteNonQuery();
                Console.WriteLine("ExecuteNonQuery : " + value);

                //Envia os dados do jogador 2
                verificaSeEstaNull(textBoxNome2,textBoxApelido2,textBoxIdade2);
                verificaChar(textBoxIdade2);
                //pega o apelido do jogador
                nickJogador2 = textBoxApelido2.Text;
                comando = "INSERT INTO jogadores (nome,apelido,idade)"
                                                + "VALUES('" + textBoxNome2.Text + "','" + textBoxApelido2.Text + "'," + textBoxIdade2.Text + ")";
                MessageBox.Show(comando);
                MySqlCommand sqlComando2 = new MySqlCommand(comando,conexao);
                value = sqlComando2.ExecuteNonQuery();
                Console.WriteLine("ExecuteNonQuery : " + value);


                conexao.Close();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            this.Close();
            jogo = new Thread(newJogo);
            jogo.SetApartmentState(ApartmentState.STA);
            jogo.Start();
        }
     
        //Verifica se o texto está ou não vazio
        private void verificaSeEstaNull(TextBox nome, TextBox apelido, TextBox idade) {
            if(nome.Text == "" || apelido.Text =="" || idade.Text=="")  {
                Console.WriteLine("estou aqui");
                throw new Exception("Os cadastros contem um ou mais espaços vazios!");
            
            }        
        }

        //Verifica se o texto tem algum char
        private void verificaChar(TextBox idade) {
            string texto = "";
            //converte o texto do textbox em array do tipo char
            char[] dados = idade.Text.ToCharArray();
            foreach( char c in dados.AsEnumerable()) {
                if(Char.IsDigit(c)) {
                    texto += c;
                }
                else {
                    throw new Exception("Digite apenas números na no campo idade!");
                }
            }
            idade.Text = texto;
        }
        //Chama o Form1
        private void newJogo() {
            Application.Run(new Form1(nickJogador1, nickJogador2));
        }

     
    }
}
