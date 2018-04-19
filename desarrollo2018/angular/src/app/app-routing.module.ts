import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
//import { DetalleComponent } from './detalle/detalle.component';
const appRoutes : Routes = [
    //{path:'detalle', component:DetalleComponent }
];
@NgModule({
  imports: [ RouterModule.forRoot(appRoutes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule { }
// Documentacion: https://angular.io/tutorial/toh-pt5
