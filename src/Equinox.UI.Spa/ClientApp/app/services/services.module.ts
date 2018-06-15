import { WebSocketServiceService } from './../cross-cutting/web-socket-service.service';

import { NgModule } from "@angular/core";

@NgModule({
	imports: [],
	providers: [WebSocketServiceService],
	declarations: [],
	exports: []
})
export class ServicesModule {
	constructor(		
		parentModule: ServicesModule
	) {}
}