
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { WebSocketServiceService } from './../../cross-cutting/web-socket-service.service';

@Injectable()
export class BitfinexWebsocketService {
  public _messages: Subject<any>;

  constructor(private webSocketServiceService: WebSocketServiceService) {
    this._messages = <Subject<any>>this.webSocketServiceService.connect('wss://api.bitfinex.com/ws/2').map((response: MessageEvent): any => {        
        return response.data;
    }, () => {{
      console.log();
    }});
  }

  subscribeTicker(symbol: string) {
    this._messages.next(
      {
        'event': 'subscribe',
        'channel': 'ticker',
        'pair': symbol
      }
    );
  }

  unSubscribeTicker(channelId: number) {
    this._messages.next(
      {
        'event': 'unsubscribe',
        'chanId': channelId
      }
    );
  }
}
