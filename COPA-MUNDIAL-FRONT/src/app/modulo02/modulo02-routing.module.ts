import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';
import { AgregarCiudadComponent } from './components/agregar-ciudad/agregar-ciudad.component';
import { ModificarCiudadComponent } from './components/modificar-ciudad/modificar-ciudad.component';
import { ConsultarCiudadComponent } from './components/consultar-ciudad/consultar-ciudad.component';
import { EliminarCiudadComponent } from './components/eliminar-ciudad/eliminar-ciudad.component';
import { PrincipalCiudadComponent } from './components/principal-ciudad/principal-ciudad.component';

const routes: Routes = [

  { path: 'agregarCiudad', component: AgregarCiudadComponent},
  { path: 'modificarCiudad', component: ModificarCiudadComponent},
  { path: 'consultarCiudad', component: ConsultarCiudadComponent},
  { path: 'eliminarCiudad', component: EliminarCiudadComponent},
  { path: '', component: PrincipalCiudadComponent }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
  
})
export class Modulo02RoutingModule {


 }
