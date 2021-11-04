using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlesGUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Pais> listaPaises;
        public MainWindow()
        {
            InitializeComponent();
            
            Pais p1 = new Pais(1,"Chile", "América", 19458000, "Español");
            Pais p2 = new Pais(2,"Perú", "América", 20000000, "Español");
            Pais p3 = new Pais(3,"Australia", "Oceanía", 25000000, "Inglés");
            Pais p4 = new Pais(4,"Francia", "Europa", 21000000, "Francés");
            Pais p5 = new Pais(5,"Brasil", "América", 20500000, "Portugués");


            
            listaPaises = new List<Pais>() {p1,p2,p3,p4,p5};
            listBoxEjemplo.ItemsSource = listaPaises;
            comboBoxPais.ItemsSource = listaPaises;
        }

        private void buttonItems_Click(object sender, RoutedEventArgs e)
        {
            long numeroGrande = 1000;
            int numeroChico = (int)numeroGrande;

            //casting o casteo
            Pais seleccion = (Pais)listBoxEjemplo.SelectedItem;
            //Devuelve el objeto seleccionado (en éste caso País), de no existir selección, retorna null
            //Object o null

            Console.WriteLine(typeof(Pais)); //ControlesGUI.Pais

            try
            {
                if (seleccion.GetType() == typeof(Pais)) //ControlesGUI.Pais == ControlesGUI.Pais
                {
                    //Todo lo que se hará aquí dentro, se ejecutará solo cuando "selección" sea un objeto de tipo "Pais"
                    textBoxID.Text = seleccion.Id.ToString();
                    textBoxNombre.Text = seleccion.Nombre;
                    textBoxContinente.Text = seleccion.Continente;
                    textBoxHabitantes.Text = seleccion.Habitantes.ToString();
                    textBoxIdioma.Text = seleccion.Idioma;

                    textBoxNombre.IsEnabled = true;
                    textBoxContinente.IsEnabled = true;
                    textBoxHabitantes.IsEnabled = true;
                    textBoxIdioma.IsEnabled = true;
                }
            }
            catch(NullReferenceException ex)
            {
                Debug.WriteLine("Ha seleccionado ningún objeto de la lista.");
            }
            

            

        }

        private void comboBoxPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // sender => OBJETO COMPLETO (combo box)
            //(sender as ComboBox)

            try
            {
                Pais itemSeleccionado = (sender as ComboBox).SelectedItem as Pais;
                textBoxID.Text = itemSeleccionado.Id.ToString();
                textBoxNombre.Text = itemSeleccionado.Nombre;
                textBoxContinente.Text = itemSeleccionado.Continente;
                textBoxHabitantes.Text = itemSeleccionado.Habitantes.ToString();
                textBoxIdioma.Text = itemSeleccionado.Idioma;

                textBoxNombre.IsEnabled = true;
                textBoxContinente.IsEnabled = true;
                textBoxHabitantes.IsEnabled = true;
                textBoxIdioma.IsEnabled = true;
            }
            catch(NullReferenceException ex)
            {
                Debug.WriteLine("Nada que seleccionar");
            }
        }

        private void buttonEditar_Click(object sender, RoutedEventArgs e)
        {
            int idActual = Convert.ToInt32(textBoxID.Text);
            string nombreActual = textBoxNombre.Text;
            string continenteActual = textBoxContinente.Text;
            int habitantesActual = Convert.ToInt32(textBoxHabitantes.Text);
            string idiomaActual = textBoxIdioma.Text;

            foreach(Pais paisActual in listaPaises)
            {
                if(paisActual.Id == idActual)
                {
                    paisActual.Nombre = nombreActual;
                    paisActual.Continente = continenteActual;
                    paisActual.Habitantes = habitantesActual;
                    paisActual.Idioma = idiomaActual;
                }
            }

            listBoxEjemplo.ItemsSource = null;
            comboBoxPais.ItemsSource = null;

            listBoxEjemplo.ItemsSource = listaPaises;
            comboBoxPais.ItemsSource = listaPaises;

        }
    }
}
