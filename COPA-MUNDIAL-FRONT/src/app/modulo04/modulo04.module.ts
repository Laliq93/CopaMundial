import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo04RoutingModule } from './modulo04-routing.module';
import { ViewComponent } from './components/view/view.component';
import { LoggedInGuard } from '../guards/logged-in.guard';


@NgModule({
  imports: [
    CommonModule,
    Modulo04RoutingModule
  ],
  declarations: [ViewComponent],
  providers: [LoggedInGuard]
})
export class Modulo04Module { }
