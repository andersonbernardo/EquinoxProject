import { NavMenuComponent } from './navmenu.component';

import { NgModule } from "@angular/core";
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';


@NgModule({
    imports: [
        HttpModule,
        RouterModule
    ],
    declarations: [NavMenuComponent],
    exports: [NavMenuComponent],
    providers: []
  })
  export class NavMenuModule { 
      
  }
