import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewComponent } from './components/view/view.component';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { CrearComponent } from './components/crear/crear.component';
import { EditarComponent } from './components/editar/editar.component';

const routes: Routes = [
    { path: 'ver', component: ViewComponent, canActivate: [LoggedInGuard] },
    { path: 'crear', component: CrearComponent, canActivate: [LoggedInGuard] },
    { path: 'editar', component: EditarComponent, canActivate: [LoggedInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo04RoutingModule { }
