using DataBinding.DataObject.Models;

namespace DataBinding.DataObject
{
    public partial class MainPage : ContentPage
    {

        public Contador contador;
        public MainPage()
        {
            InitializeComponent();
            contador = new Contador();
            BindingContext = contador;
            ConteoLabel.Text = contador.Conteo.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            contador.Reiniciar();
           ConteoLabel.Text = contador.Conteo.ToString();

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            contador.Contar();
           ConteoLabel.Text = contador.Conteo.ToString();


        }
    
       }
    
    }

