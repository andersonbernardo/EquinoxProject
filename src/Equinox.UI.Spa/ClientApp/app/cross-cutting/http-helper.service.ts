import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class HttpHelperService {

  constructor() { }


  public  extractData(res: Response) {
    const body = res.json();

    return body || {};
  }
  public  handleErrorObservable(error: Response | any) {
    console.error(error);
    return Observable.throw(error.message || error);
  }
  public  handleErrorPromise(error: Response | any) {
    console.error(error.message || error);
    return Promise.reject(error.message || error);
  }

}

