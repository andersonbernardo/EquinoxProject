import { OrderBitfinex } from './model/OrderBitfinex';
import { Component, Type, ViewChild, ElementRef, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl  } from '@angular/forms';


@Component({
    selector: 'trade-box-bitfinex',
    templateUrl: './trade-box.component.html',
    styleUrls: ['./trade-box.component.css']
})
export class TradeBoxBitfinexComponent implements OnInit {
    exchangeOrMargin = 'exchange';
    @ViewChild('botaoBuy') botaoBuy: ElementRef;
    @ViewChild('botaoSell') botaoSell: ElementRef;
    form: FormGroup;
    selectedValue = 'limit';
    showOco = true;
    ocoChecked = false;
    showAmountOco = this.ocoChecked;
    order: OrderBitfinex = new OrderBitfinex();


    constructor(private formBuilder: FormBuilder){}

    ngOnInit() {        
        this.form = this.formBuilder.group({
         // symbol: [null],
          amount: new FormControl(this.order.amount, [Validators.required]),
          price: new FormControl(this.order.price,  [Validators.required]),
          // side: [null],
          is_hidden: new FormControl(this.order.is_hidden)
        //    is_postonly: [null],
        //    ocoorder: [null],
        //    type: [null],
        //    buy_price_oco: [null],
          // sell_price_oco: [null],
          // request: [null],
          // nonce: [null]
          //exchange_margin: [null]
        });
     }

    isFieldValid(field: string) {        
        let formget = this.form.get(field);       



        if(formget != null){                         
            console.log(formget.valid)

            return !formget.valid;
            
            
        }
        else {
            console.log("else");
        }       
        
        return false;
    }   
    
    validateAllFormFields(formGroup: FormGroup) {
        Object.keys(formGroup.controls).forEach(field => {
            const control = formGroup.get(field);
            if (control instanceof FormControl) {
            control.markAsTouched({ onlySelf: true });
            } else if (control instanceof FormGroup) {
            this.validateAllFormFields(control);
            }
        });
    }   

    types = [
        { value: 'limit', viewValue: 'Limit' },
        { value: 'market', viewValue: 'Market' },
        { value: 'stop', viewValue: 'Stop' },
        { value: 'stop limit', viewValue: 'Stop Limit' },
        { value: 'trailing stop', viewValue: 'Trailing stop' },
        { value: 'fok', viewValue: 'Fill or Kill' }
     ];

    changeExchange() {
        this.botaoBuy.nativeElement.textContent = 'Exchange comprar';
        this.botaoSell.nativeElement.textContent = 'Exchange vender';
    }

    changeMargin() {
        this.botaoBuy.nativeElement.textContent = 'Margin comprar';
        this.botaoSell.nativeElement.textContent = 'Margin vender';
    }   



    onBuy(model: OrderBitfinex, isValid: boolean) {        
        
        console.log(model, isValid);
    }

}