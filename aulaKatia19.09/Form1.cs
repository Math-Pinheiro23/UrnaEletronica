using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aulaKatia19._09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string numero = "";
        Candidato alguem;
        Candidato[] lista = new Candidato[4];
        int branco = 0, nulo = 0;

        private void insereCandidato ()
        {
            alguem = new Candidato();
            alguem.Numero = 12;
            alguem.Nome = "Antonio Silva";
            alguem.Turma = "1º ADS";
            alguem.Foto = "antonio.jfif";
            lista[0] = alguem;

            alguem = new Candidato();
            alguem.Numero = 23;
            alguem.Nome = "Joana Lima";
            alguem.Turma = "1º ADS";
            alguem.Foto = "joana.jpg";
            lista[1] = alguem;

            alguem = new Candidato();
            alguem.Numero = 34;
            alguem.Nome = "Frederico Ferreira";
            alguem.Turma = "1º ADS";
            alguem.Foto = "frederico.jpg";
            lista[2] = alguem;

            alguem = new Candidato();
            alguem.Numero = 45;
            alguem.Nome = "Vivian Almeida";
            alguem.Turma = "1º ADS";
            alguem.Foto = "vivian.jfif";
            lista[3] = alguem;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNum1.Enabled = false; // desabilita o campo de texto
            txtNum2.Enabled = false;
            btnConfirma.Enabled = false; // desabilita o botão confirma
            lblMensagem.Visible = false; //Panel ocultada
            insereCandidato();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Preenche("1");
            tecla();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Preenche("2");
            tecla();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Preenche("3");
            tecla();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Preenche("4");
            tecla();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Preenche("5");
            tecla();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Preenche("6");
            tecla();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Preenche("7");
            tecla();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Preenche("9");
            tecla();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Preenche("0");
            tecla();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Preenche("8");
            tecla();
        }
        private void tecla()
        {

            SoundPlayer som = new SoundPlayer(@"C:\Users\Math2\source\repos\urna.proj\som\tecla.wav");
            som.Play();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            SoundPlayer som = new SoundPlayer(@"C:\Users\Math2\source\repos\urna.proj\som\urna.wav");
            som.Play();
            int valido = 0;
            for (int i = 0; i < 4; i++)
            {
                if (int.Parse(numero) == lista[i].Numero)
                {
                    lista[i].Voto++;
                    valido = 1;
                }
            }
            if (numero == "Branco")
            {
                branco++;
            }
            else
            {
                if (valido == 0)
                {
                    nulo++;
                }
            }
            corrige();
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            numero = "Branco";
            lblMensagem.Visible = true;
            btnConfirma.Enabled = true;
            lblCandidato.Text = "VOTO EM BRANCO";
        }

        private void corrige()
        {
            txtNum1.Text = null;
            txtNum2.Text = null;
            lblCandidato.Text = null;
            lblTurma.Text = null;
            lblMensagem.Visible = false;
            btnConfirma.Enabled=false;
            btnConfirma.Enabled = false;
            numero = "";
            pxFoto.BackgroundImage = null;
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            corrige();
        }

        private void Preenche(string n)
        {
            if (numero.Length == 0)
            {
                txtNum1.Text = n;
                numero += n; // numero=numero+n
            }
            else
            {
               
                    txtNum2.Text = n;
                    numero += n; // numero=numero+n
                    for(int i=0; i<4; i++)
                {
                    if(Convert.ToInt32(numero) == lista[i].Numero)
                    {
                        lblCandidato.Text = lista[i].Nome;
                        lblTurma.Text = lista[i].Turma;
                        pxFoto.BackgroundImage = Image.FromFile(@"C:\Users\Math2\source\repos\urna.proj\imagens\" + lista[i].Foto);
                        i = 3;
                    }
                    else
                    {
                        lblCandidato.Text = "VOTO NULO";
                    }
                    lblMensagem.Visible = true;
                    btnConfirma.Enabled = true;
                }
            }           
        }
    }
}
