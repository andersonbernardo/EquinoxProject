import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';

import { Injectable } from '@angular/core';

@Injectable()
export class WebSocketServiceService {

  constructor() { }

    private socket: Subject<any>;
    public connect(url: string): Subject<any> {
    if (!this.socket) {
      this.socket = this.create(url);
    }
    return this.socket;
  }

  private create(url: string): Subject<any> {
    const ws = new WebSocket(url);
    const observable = Observable.create(
        (obs: Observer<any>) => {
            ws.onmessage = obs.next.bind(obs);
            ws.onerror = obs.error.bind(obs);
            ws.onclose = obs.complete.bind(obs);
            // return ws.close.bind(ws);
            return ws;
        }
    );
    const observer = {
        next: (data: any) => {
            if (ws.readyState === WebSocket.OPEN) {
                ws.send(JSON.stringify(data));
            }
        }
    };
    return Subject.create(observer, observable);
  }
}
