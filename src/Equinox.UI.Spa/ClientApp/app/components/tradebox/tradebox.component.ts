import { BitfinexWebsocketService } from './../../services/bitfinex/bitfinex-websocket.service';
import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'trade-box',
    templateUrl: './tradebox.component.html'
 
})
export class TradeBoxComponent {
  subscribedChannel: any;
  ticker: any;
  @Input() symbol: string = "";
  symbolName: string = "";
    
    constructor(){

    }

    ngOnInit() {
      //   this.bitfinexWebsocketService._messages.timeoutWith(10000, Observable.throw(new Error('Boom!'))).retry(2).subscribe(x => {
      //     const retorno = JSON.parse(x);
      //     if (retorno.event === 'info') {
      //       this.bitfinexWebsocketService.subscribeTicker(this.symbol);
      //     } else if (retorno.event === 'subscribed') {
      //       this.subscribedChannel = retorno;
      //     } else if (retorno.event === 'error') {
      //       console.log(retorno);
      //     } else {
      //       this.ticker = retorno;
      //     }
    
      //     console.log(retorno);
    
      //   }, error => {
      //     console.log(error);
      //     console.log('Problemas para se conectar');
      //   }, () => {
      //       console.log('complete');
      //    }
      //  );
    
       //this.symbolName = this.getSymbolName();
    }
    
    private getSymbolName() {
      switch (this.ticker) {
        case "tBTCUSD":
          return "BTCUSD";
      }
    }

}