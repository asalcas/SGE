using DTOs;
using InverMAUI.VM;

namespace InverMAUI.Views;

public partial class DetallesTemperaturaPage : ContentPage
{
	public DetallesTemperaturaPage(int id, DateTime fecha)
	{
		InitializeComponent();
		this.BindingContext = new TemperaturasConNombreInvernaderoYFecha(id, fecha);
	}
}