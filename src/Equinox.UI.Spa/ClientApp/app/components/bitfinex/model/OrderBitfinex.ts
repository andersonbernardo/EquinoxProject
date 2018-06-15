export class OrderBitfinex {
    symbol: string;
    amount: string;
    price: string;
    side: string;
    type: string;
    is_hidden: boolean;
    is_postonly: boolean;
    ocoorder: boolean;
    buy_price_oco: number;
    sell_price_oco: number;
    private exchange: string;
    request: string;
    nonce: string;
    constructor() {
        this.exchange = 'bitfinex';
    }
}