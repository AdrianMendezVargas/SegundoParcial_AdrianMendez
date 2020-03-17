using SegundoParcial_AdrianMendez.BLL;
using SegundoParcial_AdrianMendez.Entidades;
using System.ComponentModel;
using System.Windows;

namespace SegundoParcial_AdrianMendez.UI.Registro {
    /// <summary>
    /// Interaction logic for RegistroDetalle.xaml
    /// </summary>
    public partial class RegistroDetalle : Window, INotifyPropertyChanged {

        public Llamada llamada { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public RegistroDetalle() {
            InitializeComponent();
            llamada = new Llamada();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MyPropertyChanged(string propiedad) {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propiedad));
        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {

            if (int.TryParse(LlamadaIdTextBox.Text , out int llamadaId)) {
                if (ExisteEnBaseDatos()) {
                    Limpiar();
                    llamada = LlamadasBLL.Buscar(llamadaId);
                    CargarDataGrid();
                    MyPropertyChanged("llamada");
                } else {
                    MessageBox.Show("Esta llamada no existe.");
                    Limpiar();
                }
            } else {
                MessageBox.Show("Llamada Id invalido.");
            }

        }

        private void NuevoButton_Click(object sender , RoutedEventArgs e) {
            Limpiar();
        }

        private void GuardarButton_Click(object sender , RoutedEventArgs e) {

            if (!Validar()) {
                return;
            }

            bool guardado = false;

            if (llamada.LlamadaId == 0) {
                guardado = LlamadasBLL.Guardar(llamada);
            } else {
                if (!ExisteEnBaseDatos()) {
                    MessageBox.Show("Esta Llamada no existe, no se puede modificar");
                } else {
                    guardado = LlamadasBLL.Modificar(llamada);
                }

            }

            if (guardado) {
                MessageBox.Show("Guardado.");
                Limpiar();
                CargarDataGrid();
            } else {
                MessageBox.Show("Error al guardar");
            }

        }

        private void EliminarButton_Click(object sender , RoutedEventArgs e) {

            bool eliminado = false;


            if (int.TryParse(LlamadaIdTextBox.Text , out int llamadaId)) {
                if (ExisteEnBaseDatos()) {
                    Limpiar();
                    eliminado = LlamadasBLL.Eliminar(llamadaId);
                    CargarDataGrid();
                    MyPropertyChanged("llamada");
                } else {
                    MessageBox.Show("Esta llamada no existe.");
                    Limpiar();
                }
            } else {
                MessageBox.Show("Llamada Id invalido.");
            }

            if (eliminado) {
                MessageBox.Show("Eliminado.");
            } else {
                MessageBox.Show("Error al eliminar.");
            }


        }

        private void EliminarItemButton_Click(object sender , RoutedEventArgs e) {

            if (llamada.ProblemasDetalle.Count > 0 && ItemsDataGrid.SelectedIndex != -1) {


                llamada.ProblemasDetalle.RemoveAt(ItemsDataGrid.SelectedIndex);

                CargarDataGrid();
                MyPropertyChanged("llamada");

            }
        }


        private void AgregarItemButton_Click(object sender , RoutedEventArgs e) {

            if (string.IsNullOrWhiteSpace(ProblemaTextBox.Text) || string.IsNullOrWhiteSpace(SolucionTextBox.Text)) {


                MessageBox.Show("No puede haber un problema sin solución" +
                              "\nNi una solución donde no hay problemas" +
                              "\n" +
                              "\n                       -Adrian Mendez");

            } else {
                llamada.ProblemasDetalle.Add(new LlamadaDetalle() { LlamadaDetalleId = 0 , LlamadaId = llamada.LlamadaId , Problema = this.Problema , Solucion = this.Solucion });
                MyPropertyChanged("llamada");
                CargarDataGrid();
            }

            


        }

        private void CargarDataGrid() {
            ItemsDataGrid.ItemsSource = null;
            ItemsDataGrid.ItemsSource = llamada.ProblemasDetalle;
        }

        private bool ExisteEnBaseDatos() {
            Llamada llamada = LlamadasBLL.Buscar(this.llamada.LlamadaId);
            return (llamada != null);
        }

        private bool Validar() {
            bool paso = true;
            string mensaje = "Errores: \n\n";

            if (!int.TryParse(LlamadaIdTextBox.Text , out int llamadaId)) {
                paso = false;
                mensaje += "\nLlamada Id invalido";

            }
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text)) {
                paso = false;
                mensaje += "\nLa llamada debe tener una descripción";
            }

            if (paso == false) {
                MessageBox.Show(mensaje);
            }

            return paso;
        }

        private void Limpiar() {
            llamada.Descripcion = "";
            llamada.LlamadaId = 0;
            llamada.ProblemasDetalle.Clear();
            Problema = "";
            Solucion = "";

            MyPropertyChanged("llamada");
            CargarDataGrid();
        }
    }
}
