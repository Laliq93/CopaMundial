import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';
//import { AgregarCiudadComponent } from './components/agregar-ciudad/agregar-ciudad.component';
//import { EditarCiudadComponent } from './components/editar-ciudad/editar-ciudad.component';
//import { ConsultarCiudadComponent } from './components/consultar-ciudad/consultar-ciudad.component';
//import { DetalleCiudadComponent } from './components/detalle-ciudad/detalle-ciudad.component';

const routes: Routes = [

  //{ path: 'agregarCiudad', component: AgregarCiudadComponent},
  //{ path: 'editarCiudad', component: EditarCiudadComponent},
  //{ path: 'consultarCiudad', component: ConsultarCiudadComponent},
  //{ path: 'detalleCiudad', component: DetalleCiudadComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
  
})
export class Modulo02RoutingModule {


 }
