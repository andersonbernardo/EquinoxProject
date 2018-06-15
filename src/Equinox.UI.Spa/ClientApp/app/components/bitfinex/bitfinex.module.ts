import { CommonModule } from '@angular/common';
import { TradeBoxBitfinexComponent } from './trade-box.component';
import { NgModule } from "@angular/core";
import { BitfinexWebsocketService } from "../../services/bitfinex/bitfinex-websocket.service";
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


@NgModule({
    imports: [
        ReactiveFormsModule,
        FormsModule,
        CommonModule
    ],
    declarations: [TradeBoxBitfinexComponent],
    exports: [TradeBoxBitfinexComponent],
    providers: [BitfinexWebsocketService]
  })
  export class BitfinexModule { }