import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComponentRoutes } from './components/components.route';


@NgModule({
	imports: [ComponentRoutes,  RouterModule.forRoot([])],
	exports: [RouterModule]
})
export class AppRoutingModule {}
