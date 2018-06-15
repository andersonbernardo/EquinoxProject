import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TradeBoxComponent } from './tradebox.component';

import { NgModule } from "@angular/core";
import { BitfinexModule } from '../bitfinex/bitfinex.module';
import { CommonModule } from '@angular/common';
import { WebSocketServiceService } from '../../cross-cutting/web-socket-service.service';

const ROUTE = [{path:"", component: TradeBoxComponent}]

@NgModule({
    imports: [
        BitfinexModule,        
        RouterModule.forChild(ROUTE),
        ReactiveFormsModule,
        FormsModule,
        CommonModule
    ],
    declarations: [TradeBoxComponent],    
    providers: [WebSocketServiceService]
  })
  export class TradeBoxModule { }