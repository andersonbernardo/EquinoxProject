<template>
<form>
    <div class="form-check"> 
        <input type="radio" name="exchangeOrMargin" v-model="exchangeOrMargin" class="form-check-input"  value="exchange" id="exchange">
        <label class="form-check-label" for="exchange">Exchange</label>
        <input type="radio" name="exchangeOrMargin" class="form-check-input" v-model="exchangeOrMargin" value="margin" id="margin">
        <label class="form-check-label" for="margin">Margin</label>        
    </div>   
    <div class="form-group">        
        <select v-on:change="change" v-model="orderType" class="form-control form-control-sm">
            <option v-for="type in types" v-bind:key="type.value" v-bind:value="type.value">
                    {{type.viewValue}}
            </option>
        </select>                  
    </div>
    <div class="form-group">   
        <input type="text" class="form-control" v-model="preco" placeholder="Preço" aria-label="Preço" required> 
        <MostrarErro :mensagem.sync="erros.preco" v-if="erros.preco.length > 0" ></MostrarErro>          
    </div>    
    <div class="form-group">             
        <input type="text" class="form-control" placeholder="Quantidade" aria-label="Quantidade" >                          
    </div>
    <div class="form-group" v-bind:class="{'hidden': !oco}" >             
        <input type="text" class="form-control" placeholder="oco stop" aria-label="Oco stop" >                          
    </div> 
    <div class="form-check" v-bind:class="{'hidden': orderType !== 'limit'}">
        <input type="checkbox" name="oco" v-model="oco" class="form-check-input" value="oco" id="oco">
        <label class="form-check-label" for="oco">OCO</label>
        <input type="checkbox" name="hidden" class="form-check-input" value="hidden" id="hidden">
        <label class="form-check-label" for="margin">HIDDEN</label>
        <input type="checkbox" name="post-only" class="form-check-input" value="post-only" id="post-only">
        <label class="form-check-label" for="post-only">POST ONLY</label>  
    </div> 
    <div class="form-check" v-bind:class="{'hidden': orderType !== 'stop limit'}">   
        <input type="checkbox" name="hidden" formControlName="is_hidden" class="form-check-input" value="hidden" id="hidden">
        <label class="form-check-label" for="margin">HIDDEN</label>    
    </div>     
  
    <button type="button" v-on:click="comprar" class="btn btn-success">Exchange Comprar</button>
    <button type="button" v-on:click="vender" class="btn btn-danger">Exchange Vender</button>    
</form>
</template>

<script>

import MostrarErro from '../helpers/mostrar-erros-form.vue'

export default {   
   
    
    data() {
        return {
            types: [
                { value: 'limit', viewValue: 'Limit' },
                { value: 'market', viewValue: 'Market' },
                { value: 'stop', viewValue: 'Stop' },
                { value: 'stop limit', viewValue: 'Stop Limit' },
                { value: 'trailing stop', viewValue: 'Trailing stop' },
                { value: 'fok', viewValue: 'Fill or Kill' }
            ],
            erros:{
                preco: ""
            },
            preco:null,
            orderType: 'limit',
            oco:false,
            exchangeOrMargin: 'exchange'
        }
    },
    methods: {
        vender:function(e) {
            console.log(this.preco);
        },
        comprar:function(e) {
            this.validaForm();
        },
        change: function() {
            console.log(this.orderType);
        },
        validaForm: function() {                        
            
            if(this.preco === null || this.preco < 0){
                this.erros.preco = "Preco é obrigatório"
            }else {
                this.erros.preco = "";
            }

            console.log(this.erros.preco);
        }
    },
    components: {
        MostrarErro   
    }
}
</script>

<style>
</style>
