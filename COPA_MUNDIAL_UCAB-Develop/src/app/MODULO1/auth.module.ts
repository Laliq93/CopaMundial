import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './client/login.component';
import { SigninComponent } from './client/signin.component';
import { SignupComponent } from './client/signup.component';
import { RecoveryComponent } from './client/recovery.component';
import { ChangePasswordComponent } from './client/changePassword.component';
import { LoginAdminComponent } from './admin/login-admin.component';
import { NgForm, Form, FormGroup, AbstractControl, FormBuilder, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule,FormsModule,
    ReactiveFormsModule],
  declarations: [
  	LoginComponent,
    SigninComponent,
    SignupComponent,
    RecoveryComponent,
    ChangePasswordComponent,
  	LoginAdminComponent
  ],
  
  providers: [],
  exports: [ 
  	LoginComponent,
    SigninComponent,
    SignupComponent,
    RecoveryComponent,
    ChangePasswordComponent,
	LoginAdminComponent
  ]
})

export class AuthModule {}