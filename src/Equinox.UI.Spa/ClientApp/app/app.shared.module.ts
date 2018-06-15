import { NavMenuModule } from './components/navmenu/navmenu.module';
import { HomeModule } from './components/home/home.module';
import { BitfinexModule } from './components/bitfinex/bitfinex.module';
import { FieldErrorDisplayComponent } from './components/shared/field-error-display/field-error-display.component';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { ServicesModule } from './services/services.module';
import { TradeBoxModule } from './components/tradebox/tradebox.module';
import { AppRoutingModule } from './app.routing';


@NgModule({
    declarations: [
        AppComponent
        
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        TradeBoxModule,
        ReactiveFormsModule,
        BitfinexModule,              
        HomeModule,
        NavMenuModule,
        AppRoutingModule   
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
