using DTOs;
using InverMAUI.VM;

namespace InverMAUI.Views;

public partial class DetallesTemperaturaPage : ContentPage
{
	public DetallesTemperaturaPage(ClsTemperaturasConNombreInvernaderoYFecha dto)
	{
		InitializeComponent();
		this.BindingContext = new TemperaturasConNombreInvernaderoYFecha(dto);
	}
}