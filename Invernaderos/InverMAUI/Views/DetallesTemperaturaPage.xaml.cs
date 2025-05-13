using DTOs;
using InverMAUI.VM;

namespace InverMAUI.Views;

public partial class DetallesTemperaturaPage : ContentPage
{
	public DetallesTemperaturaPage(ClsTemperaturasConNombreInvernaderoYFecha dto)
	{
		InitializeComponent();
		this.BindingContext = new TemperaturasConNombreInvernaderoYFecha(dto); // TENGO QUE CAMBIAR AQUI EL DTO conseguido antes de llegar a la pagina nueva, por llamarlo aqui -----------------------------------
	}
}