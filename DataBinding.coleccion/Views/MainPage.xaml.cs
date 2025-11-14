using DataBinding.coleccion.Models;
using System.Collections.ObjectModel;

namespace DataBinding.coleccion.Views;

public partial class MainPage : ContentPage
{

	public ObservableCollection<OrigenDePaquetes> Origenes { get; }
	private OrigenDePaquetes? _origenSeleccionado = null;
	private string _nombreDelOrigen = string.Empty;
	private string _rutaDelOrigen = string.Empty;
	public OrigenDePaquetes? OrigenSeleccionado
	{
		get => _origenSeleccionado;
		set
		{
			if (_origenSeleccionado != value)
			{
				_origenSeleccionado = value;
				OnPropertyChanged(nameof(OrigenSeleccionado));
			}
		}
	}
	public string nombreDelorigen
	{
		get => _nombreDelOrigen;
		set
		{
			if (_nombreDelOrigen != value)
			{
				_nombreDelOrigen = value;
				OnPropertyChanged(nameof(_nombreDelOrigen));
			}
		}
	}
	public string RutaDelOrigen
	{
		get => _rutaDelOrigen;
		set
		{
			if( _rutaDelOrigen != value)
			{
				_rutaDelOrigen = value;
				OnPropertyChanged(nameof(RutaDelOrigen));
			}
		}
	}
	public MainPage()
	{
		InitializeComponent();
        
        OrigenSeleccionado = null;
        Origenes = new ObservableCollection<OrigenDePaquetes>();

		CargarDatos();
        BindingContext = this;
        if (Origenes.Count > 0 )
		{
			OrigenSeleccionado = Origenes[1];
		}
		
		//OrigenesListView.ItemsSource = _origenes;
		//OrigenesListView.SelectedItem = origenSeleccionado;
	}

	private void CargarDatos()
	{
		Origenes.Add(new OrigenDePaquetes
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget.org/v3/index.json",
			EstaHabilitado = false,
		});

		Origenes.Add(new OrigenDePaquetes()
		{
			Nombre = "Microsoft Visual Studio OFFline Packges",
			Origen = @"C:\Program Files(x86)\Microsoft SDKs\NuGetPackges",
			EstaHabilitado = false,
		});
	}

	private void OnAgregarButtonCliked(object sender, EventArgs e)
	{
		var origen = new OrigenDePaquetes
		{
			Nombre = "Origen de paquete",
			Origen = "URL o ruta del origen del paquete",
			EstaHabilitado = false,
		};
		Origenes.Add(origen);
		OrigenSeleccionado = origen;
    }

	private void OnDeLeteButtonClicked(object sender, EventArgs e)
	{
		
		OrigenDePaquetes seleccionado = null;
		if (OrigenSeleccionado != null)
		{
			var indice= Origenes.IndexOf(OrigenSeleccionado);
            OrigenDePaquetes? nuevoSeleccionado;
			if (Origenes.Count>1)
			{
				//has mas de un elemento
				if(indice<Origenes.Count-1)
				{
					//El elemento seleccionado no es el ultimo
					nuevoSeleccionado = Origenes[indice + 1];
				}
				else
				{
					//El elemento seleccionado es el ultimo
					nuevoSeleccionado= Origenes[indice-1];
				}
			}
			else
			{
				//solo hay un elemento
				nuevoSeleccionado = null;
			}
				Origenes.Remove(OrigenSeleccionado);
			OrigenSeleccionado = nuevoSeleccionado;
        }
		
	}

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		//OrigenDePaquetes origenSeleccionado =
		//	(OrigenDePaquetes)OrigenesListView.SelectedItem;
		if (origenSeleccionado != null)
		{
			nombreDelorigen = origenSeleccionado.Nombre;
			RutaDelOrigen = origenSeleccionado.Origen;
		}
		else
		{
			nombreDelorigen = string.Empty;
			RutaDelOrigen = string.Empty;
		}

	}

    private void OnActualizarButton_Clicked(object sender, EventArgs e)
    {

		if (origenSeleccionado != null)
		{
			origenSeleccionado.Nombre = NombreEntry.Text;
			
		}
	}
}