using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using AlertDialog = Android.App.AlertDialog;

namespace Adivinha4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        TextView text_tentativas;
        TextView text_sorteado;
        EditText edit_valor;
        Button cmd_adivinhar;

        //valor inteiro
        int valor_sorteado;
        int numero_tentativas;

        //==============================================================
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainActivity);


            text_tentativas = FindViewById<TextView>(Resource.Id.text_tentativas);
            text_sorteado = FindViewById<TextView>(Resource.Id.text_sorteado);
            edit_valor = FindViewById<EditText>(Resource.Id.edit_valor);
            cmd_adivinhar = FindViewById<Button>(Resource.Id.cmd_adivinhar);

            //iniciar o jogo
            //sortear um valor
            Random rnd = new Random();
            valor_sorteado = rnd.Next(0, 1000);
            text_sorteado.Text = valor_sorteado.ToString();

            //iniciar tentativas
            numero_tentativas = 0;


            //evento click do cmd_click

            cmd_adivinhar.Click += Cmd_adivinhar_Click;

        }

        //==============================================================
        private void Cmd_adivinhar_Click(object sender, EventArgs e)
        {
            //analisa os dados inseridos versus o valor sorteado

            if (edit_valor.Text == "") return;

            string mensagem;
            int valor_inserido = int.Parse(edit_valor.Text);
            if(valor_inserido < valor_sorteado)
            {
                mensagem = "O valor inserido é inferior ao sorteado.";
                numero_tentativas++;
            }
            else if(valor_inserido > valor_sorteado)
            {
                mensagem = "O valor inserido é superior ao sorteado.";
                numero_tentativas++;
            }
            else
            {
                //acertou

                mensagem = "Acertou.";

            }
            text_tentativas.Text = "Tentativas: " + numero_tentativas.ToString();

            AlertDialog.Builder caixa = new AlertDialog.Builder(this);
            caixa.SetTitle("Adivinha o Número");
            caixa.SetMessage(mensagem);
            caixa.SetPositiveButton("OK", delegate { });
            caixa.SetCancelable(false);
            caixa.Show();

        }
    }
}