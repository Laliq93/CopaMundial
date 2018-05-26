import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotLoggedInGuard } from 'src/app/guards/not-logged-in.guard';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';
import { EstpartidoComponent } from './estpartido/estpartido.component';
import { EstjugadorComponent } from './estjugador/estjugador.component';

const routes: Routes = [
  { path: 'estadisticas', component: EstgeneralComponent, canActivate: [NotLoggedInGuard] },
  { path: 'estpartidos', component: EstpartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'estjugador', component: EstjugadorComponent, canActivate: [NotLoggedInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo09RoutingModule { }
