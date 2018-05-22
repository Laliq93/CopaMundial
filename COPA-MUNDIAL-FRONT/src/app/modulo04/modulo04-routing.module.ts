import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewComponent } from './components/view/view.component'
import { LoggedInGuard } from '../guards/logged-in.guard';

const routes: Routes = [
    { path: 'ver', component: ViewComponent, canActivate: [LoggedInGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo04RoutingModule { }
