// Main Modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthHttpInterceptor, AuthModule } from '@auth0/auth0-angular';
import { ReactiveFormsModule } from '@angular/forms';

// Material Modules
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatProgressBarModule } from '@angular/material/progress-bar';

// Environment
import { environment as env } from 'src/environments/environment';

// Components
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthComponent } from './components/auth/auth.component';
import { LoginButtonComponent } from './components/login-button/login-button.component';
import { LogoutButtonComponent } from './components/logout-button/logout-button.component';
import { SignupButtonComponent } from './components/signup-button/signup-button.component';
import { UserButtonComponent } from './components/user-button/user-button.component';
import { NotebooksComponent } from './components/notebooks/notebooks.component';
import { CreateNotebookButtonComponent } from './components/create-notebook-button/create-notebook-button.component';
import { CreateNotebookDialogComponent } from './components/create-notebook-dialog/create-notebook-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    AuthComponent,
    LoginButtonComponent,
    LogoutButtonComponent,
    SignupButtonComponent,
    UserButtonComponent,
    NotebooksComponent,
    CreateNotebookButtonComponent,
    CreateNotebookDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule.forRoot({
      domain: "dev-0mmj660j.us.auth0.com",
      clientId: "Mgd2CTmmSNbmxveI5QHkyCQ0noblfl3L",
      audience: "https://notedapp.azurewebsites.net",
      httpInterceptor: {
        allowedList: [
          env.baseURL + '/get-user-notebooks',
          env.baseURL + '/create-notebook',
        ]
      }
    }),
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatProgressBarModule,
    MatProgressSpinnerModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
