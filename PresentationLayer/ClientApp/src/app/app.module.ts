import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PublicDataComponent } from './public/public.component';
import { PrivateDataComponent } from './private/private.component';
import { LoginComponent  } from './login/login.component';
import { CheckInComponent } from './check-in/check-in.component';
import { JwtInterceptor } from './jwt-interseptor';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PublicDataComponent,
    PrivateDataComponent,
    LoginComponent,
    CheckInComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PublicDataComponent, pathMatch: 'full' },
      { path: 'private', component: PrivateDataComponent },
      { path: 'login', component: LoginComponent  },
      { path: 'check-in', component: CheckInComponent  },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
