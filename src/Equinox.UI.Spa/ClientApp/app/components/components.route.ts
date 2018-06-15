
import { Routes, RouterModule } from '@angular/router';

const LAYOUT_ROUTES: Routes = [
	{
		path: '',
		loadChildren: './tradebox/tradebox.module#TradeBoxModule'
	},
	{
		path: 'tradebox',
		loadChildren: './home/home.module#HomeModule'
	},
	// 404 Page Not Found
	{ path: '**', redirectTo: '' }
];



export const ComponentRoutes = RouterModule.forChild(LAYOUT_ROUTES);