using System.Collections.ObjectModel;
using System.Collections.Specialized;
using DTO;
using MAUIRivals.VM;

namespace MAUIRivals.Views;

public partial class PuntuacionPage : ContentPage
{
	public PuntuacionPage()
	{
		InitializeComponent();
		
		
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var miVM = BindingContext as ListadoHeroesVillanosConPuntosVM;
		if (miVM != null)
		{
			await miVM.actualizacionLista();

        }

	}
	
}