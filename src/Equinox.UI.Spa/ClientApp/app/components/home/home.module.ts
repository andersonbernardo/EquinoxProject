import { HomeComponent } from './home.component';
import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';

const ROUTE = [{path:"tradebox", component: HomeComponent}]

@NgModule({
    imports: [
        RouterModule.forChild(ROUTE)
    ],
    declarations: [HomeComponent],
    exports: [HomeComponent],
    providers: []
  })
  export class HomeModule { 

  }
